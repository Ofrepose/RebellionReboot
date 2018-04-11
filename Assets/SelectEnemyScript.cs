using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEnemyScript : MonoBehaviour {

	public static bool enemy1Selected = false;

	public GameObject selected;

	SelectEnemy2Script enemy2;

	public GameObject aimingReticle;

	public GameObject aimingReticleOther;





	void Start(){

		aimingReticle.SetActive (false);


		selected.SetActive (false);

		enemy2 = SelectEnemy2Script.FindObjectOfType<SelectEnemy2Script> ();

	}




	public void OnMouseOver(){

		if (enemy2 == null) {
		
			enemy2 = SelectEnemy2Script.FindObjectOfType<SelectEnemy2Script> ();

		
		}


		if (Input.GetMouseButtonDown (0) && !enemy1Selected) {
		
			enemy1Selected = true;

			selected.SetActive (true);

			aimingReticleOther.SetActive (false);

			aimingReticle.SetActive (true);
			enemy2.selected2.SetActive (false);
			SelectEnemy2Script.enemy2Selected = false;

			Debug.Log ("CLIIICKKKED");
		
		}


	}

}
