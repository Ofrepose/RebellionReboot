using UnityEngine;
using System.Collections;

public class ENEMYSELECTORFORBATTLE : MonoBehaviour {
	public GameObject ShipLarge;
	public GameObject ShipSmallGrayDefault;
	public GameObject NGC1300Boss;
	public GameObject QuantumEnemyDefault;

	public GameObject Pirate1;

	public GameObject Pirate2;
	
	public static string WhosAttacking;
	
	
	void Start () {
		
		Debug.Log("Whos attecking is " + PlayerPrefs.GetString ("WHOS_ATTACKING"));
		
		if( PlayerPrefs.GetString ("WHOS_ATTACKING") == "ShipLarge"){
			ShipLarge.SetActive(true);
			ShipSmallGrayDefault.SetActive(false);
			NGC1300Boss.SetActive (false);
			QuantumEnemyDefault.SetActive(false);
			Pirate1.SetActive (false);
			Pirate2.SetActive (false);

			
		}
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "ShipSmallGreyDefault"){
			Debug.Log ("Should be active shipsmallgrey");
			ShipSmallGrayDefault.SetActive(true);
			ShipLarge.SetActive(false);
			NGC1300Boss.SetActive (false);
			QuantumEnemyDefault.SetActive(false);
			Pirate1.SetActive (false);
			Pirate2.SetActive (false);
			
		}
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "NGC1300BOSS"){
			Debug.Log ("Should be active boss");
			ShipSmallGrayDefault.SetActive(false);
			ShipLarge.SetActive(false);
			QuantumEnemyDefault.SetActive(false);
			NGC1300Boss.SetActive (true);
			Pirate1.SetActive (false);
			Pirate2.SetActive (false);
		}
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "QuantumDefault"){
			ShipSmallGrayDefault.SetActive(false);
			ShipLarge.SetActive(false);
			NGC1300Boss.SetActive (false);
			QuantumEnemyDefault.SetActive(true);
			Pirate1.SetActive (false);
			Pirate2.SetActive (false);
		}		
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "TWOPIRATES"){
			ShipSmallGrayDefault.SetActive(false);
			ShipLarge.SetActive(false);
			NGC1300Boss.SetActive (false);
			QuantumEnemyDefault.SetActive(false);
			Pirate1.SetActive (true);
			Pirate2.SetActive (true);
		}

	
	}
	
	void Update () {
	
	}
}
