using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2D : MonoBehaviour
{
	private Transform player_transform;
	private bool in_range;

	public float engageRange;

	// Use this for initialization
	void Start ()
	{
		player_transform = FindObjectOfType<PlayerController2D> ().transform;

		if (player_transform.Equals(null))
			Debug.Log ("Couldn't find player transform");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// Fixed Update
	void FixedUpdate ()
	{
		in_range = checkInRange ();

		if (in_range)
			Debug.Log ("In Range");
		else
			Debug.Log ("Not In Range");
	}

	// Checks wether the player is in engage range or not
	bool checkInRange()
	{
		float distance = Vector3.Distance (transform.position, player_transform.position);
		return (distance <= engageRange);
	}
}
