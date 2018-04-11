using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconObject1Script : MonoBehaviour {


	LevelManager levelmanager;

	public GameObject bodyOfAi;

	StarbaseFlyingScript playerSpeed;




	void Start () {

		playerSpeed = StarbaseFlyingScript.FindObjectOfType<StarbaseFlyingScript> ();

		levelmanager = LevelManager.FindObjectOfType<LevelManager> ();




	}

	void OnTriggerEnter(Collider col){

	
		if (col.tag == "Player") {

			playerSpeed.playerSpeed = 0f;

			//Invoke ("AIDead", 10f);






		}


	}

	void AIDead(){


		PlayerPrefs.SetInt("NGC1300_BEACONDONE", 1);

		levelmanager.LoadLevel (Character.where);


	}


}
