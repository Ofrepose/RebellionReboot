using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToTargetScript : MonoBehaviour {

	GoingToShipAfterBattleScript playerSpeed;

	public GameObject thankYouText;

	XP credits;




	void Start(){

		playerSpeed = GoingToShipAfterBattleScript.FindObjectOfType<GoingToShipAfterBattleScript> ();

		thankYouText.SetActive (false);

		credits = XP.FindObjectOfType<XP> ();

			
	}



	void OnTriggerEnter(Collider col){

		if (col.tag == "Player") {
		
			playerSpeed.playerSpeed = 0;

			thankYouText.SetActive (true);

			Character.Credits = Character.Credits + 1000;
			PlayerPrefs.SetInt ("PLAYER_CREDITS", Character.Credits);

			credits.UpdateDisplay ();
		
		}





	}


}
