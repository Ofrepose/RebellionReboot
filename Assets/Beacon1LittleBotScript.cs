using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon1LittleBotScript : MonoBehaviour {

	public GameObject engine;

	Animator botsAnimator;

	void Start(){
	
		botsAnimator = GetComponent<Animator> ();

		botsAnimator.SetBool ("Bot1Swarming", true);
	
	}

	public void AfterBurnerOn(){
	
		engine.SetActive (true);
	
	}


	public void AfterBurnerOff(){

		engine.SetActive (false);

	}
}
