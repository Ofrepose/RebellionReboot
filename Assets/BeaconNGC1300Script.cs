using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconNGC1300Script : MonoBehaviour {

	GameObject player;
	LevelManager levelmanager;
	int[] Randomize = { 0,1, 2, 3, 4, 5 };
	int whichOne;

	int alreadyDone;


	void Start () {

		levelmanager = LevelManager.FindObjectOfType<LevelManager> ();

		whichOne = Random.Range (0, 2);


		//ADD FOR OTHER ALTERNATE SITUATIONS. SO FAR ONLY HAVE ONE SCENE BEACON0
		//whichOne = 0;

	}
	
	void Update () {

		if (player == null) {
		
			player = GameObject.FindGameObjectWithTag ("Player");

			Debug.Log ("Found player in update");
		
		}
		
	}


	void OnTriggerEnter(Collider col){
	
		if (col.tag == "Player") {
		
			//Load Level here 

			Debug.Log ("Player has hit beacon");
			PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_X", this.transform.position.x);
			PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_Z",  this.transform.position.z);
			PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_Y",  this.transform.position.y);




			//alreadyDone = whichOne;
			PlayerPrefs.SetInt("NGC1300_BEACONDONE", 1);
			levelmanager.LoadLevel ("Beacon" + Randomize [whichOne]);
		
		}
	
	
	}
}
