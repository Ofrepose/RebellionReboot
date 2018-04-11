using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconObject0Script : MonoBehaviour {

	public GameObject playerLaser;

	LevelManager levelmanager;

	public GameObject explosionPrefab;

	public GameObject bodyOfAi;


	Collider laser;


	void Start () {



		levelmanager = LevelManager.FindObjectOfType<LevelManager> ();




	}

	void OnTriggerEnter(Collider col){
	
		Collider laser = playerLaser.GetComponent<Collider> ();

		//BasicLaserScript laser = collider.gameObject.GetComponent<BasicLaserScript> ();
		//playerLaser = gameObject.GetComponent<Collider>();

		if (laser) {

			Vector3 newPos = new Vector3 (transform.position.x, transform.position.y , transform.position.z + 11f);
		
			GameObject explode = Instantiate (explosionPrefab,newPos, Quaternion.identity) as GameObject;

			bodyOfAi.SetActive (false);

			//determine how much money you just goooot

			int cashMonies = Random.Range (50, 500);

			Character.Credits = Character.Credits + cashMonies;


			Invoke ("AIDead", 10f);





		
		}
	
	
	}

	void AIDead(){


		PlayerPrefs.SetInt("NGC1300_BEACONDONE", 1);

		levelmanager.LoadLevel (Character.where);


	}


}
