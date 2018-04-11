using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ShipComputer : MonoBehaviour {
	public Text errorMessage;
	public GameObject ErrorMessageShip;

	void Start () {
	Text errorMessage = GetComponent<Text>();
	ErrorMessageShip.SetActive(false);
	
	
	}
	
	public void NoFTLPosition(){
		ErrorMessageShip.SetActive(true);
		errorMessage.text = "<Warning.. No Coordinates in System>";
		Invoke  ("waitToRemove", 5);
	}
	
	public void waitToRemove(){
		ErrorMessageShip.SetActive(false);
	}
	
	void Update () {
	
	}
}
