using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killOnScript : MonoBehaviour {

	FlyingAISc flyingAi;

	void Start(){
	
		flyingAi = FlyingAISc.FindObjectOfType<FlyingAISc> ();
	
	}


	void OnTriggerEnter(Collider col){

		if (flyingAi) {
		
			Debug.Log ("enteredCollider");

			Destroy (col.gameObject);

		
		}

		Destroy (col.gameObject);



	
	}
}
