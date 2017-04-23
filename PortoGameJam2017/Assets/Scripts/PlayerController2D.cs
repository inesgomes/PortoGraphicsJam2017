using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour
{
	private Rigidbody2D Rb2D;
	private Animator anim;
	private float x_axis;
	private float y_axis;

	private int dir;	// default 0

	public float velocity;

	public BoxCollider2D right_attack;
	public BoxCollider2D left_attack;
	public BoxCollider2D front_attack;
	public BoxCollider2D back_attack;
	private BoxCollider2D[] attack_vector;

	// Attack vars
	private bool attacking;

	private float attack_cooldown;
	private float next_attack_time;

	private float trigger_delay;
	private float trigger_time;

	// Health
	public int currHP;
	public Sprite[] sprites;
	public Image image;
	public Image image0;
	public Image image1;
	public Image image2;

	private DialogueScriptManager dialogueManager;

	public bool hit;

	//knockback
	public float knock_back_time;
	public float knock_back_delay;

	public float invincibility;

	//Audio
	GamePlayAudioManagement audioManager;

	//current level
	public bool[] currentLevels;

	// Use this for initialization
	void Start ()
	{
		dialogueManager = FindObjectOfType<DialogueScriptManager> ();

		sprites = new Sprite[3];
		currentLevels = new bool[]
		{ true, false, false, false, false, false};

		audioManager = GameObject.FindGameObjectWithTag ("audio").GetComponent<GamePlayAudioManagement> ();

		invincibility = .0f;

		dir = -1;
		Rb2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> (); 

		attack_vector = new BoxCollider2D[4];

		sprites [0] = image0.sprite;
		sprites [1] = image1.sprite;
		sprites [2] = image2.sprite;

		attack_vector [0] = right_attack;
		attack_vector [1] = left_attack;
		attack_vector [2] = front_attack;
		attack_vector [3] = back_attack;
 
		next_attack_time = -1;
		attack_cooldown = 0.5f;

		trigger_time = -1;
		trigger_delay = 0.25f;

		knock_back_delay = .5f;
		knock_back_time = .5f;

		hit = false;

	}
	
	// Update is called once per frame
	void Update ()
	{
		

		if(manageKnockback()){
			return;
		}

		manageSpeed ();
		manageAttack ();

	}

	public int getCurrentLevel(){

		int i;
		int maxLevel = 0;
		for (i = 0; i < currentLevels.Length; i++) {
			
			if (currentLevels [i]) {
				maxLevel = i;
			}

		}

		return maxLevel;
	}

	// Handler speed
	void manageSpeed()
	{
		x_axis = Input.GetAxisRaw ("Horizontal");
		y_axis = Input.GetAxisRaw ("Vertical");

		Rb2D.velocity = new Vector2 (x_axis, y_axis) * 12;
		anim.SetFloat ("Velocity", Rb2D.velocity.magnitude);

		//audio

		if (Rb2D.velocity.magnitude > 0)
			audioManager.playRunMusic ();
		else
			audioManager.stopRunMusic ();
	}

	bool manageKnockback(){

		if (!hit) {
			return false;
		}

		knock_back_time -= Time.deltaTime;


		if(knock_back_time <= 0){

			if(currHP > 0)
			{
				hit = false;
				currHP--;
				image.sprite = sprites [currHP];

				//audio
				/*if (currHP <= 2)
					audioManager.playSadMusic ();
				else
					audioManager.playAmbientMusic ();*/

				if (currHP == 0)
				{
					//audio
					audioManager.stopRunMusic ();
					SceneManager.LoadScene ("gameOver");
				}
			}

			knock_back_time = knock_back_delay;
			hit = false;
			return false;
		}

		return true;
	}

	// Handler attack
	void manageAttack()
	{
		if (attacking)
		{
			next_attack_time = Mathf.Max (0, next_attack_time - Time.deltaTime);
			trigger_time = Mathf.Max (0, trigger_time - Time.deltaTime);

			if (trigger_time == 0)
			{
				attack_vector [dir].enabled = true;
			}

			if (next_attack_time == 0)
			{
				attacking = false;
				anim.SetBool ("Attack", false);

				foreach (BoxCollider2D bc in attack_vector)
				{
					bc.enabled = false;
				}
				attacking = false;
			}
		}
		else
		{
			updateDir ();
			anim.SetInteger ("Dir", dir);

			if (Input.GetKeyDown (KeyCode.Space))
			{
				attacking = true;
				anim.SetBool ("Attack", true);

				//audio
				audioManager.playMissPunchMusic();

				next_attack_time = attack_cooldown;
				trigger_time = trigger_delay;
			}
		}
	}
		
		
	// Return the direction (0 direita, 1 esquerda, 2 cima, 3 baixo)
	void updateDir()
	{
		if (x_axis == 1)
		{
			dir = 0;
			return;
		}

		if (x_axis == -1)
		{
			dir = 1;
			return;
		}

		if (y_axis == 1)
		{
			dir = 2;
			return;
		}


		if (y_axis == -1)
		{
			dir = 3;
			return;
		}
	}

	// Parses dir
	string getDirAsString(int direction)
	{
		switch (direction)
		{
		case -1:
			return "Parado";
		case 0:
			return "Direita";
		case 1:
			return "Esquerda";
		case 2:
			return "Cima";
		case 3:
			return "Baixo";
		default:
			return "Error Parsing Direction";
		}
	}


	public void endGame(){
		dialogueManager.GetComponent<DialogueScriptManager> ().collidedWithBoss ();
	}


	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "lobo") {

			hit = true;
			//Calcular vetor oposto à colisao para fazer knockback
			Vector2 normal = ( gameObject.transform.position - col.gameObject.transform.position).normalized;
			Rb2D.velocity = new Vector2 (0,0);
			Rb2D.AddForce (normal * 1500);
		}

		if (col.gameObject.tag == "old") {
			dialogueManager.GetComponent<DialogueScriptManager> ().collidedWithOldMan ();
			col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}

		if (col.gameObject.tag == "b1") {
			dialogueManager.GetComponent<DialogueScriptManager> ().collidedWithArea1 ();
			col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}

		if (col.gameObject.tag == "t1") {
			dialogueManager.GetComponent<DialogueScriptManager> ().collidedWithTransition1 ();
			col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}

		if (col.gameObject.tag == "b2") {
			dialogueManager.GetComponent<DialogueScriptManager> ().collidedWithArea2 ();
			col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}

		if (col.gameObject.tag == "b3") {
			dialogueManager.GetComponent<DialogueScriptManager> ().collidedWithTransition2 ();
			col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}




	
	}



}