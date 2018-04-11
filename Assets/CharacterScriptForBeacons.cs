using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScriptForBeacons : MonoBehaviour {

	public GameObject resistance;

	 public GameObject silverHawk;

	public GameObject playerShip;

	bool isSilverhawk;






	void Start(){

		if (PlayerPrefs.GetString("SHIP_CHOICE") == "SILVERHAWK"){
			isSilverhawk =  true;


		}
		if (PlayerPrefs.GetString("SHIP_CHOICE") == "RESISTANCE"){
			isSilverhawk = false;
		}

		if (isSilverhawk && silverHawk) {
			silverHawk.SetActive (true);
			resistance.SetActive (false);


		}
		if (isSilverhawk == false && resistance ) {
			silverHawk.SetActive (false);
			resistance.SetActive (true);
			if (PlayerPrefs.GetInt ("PlasmaLaserOnResistance") == 1) {
				//PlasmaLaserOnResistance.SetActive(true);
			}
		}
	}


	void update(){
	
		if (Character.isSilverhawk && silverHawk == null) {
		
			silverHawk = GameObject.FindGameObjectWithTag ("SILVERHAWK");

		
		}


		if (Character.isSilverhawk == false && resistance == null) {
		
			resistance = GameObject.FindGameObjectWithTag ("RESISTANCE");

		
		}
	
	
	}
}
