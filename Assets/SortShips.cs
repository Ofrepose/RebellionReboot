using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SortShips : MonoBehaviour {
	public GameObject EASRESISTANCE;
	public GameObject EASSILVERHAWK;

	public GameObject ResistancePanel;
	public GameObject silverhawkPanel;

	bool thisone =  true;
	public static int ship1or2;
	
	//texts
	public Text ResistanceHull;
	public Text ResistanceSpeed;
	public Text ResistanceShipType;
	
	public Text SilverHawkHull;
	public Text SilverHawkSpeed;
	public Text SilverHawkShipType;

	void Start () {
		Text ResistanceHull = GetComponent<Text>();
		Text ResistanceSpeed = GetComponent<Text>();
		Text ResistanceShipType = GetComponent<Text>();
		
		Text SilverHawkHull = GetComponent<Text>();
		Text SilverHawkSpeed = GetComponent<Text>();
		Text SilverHawkShipType = GetComponent<Text>();
	}
	
	void Update () {
	
		if (thisone){
			ResistancePanel.SetActive (true);
			silverhawkPanel.SetActive (false);

			EASRESISTANCE.SetActive(true);
			EASSILVERHAWK.SetActive(false);
			Character.shipChoice = "RESISTANCE";
			ResistanceHull.text = "Ship Hull: Light";
			ResistanceSpeed.text = "Ship Speed: Medium";
			ResistanceShipType.text = "Ship Class: Diplomatic Guard";
			
		}
		if(!thisone){

			ResistancePanel.SetActive (false);
			silverhawkPanel.SetActive (true);

			EASRESISTANCE.SetActive(false);
			EASSILVERHAWK.SetActive(true);
			Character.shipChoice = "SILVERHAWK";
			SilverHawkHull.text = "Ship Hull: Medium";
			SilverHawkSpeed.text ="Ship Speed: Slow";
			SilverHawkShipType.text = "Ship Type: Mercenary Survivalist";
		}
	}
	
	public void NextOne(){
		thisone = !thisone;
	}
}
