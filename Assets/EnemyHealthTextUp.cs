using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthTextUp : MonoBehaviour {


	float timeToKill = 1.25f;
	float timer;

	Vector3 targetEnd;
	Vector3 beginPos;

	void Start(){
	
		beginPos = new Vector3 (0, 2.46f, -2.4f);

		targetEnd = new Vector3 (0, 6.21f, -2.4f);
	
	}

	void Update(){

		timer += Time.deltaTime;

		if (timer >= timeToKill) {
		
			Destroy (this.gameObject);
		
		} else {
		
			this.transform.position = Vector3.Lerp (beginPos,targetEnd,.1f);
		
		}



	}


}
