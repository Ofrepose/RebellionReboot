using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasItemScript : MonoBehaviour {

	public GameObject repair;
	public GameObject shield;
	public GameObject attackPoints;
	public GameObject weaponBoost;

	public bool hasItem;

	public InventoryScript inventory;

	PlayerHealth playerhealth;

	RTSBattleController playerController;
	PlayerAttackScriptMultipleEnemies playerController2;


	BattleControllerTurnBased battleController;
	BattleControllerTurnBasedMultipleScript	battleController2;

	SingleFightScriptPlace singleFight;







	void Start () {
		


		singleFight = SingleFightScriptPlace.FindObjectOfType<SingleFightScriptPlace> ();
		playerhealth = PlayerHealth.FindObjectOfType<PlayerHealth> ();

		playerController = RTSBattleController.FindObjectOfType<RTSBattleController> ();
		battleController = BattleControllerTurnBased.FindObjectOfType<BattleControllerTurnBased> ();

		if (singleFight == null) {
		
			playerController2 = PlayerAttackScriptMultipleEnemies.FindObjectOfType<PlayerAttackScriptMultipleEnemies> ();

			battleController2 = BattleControllerTurnBasedMultipleScript.FindObjectOfType<BattleControllerTurnBasedMultipleScript> ();
		
		}


		
		




		





		/*repair.SetActive (false);
		shield.SetActive (true);
		attackPoints.SetActive (false);
		weaponBoost.SetActive (false);
		*/
		CheckIfAnyActive ();
	}

	public void CheckIfAnyActive(){
	
		if (!repair.activeSelf  && !shield.activeSelf && !attackPoints.activeSelf && !weaponBoost.activeSelf ) {
		
			hasItem = false;
		
		}
		if (repair.activeSelf  || shield.activeSelf || attackPoints.activeSelf || weaponBoost.activeSelf ) {

			hasItem = true;

		}

		Debug.Log ("does it have item?" + hasItem);
		//inventory.CheckAllSlotsForUse ();
	
	
	}
	
	public void UseItem(){



	

		if (repair.activeSelf) {
		
			Debug.Log (" using Repair");

			repair.SetActive (false);	

			CheckIfAnyActive ();

			playerhealth.GainHealth (30);

		
		}

		if (shield.activeSelf) {

			Debug.Log (" using Shield");

			shield.SetActive (false);

			if (singleFight != null) {
			
				RTSBattleController.shieldOn = true;

				playerController.shield.SetActive(true);

				playerController.ShieldCharge ();

				playerController.shieldAnimator.SetTrigger ("ShieldOn");

				playerController.shieldOnAudio.Play ();

				playerController.shieldBarPanel.SetActive (true);
			
			}

			if (singleFight == null) {
			
				PlayerAttackScriptMultipleEnemies.shieldOn = true;

				playerController2.shield.SetActive(true);

				playerController2.ShieldCharge ();

				playerController2.shieldAnimator.SetTrigger ("ShieldOn");

				playerController2.shieldOnAudio.Play ();

				playerController2.shieldBarPanel.SetActive (true);
			
			}



		

			CheckIfAnyActive ();

		}

		if (attackPoints.activeSelf) {
		
			Debug.Log ("using attackpoints");

			attackPoints.SetActive (false);

			if (singleFight == null) {
			
				battleController.attackPoints += 100;

			
			}

			if (singleFight != null) {

				battleController2.attackPoints += 100;

			}


			CheckIfAnyActive ();

		}


		if (weaponBoost.activeSelf && battleController.playerTurn) {
		
			Debug.Log ("using weaponBoost");

			playerController.weaponCharge.SetActive (true);
			if (singleFight != null) {
			
				RTSBattleController.weaponIsCharged = true;
			
			}

			if (singleFight == null) {
			
				PlayerAttackScriptMultipleEnemies.weaponIsCharged = true;
			
			}

			weaponBoost.SetActive (false);

			CheckIfAnyActive ();
		
		}

		inventory.CheckAllSlotsForUse ();

	}
}
