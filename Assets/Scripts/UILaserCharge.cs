using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UILaserCharge : MonoBehaviour {
	public string message;
	//Text for the message to display
	public Text textComp;
	PlayerController laserCharge;
	
	
	// Use this for initialization
	void Start () {
		laserCharge = PlayerController.FindObjectOfType<PlayerController>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		//round float to int so the decimals arent shown on gui
		int mylaserasint = Mathf.RoundToInt(laserCharge.laserCharge);
		textComp.text= mylaserasint  + " %";
		
	}
}