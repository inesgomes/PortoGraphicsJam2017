using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
	private Rigidbody2D Rb2D;
	private Animator anim;
	private float x_axis;
	private float y_axis;

	private int dir; // default 0

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
	}
	
	// Update is called once per frame
	void Update ()
	{
		x_axis = Input.GetAxisRaw ("Horizontal");
		y_axis = Input.GetAxisRaw ("Vertical");

		Rb2D.velocity = new Vector2 (x_axis, y_axis) * velocity;
		anim.SetFloat ("Velocity", Rb2D.velocity.magnitude);

		// Attack

		if (attacking)
		{
			Debug.Log ("Attacking");

			next_attack_time = Mathf.Max (0, next_attack_time - Time.deltaTime);
			trigger_time = Mathf.Max (0, trigger_time - Time.deltaTime);

			if (trigger_time == 0)
			{
				Debug.Log ("Enabled Trigger");
				attack_vector [dir].enabled = true;
			}

			if (next_attack_time == 0)
			{
				attacking = false;
				anim.SetBool ("Attack", false);

				Debug.Log ("Disabled all triggers");
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

	/*
	void Attack()
	{		
		int attackDirection = dir;

		if (attackDirection == -1)
		{
			return;
		}

		if(next_attack_time <= Time.time)
		{
			Debug.Log("Atacou " + getDirAsString(attackDirection));

			attacked = true;

			anim.SetBool ("Attack", true);

			next_attack_time = Time.time + attack_cooldown;
		}
	}
	*/
}
