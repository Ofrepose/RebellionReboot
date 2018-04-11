using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon1LittleBot2Script : MonoBehaviour {

	public GameObject engine;

	Animator botsAnimator;

	void Start(){

		botsAnimator = GetComponent<Animator> ();

		botsAnimator.SetBool ("Bot2Swarming", true);

	}

	public void AfterBurnerOn(){

		engine.SetActive (true);

	}


	public void AfterBurnerOff(){

		engine.SetActive (false);

	}
}
