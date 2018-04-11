using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarbaseFlyingScript : MonoBehaviour {

	public GameObject playerShip;

	public Transform starbase;

	GameObject playershipJumped;

	public float playerSpeed = 0.2f;

	void Start () {

		Vector3 startPosition1 = new Vector3 (28f, -5f, 51f);

		playershipJumped = Instantiate( playerShip, startPosition1, Quaternion.identity) as GameObject;

		//Vector3 starBasePos = new Vector3 (enemyShip.position.x + 5f, enemyShip.position.y + 5f, enemyShip.position.z + 5f);




	}
	
	void Update () {

		playershipJumped.transform.LookAt (starbase);

		playershipJumped.transform.position = Vector3.Lerp (playershipJumped.transform.position, starbase.position, Time.deltaTime * playerSpeed);



	}
}
