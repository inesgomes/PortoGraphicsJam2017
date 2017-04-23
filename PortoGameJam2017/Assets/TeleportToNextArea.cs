using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToNextArea : MonoBehaviour {


	public BoxCollider2D thisPortal;

	public GameObject nextSpawn;

	Vector2 nextSpawnPoint;


	void Start () {
	
		nextSpawnPoint = nextSpawn.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Player")
			col.gameObject.transform.position = nextSpawnPoint;

	}
}
