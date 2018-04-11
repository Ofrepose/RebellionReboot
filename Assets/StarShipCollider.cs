using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShipCollider : MonoBehaviour {
	GameObject player;
	//public GameObject enemy;
	LevelManager levelmanager;

	// Use this for initialization
	void Start () {
		levelmanager = LevelManager.FindObjectOfType<LevelManager> ();

	}
	
	void OnTriggerEnter (Collider col){
		player = GameObject.FindGameObjectWithTag ("Player");
		if (col.tag == "Player") {
			levelmanager.LoadLevel ("NGC1300STARBASE");
			
		}

	}


}
