using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {


	public GameObject repair;
	public GameObject shield;
	public GameObject attackPoints;
	public GameObject weaponBoost; 
	public GameObject credits;

	//Randomize

	int whichOne;

	public static int DROPITEM = 0;



	void Start () {

		repair.SetActive (false);
		shield.SetActive (false);
		attackPoints.SetActive (false);
		weaponBoost.SetActive (false);
		credits.SetActive (false);

	}

	void Update(){
		if (DROPITEM == 1) {
		
			whichOne = Random.Range (0, 5);

			Debug.Log (whichOne + " which one");

			if (whichOne == 0) {
			
				repair.SetActive (true);


			}
			if (whichOne == 1) {

				shield.SetActive (true);

			}
			if (whichOne == 2) {

				attackPoints.SetActive (true);

			}
			if (whichOne == 3) {

				weaponBoost.SetActive (true);

			}
			if (whichOne == 4) {

				credits.SetActive (true);

			}

			DROPITEM = 2;

		
		}


	}

}
