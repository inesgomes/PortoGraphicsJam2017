using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TeleportToNextArea : MonoBehaviour {


	public BoxCollider2D thisPortal;

	public GameObject nextSpawn;

	Vector2 nextSpawnPoint;

	//Audio
	GamePlayAudioManagement audioManager;

	void Start () {
	
		audioManager = GameObject.FindGameObjectWithTag ("audio").GetComponent<GamePlayAudioManagement> ();

		nextSpawnPoint = nextSpawn.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Player") {

			col.gameObject.GetComponent<PlayerController2D> ().currentLevels [1] = true;

			col.gameObject.transform.position = nextSpawnPoint;

			audioManager.playPortalMusic();
		}


	}
}
