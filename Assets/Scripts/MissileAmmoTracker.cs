using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissileAmmoTracker : MonoBehaviour {
	public int missileTotal = 0;
	public Text myText;
	
	
	void Start () {
		myText = GetComponent<Text>();
	}
	
	public void TotalMissileAmmo(int ammois){
		Debug.Log ("Total missile ammo is " + ammois);
		missileTotal += ammois;
		myText.text = "x " + missileTotal;
	}
	
	public void Reset(){
		missileTotal = 0;
		myText.text = "x " + missileTotal;
	}
}
