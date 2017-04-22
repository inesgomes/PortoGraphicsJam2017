using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2D : MonoBehaviour
{
	private Rigidbody2D Rb2D;
	private Transform player_transform;
	private bool in_range;

	public float engageRange;
	public float velocity;
	public float minDist;

	// Use this for initialization
	void Start ()
	{
		player_transform = FindObjectOfType<PlayerController2D> ().transform;
		Rb2D = GetComponent<Rigidbody2D> ();

		if (player_transform.Equals(null))
			Debug.Log ("Couldn't find player transform");
	}
	
	// Update is called once per frame
	void Update ()
	{
		float distance = Vector3.Distance (transform.position, player_transform.position);

		if (distance <= engageRange && distance > minDist)
		{
			Vector2 vector_dir = (player_transform.position - transform.position) / distance;
			Rb2D.velocity = (vector_dir * velocity);
		}
		else
			Rb2D.velocity = Vector2.zero;
	}

}
