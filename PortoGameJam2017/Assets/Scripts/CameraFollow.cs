using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;


	private PlayerController2D playerScript;
	int current_level;

	int first_top;
	int first_bot;

	// Use this for initialization
	void Start ()
	{
		playerScript = target.GetComponent<PlayerController2D> ();
		first_top = -276;
		first_bot = -324;
	}
	
	// Update is called once per frame
	void Update ()
	{
		current_level = target.GetComponent<PlayerController2D> ().getCurrentLevel ();
		Debug.Log (current_level);

		float minY = first_bot + 150 * current_level;
		float maxY = first_top + 150 * current_level;

		float y;
	

		if (target.transform.position.y < minY) {
			y = minY;
		} 
		else if (target.transform.position.y > maxY) {
			y = maxY;	
		} else {
			y = target.transform.position.y;
		}


		Vector3 v3 = new Vector3 (0f, y, -10f);

		transform.position = v3;
	}
}
