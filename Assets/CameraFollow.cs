using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Camera mainCamera;
	//public Camera sideCamera;
	public Transform player;

	public static bool enemyBehind;


	// Use this for initialization
	void Start () { 
		enemyBehind = true;

		
	}
	
	// Update is called once per frame
	void Update () {
		if (!enemyBehind) {
			//sideCamera.enabled = false;
			mainCamera.enabled = true;

			Quaternion target = Quaternion.Euler (25.303f, 0.619f, 0);
			mainCamera.transform.rotation = target;
		}
		if (enemyBehind) {
			//sideCamera.enabled = true;
			mainCamera.enabled = false;
			Quaternion target = Quaternion.Euler(51.482f, -97.811f, -1.405f);
			//sideCamera.transform.rotation = target;



		}
			}
}
