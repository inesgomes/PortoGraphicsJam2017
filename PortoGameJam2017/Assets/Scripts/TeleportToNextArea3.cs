using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToNextArea3 : MonoBehaviour {


	public BoxCollider2D thisPortal;

	public GameObject nextSpawn;

	Vector2 nextSpawnPoint;

	//Audio
	GamePlayAudioManagement audioManager;

	void Start () {
	
		audioManager = GameObject.FindGameObjectWithTag ("audio").GetComponent<GamePlayAudioManagement> ();
		audioManager.playPortalMusic();
		nextSpawnPoint = nextSpawn.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Player") {

			col.gameObject.GetComponent<PlayerController2D> ().currentLevels [4] = true;

			col.gameObject.transform.position = nextSpawnPoint;
		}


	}
}
