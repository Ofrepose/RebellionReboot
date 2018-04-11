using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttackPanelDefault : MonoBehaviour {
	public Text pilotName;
	public Text shipType;
	

	// Use this for initialization
	void Start () {
	Text pilotName = GetComponent<Text>();
	Text shipType = GetComponent<Text>();
	
	UpdateDisplay();
	
	}
	
	void UpdateDisplay(){
		Debug.Log ("updatingdisplaynow");
		pilotName.text = "Captain: " + PlayerPrefs.GetString("PLAYER_NAME");
		shipType.text = "Null for now";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
