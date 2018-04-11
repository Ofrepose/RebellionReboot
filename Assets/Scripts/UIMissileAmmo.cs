using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMissileAmmo : MonoBehaviour
{
	//Time taken for each letter to appear (The lower it is, the faster each letter appear)
	public float letterPaused = 1f;
	//Message that will displays till the end that will come out letter by letter
	public string message;
	//Text for the message to display
	public Text textComp;
	PlayerController playercontroller;
	private float ammo2;
	
	// Use this for initialization
	void Start ()
	{	
		playercontroller = PlayerController.FindObjectOfType<PlayerController>();
		ammo2 = playercontroller.ammo;
		
		
	}
	
	void Update(){
		textComp.text= "X " + playercontroller.ammo;
		if (playercontroller.ammo < 0 ){
			textComp.text = "X 0";
		}
	}
	
	
	
}
