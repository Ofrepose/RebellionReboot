using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnamolyActivatedScript : MonoBehaviour {

	public Transform middleGlowParticles;

	public GameObject flashPoint;

	public GameObject blastTarget;

	//GameObject flashCreated;

	public bool velocityExtrapolate;

	bool zeroHorizon = false;

	float xMax = 14f;

	float voltDischarge;

	float enumeration = 15f;

	float attain;


	void Start () {

	}
	
	void Update () {

		attain += Time.deltaTime * 1f;

		if (attain > enumeration) {

			velocityExtrapolate = true;
		
			if (velocityExtrapolate) {

				if (middleGlowParticles.localScale.x < xMax) {

					middleGlowParticles.transform.localScale += new Vector3 (1, 1, 1) * Time.deltaTime * 2f;

				}

				if (middleGlowParticles.localScale.x >= xMax && !zeroHorizon) {

					GameObject flashCreated = Instantiate (flashPoint, transform.position, Quaternion.identity) as GameObject;

					//flashCreated.GetComponent<Rigidbody>().velocity = new Vector3 (blastTarget.transform.position.x, blastTarget.transform.position.y,blastTarget.transform.position.z);

					flashCreated.GetComponent<Rigidbody> ().velocity = (GameObject.Find ("defaultShipFORAmonily").transform.position - transform.position).normalized * 50f;					


					zeroHorizon = true;

				
				}

			

			}
		
		}






	}
}
