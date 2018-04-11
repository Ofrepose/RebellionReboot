using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOTBATTLEPLAYERACTIONSSCRIPT : MonoBehaviour {

	public GameObject basicLaser;

	Transform AIShip;

	public Transform playerFirePos;


	public Transform playerFirePos2;

	public GameObject Laser1;

	public GameObject Laser2;


	public GameObject player;



	void Start () {
		
		
	}
	
	/*void Update () {
		if (AIShip == null) {
		
			AIShip = GameObject.FindGameObjectWithTag ("AI").GetComponent<Transform> ();

			Debug.Log ("AISHIP is " + AIShip);
		
		}

		
	}*/


	public void FireAtAI(){
	
		//Vector3 firePos = new Vector3 (playerFirePos.position);

		AIShip = GameObject.FindGameObjectWithTag ("AI").GetComponent<Transform>();


		Debug.Log ("transform of laser2 is " + Laser2.transform.position);
		Debug.Log ("transform of laser1 is " + Laser1.transform.position);





		GameObject playerLaser = Instantiate (basicLaser, Laser1.transform.position, Quaternion.Euler(new Vector3 (0, -85.82f, 0))) as GameObject;
		//playerLaser.transform.parent = this.gameObject.transform;

		playerLaser.GetComponent<Rigidbody> ().velocity = (GameObject.Find ("BEACONOBJECT0").transform.position - transform.position).normalized * 100f;   //new Vector3 (AIShip.transform.position.x, AIShip.transform.position.y, AIShip.transform.position.z);

		//playerLaser.transform.LookAt (GameObject.Find("BEACONOBJECT0").GetComponent<Transform>());


		//playerLaser.GetComponent<Rigidbody> ().velocity.y = 0;





		Vector3 fixedFirePos = new Vector3 (18f, -2.4f, 38.8f);

		GameObject playerLaser2 = Instantiate (basicLaser,fixedFirePos, Quaternion.Euler(new Vector3 (0, 129f, 0))) as GameObject;

		//playerLaser2.transform.parent = this.transform;

		playerLaser2.GetComponent<Rigidbody> ().velocity = (GameObject.Find ("BEACONOBJECT0").transform.position - Laser1.transform.position).normalized * 100f;   //new Vector3 (AIShip.transform.position.x, AIShip.transform.position.y, AIShip.transform.position.z);
			
	
	}
}
