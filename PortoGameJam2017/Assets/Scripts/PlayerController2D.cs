using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

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
	public bool hit;

	//knockback
	public float knock_back_time;
	public float knock_back_delay;

	// Use this for initialization
	void Start ()
	{
		dir = -1;
		Rb2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> (); 

		attack_vector = new BoxCollider2D[4];

		attack_vector [0] = right_attack;
		attack_vector [1] = left_attack;
		attack_vector [2] = front_attack;
		attack_vector [3] = back_attack;
 
		next_attack_time = -1;
		attack_cooldown = 0.5f;

		trigger_time = -1;
		trigger_delay = 0.25f;

		knock_back_delay = .3f;
		knock_back_time = .3f;

		hit = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(manageKnockback()){
			return;
		}

		manageHealth ();

		manageSpeed ();
		manageAttack ();

	}

	// Handler speed
	void manageSpeed()
	{
		x_axis = Input.GetAxisRaw ("Horizontal");
		y_axis = Input.GetAxisRaw ("Vertical");

		Rb2D.velocity = new Vector2 (x_axis, y_axis) * velocity;
		anim.SetFloat ("Velocity", Rb2D.velocity.magnitude);
	}

	bool manageKnockback(){

		if (!hit) {
			return false;
		}

		knock_back_time -= Time.deltaTime;

		Debug.Log (knock_back_time);

		if(knock_back_time <= 0){
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

				next_attack_time = attack_cooldown;
				trigger_time = trigger_delay;
			}
		}
	}

	// Handler health
	void manageHealth()
	{
		image.sprite = sprites [currHP];

		if(hit && currHP > 0)
		{
			hit = false;
			currHP--;

			if (currHP == 0)
			{
				Debug.Log ("I DIEDEDED");
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

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Enemy") {
			hit = true;
			
			Debug.Log ("Atacado");

			//Calcular vetor oposto à colisao para fazer knockback
			Vector2 normal = ( gameObject.transform.position - col.gameObject.transform.position).normalized;

			Rb2D.AddForce (normal * 700);
		}
	
	}



}