using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSelectInSystem : MonoBehaviour {

	public GameObject InfoPanel;
	public GameObject panelPos;

	bool go = false;

	void Start(){


		InfoPanel = GameObject.FindGameObjectWithTag ("EnemyInfoPanel");



	}

	void OnMouseEnter(){

		InfoPanel.transform.rotation = Quaternion.Euler (0, 0, 0);

		Vector3 namePos = panelPos.transform.position;

		go = true;

		SelectShip ();
	}

	void OnMouseExit(){

		InfoPanel.transform.rotation = Quaternion.Euler (-90, 0, 0);

		go = false;
	
		DeSelect ();
	
	}


	public void SelectShip(){
		
			//selectship here

			Debug.Log ("WouldSelect ship now");	
	
	
	}

	public void DeSelect(){

		Debug.Log ("Deselected");


	}




	void Update(){



		if (InfoPanel == null) {
		
			InfoPanel = GameObject.FindGameObjectWithTag ("EnemyInfoPanel");

		
		}

		if (go) {
		
			Vector3 namePos = Camera.main.WorldToScreenPoint (panelPos.transform.position);
			InfoPanel.transform.position = namePos;
		
		}



	}

}
