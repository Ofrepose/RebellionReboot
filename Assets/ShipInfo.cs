using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipInfo : MonoBehaviour {

	//public Text shipName;
	public Text shipCaptain;
	public Text shipDamage;
	public Text shipCredits;
	public Text captainLevel;
	
	PlayerHealth shipdamage;
	Character captinname;
	Character captainlevel;
	
	

	void Start () {
		//Text shipName = GetComponent<Text>();
		Text shipCaptin = GetComponent<Text>();
		Text shipDamage = GetComponent<Text>();
		Text shipCredits = GetComponent<Text>();
		Text captainLevel = GetComponent<Text>();
		shipdamage = PlayerHealth.FindObjectOfType<PlayerHealth>();
		captinname = Character.FindObjectOfType<Character>();
		captainlevel = Character.FindObjectOfType<Character>();
		UpdateDisplay();
		
	
	}
	
	void UpdateDisplay(){
	
		shipCaptain.text = "Captain: " + Character.playerName.ToString();
		shipDamage.text = "Hull Condition: " + PlayerHealth.playerHealth.ToString() + "%";
		captainLevel.text = "XP: " + Character.XP.ToString();
		
	}
	
	void Update () {
	
	}
}
