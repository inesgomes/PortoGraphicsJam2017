using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFollow : MonoBehaviour {


	Transform playerPos;

	public GameObject player;


	void Start () {

		playerPos = player.transform;
		
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.transform.position = player.transform.position;
		
	}
}
