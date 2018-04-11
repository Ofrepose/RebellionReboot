using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsFight : MonoBehaviour {

	public GameObject Skill1;
	public GameObject Skill1Charge;
	
	public GameObject Skill2;
	public GameObject Skill2Charge;
	
	public GameObject Skill3;

	public GameObject Skill4;
	public GameObject Skill4Charge;

	public GameObject Skill5;
	public GameObject Skill5Charge;

	public GameObject Skill6;
	
	public GameObject Skill7;
	public GameObject Skill7Charge;
	
	public GameObject Skill8;
	public GameObject Skill9;
	public GameObject Skill10;


	SingleFightScriptPlace isItSingleFight;



	void Start () {



		
		if (PlayerPrefs.GetFloat("SHIELDBOOSTER_SKILL") == 1){
			Skill1.SetActive(true);
			
		}
		if (PlayerPrefs.GetFloat("REPAIR_SKILL") == 1){
			Skill2.SetActive(true);
		}
		if (PlayerPrefs.GetFloat("SHIELDDEFLECTOR_SKILL") == 1 ){
			Skill7.SetActive(true);
		}

		if (PlayerPrefs.GetFloat ("DIPLOMACY_SKILL") == 1) {
		
			Skill4.SetActive (true);
			//Skill4Charge.SetActive (false);
		
		}

		if (PlayerPrefs.GetFloat("EVADEBOOSTER_SKILL") == 1){

			Skill5.SetActive(true);


		}

		isItSingleFight = SingleFightScriptPlace.FindObjectOfType<SingleFightScriptPlace> ();
			
			
		
	}
	
	void Update () {

		if (isItSingleFight != null) {

			Debug.Log ("IS SINGLE FIGHT TRRUE");
		
			if (RTSBattleController.shieldCharged == false){
				Skill1Charge.SetActive(true);
			}
			if (RTSBattleController.shieldCharged == true){
				Skill1Charge.SetActive(false);
			}
			if (RTSBattleController.repairCharged == false){
				Skill2Charge.SetActive(true);
			}
			if (RTSBattleController.repairCharged == true){
				Skill2Charge.SetActive(false);
			}
			if (RTSBattleController.shieldDeflectorCharged == false){
				Skill7Charge.SetActive(true);
			}
			if (RTSBattleController.shieldDeflectorCharged == true){
				Skill7Charge.SetActive(false);
			}

			if (RTSBattleController.diplomacyUsed == true) {

				Skill4Charge.SetActive (true);

			}

			if (RTSBattleController.evadeCharged == false){
				Skill5Charge.SetActive(true);
			}
			if (RTSBattleController.evadeCharged == true){
				Skill5Charge.SetActive(false);
			}

		
		}
		



		//MULTIPLE ENEMIES

			if (isItSingleFight == null) {
		

			if (PlayerAttackScriptMultipleEnemies.shieldCharged == false){
				Skill1Charge.SetActive(true);
			}
			if (PlayerAttackScriptMultipleEnemies.shieldCharged == true){
				Skill1Charge.SetActive(false);
			}
			if (PlayerAttackScriptMultipleEnemies.repairCharged == false){
				Skill2Charge.SetActive(true);
			}
			if (PlayerAttackScriptMultipleEnemies.repairCharged == true){
				Skill2Charge.SetActive(false);
			}
			if (PlayerAttackScriptMultipleEnemies.shieldDeflectorCharged == false){
				Skill7Charge.SetActive(true);
			}
			if (PlayerAttackScriptMultipleEnemies.shieldDeflectorCharged == true){
				Skill7Charge.SetActive(false);
			}

			if (PlayerAttackScriptMultipleEnemies.diplomacyUsed == true) {

				Skill4Charge.SetActive (true);

			}

			if (PlayerAttackScriptMultipleEnemies.evadeCharged == false){
				Skill5Charge.SetActive(true);
			}
			if (PlayerAttackScriptMultipleEnemies.evadeCharged == true){
				Skill5Charge.SetActive(false);
			}

		
		}

	


		
		
		
		
	}
}
