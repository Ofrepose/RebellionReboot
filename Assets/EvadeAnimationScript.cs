using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeAnimationScript : MonoBehaviour {


	public GameObject leftWingAir;

	public GameObject rightWingAir;



	public void LeftWingAirOn(){

		leftWingAir.SetActive (true);

	}

	public void LeftWingAirOff(){

		leftWingAir.SetActive (false);

	}

	public void RightWingAirOn(){

		rightWingAir.SetActive (true);

	}

	public void RightWingAirOff(){

		rightWingAir.SetActive (false);
	}
}
