using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowEasyScript : MonoBehaviour {

	public Transform targetToFollow;

	public GameObject camera;

	public float DistanceAway;

	public float HeightAbove;

	public float Vertical;

	//this is just for this particular use. comment out in default uses

	GameObject playerIsActive;

	void Start () {





	}
	
	void Update () {

		playerIsActive = GameObject.FindGameObjectWithTag ("Player");

		if (playerIsActive != null) {
			Debug.Log (" in if " + playerIsActive);

		
			Vector3 CameraPos = new Vector3 (playerIsActive.transform.position.x + Vertical, playerIsActive.transform.position.y + HeightAbove, playerIsActive.transform.position.z + DistanceAway);

			camera.transform.position = CameraPos;

		
		}





		
	}
}
