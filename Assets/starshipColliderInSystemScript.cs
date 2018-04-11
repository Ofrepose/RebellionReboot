using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starshipColliderInSystemScript : MonoBehaviour {
	//public GameObject enemy;
	LevelManager levelmanager;
	static int wasHere = 0;

	// Use this for initialization
	void Start () {
		levelmanager = LevelManager.FindObjectOfType<LevelManager> ();

	}

	void OnTriggerEnter (Collider col){

		if (col.tag == "Player" && wasHere == 0) {
			PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_X", this.transform.position.x);
			PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_Z",  this.transform.position.z);
			PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_Y",  this.transform.position.y);

			wasHere = 1;
			levelmanager.LoadLevel ("NBC1300STARBASEFLYING");

		}



	}

	void OnTriggerExit(Collider col){

		if (col.tag == "Player") {
		
			wasHere = 0;
		
		}


	}

}
