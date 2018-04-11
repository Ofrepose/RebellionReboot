using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

	//Check these to determine if open slot available.
	public HasItemScript itemSlot1;
	public HasItemScript itemSlot2;
	public HasItemScript itemSlot3;
	public HasItemScript itemSlot4;

	public bool repairDropItem;
	public bool shieldDropItem;
	public bool attackPointDropItem;
	public bool weaponJammerDropItem;
	public bool creditsDropItem;

	public bool hasItem;

	public Transform player;

	XP getCredits;



	void Start(){
	
		getCredits = XP.FindObjectOfType<XP> ();

	
	}

	
	void Update () {

		//if (Input.GetKeyDown(KeyCode.G)){

			transform.LookAt(player);

			transform.position = Vector3.Lerp (transform.position, player.position, Time.deltaTime * 5f);

		//}
		
	}


	void OnTriggerEnter(Collider col){


	
		if (col.tag == "Player") {
		
			if (repairDropItem) {
			
				GiveRepair ();
			
			
			}

			if (shieldDropItem) {

				GiveShieldBoost ();

			}

			if (attackPointDropItem) {

				GiveAttackPoints ();

			}

			if (weaponJammerDropItem) {

				GiveWeaponJammer ();

			}

			if (creditsDropItem) {

				GiveCredits ();

			}

			Destroy (this.gameObject);
		
		}
	
	}

	public void GiveRepair(){
	
		if (!itemSlot1.hasItem) {	

			itemSlot1.repair.SetActive (true);
			itemSlot1.hasItem = true;
			PlayerPrefs.SetInt ("Slot1", 1);
		
			return;
					
		}
		if (!itemSlot2.hasItem) {	

			itemSlot2.repair.SetActive (true);
			PlayerPrefs.SetInt ("Slot2", 1);
			itemSlot2.hasItem = true;


			return;

		}

		if (!itemSlot3.hasItem) {	

			itemSlot3.repair.SetActive (true);
			PlayerPrefs.SetInt ("Slot3", 1);
			itemSlot3.hasItem = true;


			return;

		}

		if (!itemSlot4.hasItem) {	

			itemSlot4.repair.SetActive (true);
			PlayerPrefs.SetInt ("Slot4", 1);
			itemSlot4.hasItem = true;


			return;

		} else {
			Debug.Log ("Eveything is registered as full in item script");
		
		}
	
	}

	public void GiveShieldBoost(){

		if (!itemSlot1.hasItem) {
		
			itemSlot1.shield.SetActive (true);

			itemSlot1.hasItem = true;


			PlayerPrefs.SetInt ("Slot1", 2);

			return;
		
		}
		if (!itemSlot2.hasItem) {

			itemSlot2.shield.SetActive (true);

			itemSlot2.hasItem = true;

			PlayerPrefs.SetInt ("Slot2", 2);

			return;

		}

		if (!itemSlot3.hasItem) {

			itemSlot3.shield.SetActive (true);

			itemSlot3.hasItem = true;

			PlayerPrefs.SetInt ("Slot3", 2);

			return;

		}

		if (!itemSlot4.hasItem) {

			itemSlot4.shield.SetActive (true);

			itemSlot4.hasItem = true;

			PlayerPrefs.SetInt ("Slot4", 2);

			return;

		}



	}


	public void GiveAttackPoints(){

		if (!itemSlot1.hasItem) {

			itemSlot1.attackPoints.SetActive (true);

			itemSlot1.hasItem = true;

			PlayerPrefs.SetInt ("Slot1", 3);

			return;

		}
		if (!itemSlot2.hasItem) {

			itemSlot2.attackPoints.SetActive (true);

			itemSlot2.hasItem = true;

			PlayerPrefs.SetInt ("Slot2", 3);

			return;

		}

		if (!itemSlot3.hasItem) {

			itemSlot3.attackPoints.SetActive (true);

			itemSlot3.hasItem = true;

			PlayerPrefs.SetInt ("Slot3", 3);

			return;

		}

		if (!itemSlot4.hasItem) {

			itemSlot4.attackPoints.SetActive (true);

			itemSlot4.hasItem = true;

			PlayerPrefs.SetInt ("Slot4", 3);

			return;

		}

	}


	public void GiveWeaponJammer(){

		if (!itemSlot1.hasItem) {

			itemSlot1.weaponBoost.SetActive (true);

			itemSlot1.hasItem = true;

			PlayerPrefs.SetInt ("Slot1", 4);

			return;

		}
		if (!itemSlot2.hasItem) {

			itemSlot2.weaponBoost.SetActive (true);

			itemSlot2.hasItem = true;

			PlayerPrefs.SetInt ("Slot2", 4);

			return;

		}
		if (!itemSlot3.hasItem) {

			itemSlot3.weaponBoost.SetActive (true);

			itemSlot3.hasItem = true;

			PlayerPrefs.SetInt ("Slot3", 4);

			return;

		}
		if (!itemSlot4.hasItem) {

			itemSlot4.weaponBoost.SetActive (true);

			itemSlot4.hasItem = true;

			PlayerPrefs.SetInt ("Slot4", 4);

			return;

		}


	}

	public void GiveCredits(){

		int randomAmount = Random.Range (1, 250);

		getCredits.creditsHere += randomAmount; 

		getCredits.UpdateDisplay ();

	}
}
