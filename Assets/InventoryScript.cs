using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {

	public GameObject inventoryPanel;

	public HasItemScript itemSlot1;
	public HasItemScript itemSlot2;
	public HasItemScript itemSlot3;
	public HasItemScript itemSlot4;
	/*
	public HasItemScript itemSlot5;
	public HasItemScript itemSlot6;
	public HasItemScript itemSlot7;
	public HasItemScript itemSlot8;
	public HasItemScript itemSlot9;
	public HasItemScript itemSlot10;
	public HasItemScript itemSlot11;
	public HasItemScript itemSlot12;
	public HasItemScript itemSlot13;
	public HasItemScript itemSlot14;
	public HasItemScript itemSlot15;
	public HasItemScript itemSlot16;*/

	int slot1;
	int slot2;
	int slot3;
	int slot4;


	bool isOpen= false;


	void Start(){
		

		slot1 = 4;//PlayerPrefs.GetInt ("Slot1");
		slot2 = PlayerPrefs.GetInt ("Slot2");
		slot3 = PlayerPrefs.GetInt ("Slot3");
		slot4 = PlayerPrefs.GetInt ("Slot4");

		Debug.Log ("slot1" + slot1);
		Debug.Log ("slot2" + slot2);
		Debug.Log ("slot3" + slot3);
		Debug.Log ("slot4" + slot4);

		inventoryPanel.SetActive (false);

		if (slot1 != 0) {
		
			if (slot1 == 1) {
			
				itemSlot1.repair.SetActive (true);
			
			}
			if (slot1 == 2) {

				itemSlot1.shield.SetActive (true);

			}

			if (slot1 == 3) {

				itemSlot1.attackPoints.SetActive (true);

			}

			if (slot1 == 4) {

				itemSlot1.weaponBoost.SetActive (true);

			}
			itemSlot1.hasItem = true;
		
		}

		if (slot2 != 0) {

			itemSlot2.hasItem = true;


			if (slot2 == 1) {

				itemSlot2.repair.SetActive (true);

			}
			if (slot2 == 2) {

				itemSlot2.shield.SetActive (true);

			}

			if (slot2 == 3) {

				itemSlot2.attackPoints.SetActive (true);

			}

			if (slot2 == 4) {

				itemSlot2.weaponBoost.SetActive (true);

			}

		}

		if (slot3 != 0) {
			itemSlot3.hasItem = true;


			if (slot3 == 1) {

				itemSlot3.repair.SetActive (true);

			}
			if (slot3 == 2) {

				itemSlot3.shield.SetActive (true);

			}

			if (slot3 == 3) {

				itemSlot3.attackPoints.SetActive (true);

			}

			if (slot3 == 4) {

				itemSlot3.weaponBoost.SetActive (true);

			}

		}

		if (slot4 != 0) {

			itemSlot4.hasItem = true;


			if (slot4 == 1) {

				itemSlot4.repair.SetActive (true);

			}
			if (slot4== 2) {

				itemSlot4.shield.SetActive (true);

			}

			if (slot4 == 3) {

				itemSlot4.attackPoints.SetActive (true);

			}

			if (slot4== 4) {

				itemSlot4.weaponBoost.SetActive (true);

			}

		}

	}



	public void InventoryOpen(){

		isOpen = !isOpen;

		inventoryPanel.SetActive (isOpen);

	}



	public void CheckAllSlotsForUse(){

			
		if (itemSlot1.hasItem == false) {
		
			PlayerPrefs.SetInt ("Slot1",0);

			Debug.Log ("Setting slot1 empty");
		

		}
		if (itemSlot2.hasItem == false) {

			PlayerPrefs.SetInt ("Slot2",0);

			Debug.Log ("Setting slot2 empty");
		
		}
		if (itemSlot3.hasItem == false) {
			PlayerPrefs.SetInt ("Slot3",0);

			Debug.Log ("Setting slot3 empty");


		}
		if (itemSlot4.hasItem == false) {

			PlayerPrefs.SetInt ("Slot4",0);

			Debug.Log ("Setting slot4 empty");
		}
	
	
	}



}
