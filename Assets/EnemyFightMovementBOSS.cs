using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFightMovementBOSS : MonoBehaviour {
	float xMin;
	float xMax;
	float yMin = 0f;
	float yMax = 2f;
	float zMin = -19f;
	float zMax = 19f;
	float rzmin = -4f;
	float rzmax = 4f;
	float direction = 1;
	float directionVertical = 1;
	public float enemySpeed= 10f;
	public float smooth = 3f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Hover ();


	}


	void Hover(){
		if (transform.position.z >= zMax){
			//anime.SetTrigger("TurnToLeft");
			//Quaternion target = Quaternion.Euler(0,0, -4f);
			//transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			Quaternion target = Quaternion.Euler(9.65f,90f, rzmax);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			directionVertical = directionVertical * -1;
			print (directionVertical);
		}

		if (transform.position.z <= zMin){
			Quaternion target = Quaternion.Euler(9.65f,90, rzmin);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			directionVertical = directionVertical * -1;
		}






		if(directionVertical == -1){
			//Quaternion target = Quaternion.Euler(0,0, 4f);
			//transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			transform.position += Vector3.forward * enemySpeed * Time.deltaTime * directionVertical;

		}

		if (directionVertical == 1 ){
			//Quaternion target = Quaternion.Euler(0,0, 0);
			//transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			transform.position += Vector3.forward * enemySpeed * Time.deltaTime * directionVertical;
		}
		transform.position += Vector3.forward * enemySpeed * Time.deltaTime * directionVertical;
	}
}
