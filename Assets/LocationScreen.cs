using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocationScreen : MonoBehaviour {
	public Text locationScreen;

	// Use this for initialization
	void Start () {
		Text locationScreen = GetComponent<Text> ();
		UpdateLocationScreen ();
	
	}
	public void UpdateLocationScreen(){
		locationScreen.text = "Location: " + PlayerPrefs.GetString ("PLAYER_LOCATION");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
