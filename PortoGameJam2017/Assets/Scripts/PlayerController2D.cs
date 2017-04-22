using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
	private Rigidbody2D Rb2D;
	private float x_axis;
	private float y_axis;

	private int dir; // default 0

	public float velocity;

	public BoxCollider2D right_attack;
	public BoxCollider2D left_attack;
	public BoxCollider2D front_attack;
	public BoxCollider2D back_attack;
	private BoxCollider2D[] attack_vector;
	private float next_attack_time;
	private int attack_cooldown;

	private bool attacked;

	// Use this for initialization
	void Start ()
	{
		dir = -1;
		Rb2D = GetComponent<Rigidbody2D> ();

		attack_vector = new BoxCollider2D[4];

		next_attack_time = -1;
		attack_cooldown = 1;

		attack_vector [0] = right_attack;
		attack_vector [1] = left_attack;
		attack_vector [2] = front_attack;
		attack_vector [3] = back_attack;
 
	}
	
	// Update is called once per frame
	void Update ()
	{

		

		x_axis = Input.GetAxisRaw ("Horizontal");
		y_axis = Input.GetAxisRaw ("Vertical");


		Rb2D.velocity = new Vector2 (x_axis, y_axis) * velocity;

		//atacar

		if (attacked) {
			foreach (BoxCollider2D bc in attack_vector) {
				bc.enabled = false;
			}
			attacked = false;
		}

		if (Input.GetKey (KeyCode.Space)) {
			Attack ();
		}


		updateDir ();
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

	void Attack(){
			
		int attackDirection = dir;

		if(next_attack_time <= Time.time){

			attack_vector [attackDirection].enabled = true;

			Debug.Log("Atacou " + getDirAsString(attackDirection));

			attacked = true;

			next_attack_time = Time.time + attack_cooldown;

		}

	}






}
