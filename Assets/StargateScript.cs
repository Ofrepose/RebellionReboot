using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StargateScript : MonoBehaviour {
	//public Text Dialog;

	private AudioSource RequestAccepted;
	private AudioSource notEnoughCredits;
	private AudioSource purchaseSuccesful;
	private AudioSource unacceptableParameters;
	private AudioSource upgradeSuccessful;
	private AudioSource uplinkSuccessful;
	
	
	//PANELS
	
	public GameObject pricePanel;
	public GameObject WeaponsPreviewPanel;
	public GameObject MainPanel;
	
	//Texts
	public Text WeaponName;	
	public Text WeaponDescription;
	public Text WeaponPriceText;
	public Text shipHealth;
	
	public Text repairPriceText;
	


	public Text creditAmount;
	int credits;

	//PRICES

	public int repairCost;




	//Weapons
	public GameObject[] WeaponsArray;
	public int[] weaponsRandom = {1,2};
	int[] weaponPrice = {500, 550};
	
	int randomWeaponChoice;


	
	
	//public GameObject weaponPricePanel;
	

	void Start () {
		
		randomWeaponChoice = Random.Range(1, 3);
		Text WeaponName = GetComponent<Text>();
		Text WeaponDescription = GetComponent<Text>();
		Text creditAmount = GetComponent<Text>();
		Text shipHealth = GetComponent<Text>();
	
		Text WeaponPriceText = GetComponent<Text>();
		WeaponsPreviewPanel.SetActive(false);
		//weaponName.text = "Plasma Laser Upgrade";
		
		
		Text repairPriceText = GetComponent<Text> ();
		pricePanel.SetActive (false);
		//weaponPricePanel.SetActive(false);
		credits = PlayerPrefs.GetInt ("PLAYER_CREDITS");
		Debug.Log("Player credits is " + credits);
		repairCost = (PlayerPrefs.GetInt("PLAYER_STARTING_HEALTH",200) - PlayerPrefs.GetInt("PLAYER_HEALTH"))  * 1;


		var aSource = GetComponents<AudioSource>();

		RequestAccepted = aSource [0];
		notEnoughCredits = aSource [1];
		purchaseSuccesful = aSource [2];
		unacceptableParameters = aSource [3];
		upgradeSuccessful = aSource [4];
		uplinkSuccessful = aSource [5];
		Debug.Log("Random weapon choice is equal to " + randomWeaponChoice);
		//if (randomWeaponChoice == 1 ){
		
		//}
		UpdateScreen();
	
		


		
	}
	
	void Update () {
	}


	public void RepairShip(){
		if (PlayerPrefs.GetInt ("PLAYER_HEALTH") == PlayerPrefs.GetInt ("PLAYER_STARTING_HEALTH")) {
			unacceptableParameters.Play ();
			
		}
		if (PlayerPrefs.GetInt ("PLAYER_HEALTH") != PlayerPrefs.GetInt ("PLAYER_STARTING_HEALTH")) {
			Debug.Log ("player health is " + PlayerPrefs.GetInt ("PLAYER_HEALTH"));
			pricePanel.SetActive (true);
			repairPriceText.text = "Repair your ship for " + repairCost + " credits?";
			




		}
			
	}
	public void RepairShipOK(){
		
		if (credits < repairCost) {
			notEnoughCredits.Play ();
		}
		if (credits >= repairCost) {
			purchaseSuccesful.Play ();
			PlayerPrefs.SetInt ("PLAYER_CREDITS", PlayerPrefs.GetInt ("PLAYER_CREDITS") - repairCost);
			PlayerPrefs.SetInt ("PLAYER_HEALTH", PlayerPrefs.GetInt ("PLAYER_STARTING_HEALTH"));
			UpdateScreen();
			pricePanel.SetActive (false);


		}
	}

	public void RepairShipCANCEL(){
		pricePanel.SetActive (false);
	}
	
	void UpdateScreen(){
		creditAmount.text = "Credits: " + PlayerPrefs.GetInt ("PLAYER_CREDITS").ToString();
		shipHealth.text = "Ship Hull: " + PlayerPrefs.GetInt("PLAYER_HEALTH").ToString();
		
	}
	
	
	
	//---------------------WEAPONS UPGRADES----------------------------------------------------------------------------------------------------------------------------------
	
	public void WeaponsButton(){
		WeaponsPreviewPanel.SetActive(true);
		pricePanel.SetActive (false);
		MainPanel.SetActive(false);
		if (randomWeaponChoice == 1){
			WeaponPriceText.text = weaponPrice[0].ToString() + " credits";
			WeaponName.text = "Plasma Pulse Rifle";
			WeaponDescription.text = "Charged particle beams can take out a ship through Bremsstrahlug, or 'breaking radiation'. Simply put, run you particles up to about a gigaelectronvolt (GeV) " + 
									"per nucleon, fire at your target, apply a couple of megajoules per square meter, and watch everything inside the target die. And die they will. Not just people, but " + 
									"electronics that arent heavily shielded will fry as well, since at 1 GeV the particles are acting like primary cosmic rays.";
			
			GameObject weapon = WeaponsArray[0];
			Vector3 newPos = new Vector3(58.83f,  1.625f, 21.815f);
			Quaternion zero = Quaternion.Euler(0,0,0);
			GameObject WeaponChoice = Instantiate(weapon, newPos, zero) as GameObject;
			//WeaponChoice.transform.parent = WeaponsPreviewPanel.transform;
			
			//WeaponChoice.SetActive(false);
			
		}



		if (randomWeaponChoice == 2){
			WeaponPriceText.text = weaponPrice[0].ToString() + " credits";
			WeaponName.text = "Electic Bolt Cannon";
			WeaponDescription.text = "This Electric orb propels a self-contained ball of electricity that damages targeting systems and damages the ships integrity. While it does little damage it prohibits enemy ships from accuratly firing projectiles.";

			GameObject weapon = WeaponsArray[1];
			Vector3 newPos = new Vector3(58.83f, 1.625f, 21.815f);
			Quaternion zero = Quaternion.Euler(0,0,0);
			GameObject WeaponChoice = Instantiate(weapon, newPos, zero) as GameObject;
			//WeaponChoice.transform.parent = WeaponsPreviewPanel.transform;

			//WeaponChoice.SetActive(false);

		}
		
	}
	
	public void WeaponsPreviewButtonClose(){
		WeaponsPreviewPanel.SetActive(false);
		MainPanel.SetActive(true);
		Destroy (GameObject.FindGameObjectWithTag ("Weapon"));
		
	}
	
	/*public void WeaponUpgrade(){
		if ((randomWeaponChoice == 1 && PlayerPrefs.GetInt("PlasmaLaserOnResistance") == 1) {
			unacceptableParameters.Play ();
			
		}
		if ((randomWeaponChoice == 1 && PlayerPrefs.GetInt("PlasmaLaserOnResistance") == 0) {
			
			weaponPricePanel.SetActive (true);
			pricePanel.SetActive(false);
			WeaponPriceText.text = "Purcahase Weapon upgrade for " + weaponPrice[0] + " credits?";
		}

	if ((randomWeaponChoice == 2 && PlayerPrefs.GetInt("ElectricBoltCannon") == 1) {
			unacceptableParameters.Play ();
			
		}
		if ((randomWeaponChoice == 2 && PlayerPrefs.GetInt("ElectricBoltCannon") == 0) {
			
			weaponPricePanel.SetActive (true);
			pricePanel.SetActive(false);
			WeaponPriceText.text = "Purcahase Weapon upgrade for " + weaponPrice[1] + " credits?";
		}
	}*/
	
	public void WeaponUpgradeOK(){
	
		if (randomWeaponChoice == 1 && PlayerPrefs.GetInt("PlasmaLaserOnResistance") == 1) {
			unacceptableParameters.Play ();
			
		}

		if (randomWeaponChoice == 2 && PlayerPrefs.GetInt("ElectricBoltCannon") == 1) {
			unacceptableParameters.Play ();

		}
		if ( randomWeaponChoice == 1 && weaponPrice[0] > credits && PlayerPrefs.GetInt("PlasmaLaserOnResistance") == 0){
			notEnoughCredits.Play();
		}
		if (randomWeaponChoice == 1  && weaponPrice[0] <= credits && PlayerPrefs.GetInt("PlasmaLaserOnResistance") == 0){
			purchaseSuccesful.Play ();
			PlayerPrefs.SetInt("PlasmaLaserOnResistance",1);
			Debug.Log("Credits before purchase " +  PlayerPrefs.GetInt ("PLAYER_CREDITS"));
			PlayerPrefs.SetInt ("PLAYER_CREDITS", PlayerPrefs.GetInt ("PLAYER_CREDITS") - weaponPrice[0]);
			Debug.Log("Credits after purchase " +  PlayerPrefs.GetInt ("PLAYER_CREDITS"));
			if (PlayerPrefs.GetInt ("ElectricBoltCannon") == 1) {
			
				PlayerPrefs.SetInt ("ElectricBoltCannon", 0);
			
			}

			UpdateScreen();
		}

		if ( randomWeaponChoice == 2 && weaponPrice[1] > credits && PlayerPrefs.GetInt("ElectricBoltCannon") == 0){
			notEnoughCredits.Play();
		}
		if (randomWeaponChoice == 2  && weaponPrice[1] <= credits && PlayerPrefs.GetInt("ElectricBoltCannon") == 0){
			purchaseSuccesful.Play ();
			PlayerPrefs.SetInt("ElectricBoltCannon",1);
			Debug.Log("Credits before purchase " +  PlayerPrefs.GetInt ("PLAYER_CREDITS"));
			PlayerPrefs.SetInt ("PLAYER_CREDITS", PlayerPrefs.GetInt ("PLAYER_CREDITS") - weaponPrice[1]);
			Debug.Log("Credits after purchase " +  PlayerPrefs.GetInt ("PLAYER_CREDITS"));
			if (PlayerPrefs.GetInt ("PlasmaLaserOnResistance") == 1) {

				PlayerPrefs.SetInt ("PlasmaLaserOnResistance", 0);

			}

			UpdateScreen();
		}
	}
	
}
