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

	// Use this for initialization
	void Start ()
	{
		dir = 0;
		Rb2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		x_axis = Input.GetAxisRaw ("Horizontal");
		y_axis = Input.GetAxisRaw ("Vertical");

		Rb2D.velocity = new Vector2 (x_axis, y_axis) * velocity;

		updateDir ();
	}

	// Return the direction (1 direita, 2 esquerda, 3 cima, 4 baixo)
	void updateDir()
	{
		if (x_axis == 1)
		{
			dir = 1;
			return;
		}

		if (x_axis == -1)
		{
			dir = 2;
			return;
		}

		if (y_axis == 1)
		{
			dir = 3;
			return;
		}


		if (y_axis == -1)
		{
			dir = 4;
			return;
		}
	}

	// Parses dir
	string getDirAsString()
	{
		switch (dir)
		{
		case 0:
			return "Parado";
		case 1:
			return "Direita";
		case 2:
			return "Esquerda";
		case 3:
			return "Cima";
		case 4:
			return "Baixo";
		default:
			return "Error Parsing Direction";
		}
	}
}
