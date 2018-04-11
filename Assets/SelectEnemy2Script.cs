using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEnemy2Script : MonoBehaviour {

	public static bool enemy2Selected = false;

	public GameObject selected2;

	SelectEnemyScript enemy1;

	public GameObject aimingReticle;

	public GameObject aimingReticleOther;


	void Start(){

		aimingReticle.SetActive (false);


		selected2.SetActive (false);

		enemy1 = SelectEnemyScript.FindObjectOfType<SelectEnemyScript> ();

	}


	public void OnMouseOver(){

		if (enemy1 == null) {
		
			enemy1 = SelectEnemyScript.FindObjectOfType<SelectEnemyScript> ();

		
		}


		if (Input.GetMouseButtonDown (0) && !enemy2Selected) {

			aimingReticle.SetActive (true);


			aimingReticleOther.SetActive (false);

			enemy2Selected = true;
			selected2.SetActive (true);
			enemy1.selected.SetActive (false);
			SelectEnemyScript.enemy1Selected = false;


			Debug.Log ("CLIIICKKKED");

		}


	}
}
