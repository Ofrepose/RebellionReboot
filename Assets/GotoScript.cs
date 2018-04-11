using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoScript : MonoBehaviour {
	private AudioSource beep;

	void Start () {

		var aSource = GetComponents<AudioSource> ();

		beep = aSource [0];

	}

	void Update(){
	
		if (Input.GetMouseButtonDown (0) && Time.timeScale != 0) {
		
			beep.Play ();
				
		}
	
	}

}
