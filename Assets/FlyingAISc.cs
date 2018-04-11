using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAISc : MonoBehaviour {

	public GameObject playerShip;

	public Transform target;

	GameObject playershipJumped;

	public float speed;

	void Start () {

		//Vector3 startPosition1 = new Vector3 (28f, -1f, 51f);

		//playershipJumped = Instantiate( playerShip, startPosition1, Quaternion.identity) as GameObject;

		//Vector3 starBasePos = new Vector3 (enemyShip.position.x + 5f, enemyShip.position.y + 5f, enemyShip.position.z + 5f);




	}

	void Update () {

		playerShip.transform.LookAt (target);

		playerShip.transform.position = Vector3.Lerp (playerShip.transform.position, target.position, Time.deltaTime * speed);



	}
}
