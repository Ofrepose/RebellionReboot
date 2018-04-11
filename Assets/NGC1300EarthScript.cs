using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGC1300EarthScript : MonoBehaviour {

	public GameObject earthMainPanel;

	public GameObject mainCanvas;

	public Camera mainCamera;

	Vector3 cameraZoom = new Vector3 (-22f, 34.5f, -13.5f);

	Vector3 cameraDefault = new Vector3 (-0.31f, 56f, -0.5f);

	GameObject player;

	bool go = false;

	bool goBack = false;



	void Start(){

		earthMainPanel.SetActive (false);


	}



	public void OnMouseDown(){

		if (PlayerPrefs.GetString ("NGC1300_FACTION_CONTROL") == "REBELLION") {
		
			mainCanvas.SetActive (false);

			player = GameObject.FindGameObjectWithTag ("Player");

			player.SetActive (false);

			earthMainPanel.SetActive (true);

			go = true;

			Debug.Log ("Has Clicked on Earth");
		
		}


		//Time.timeScale = 0;

	

	}

	public void exitEarthMainPanel(){
	
		//Time.timeScale = 1f;

		//player = GameObject.FindGameObjectWithTag ("Player");

		player.SetActive (true);

		goBack = true;

		earthMainPanel.SetActive (false);

		mainCanvas.SetActive (false);

	
	}


	void Update(){
	
		float aimAmount = 10f;

		if (mainCamera.orthographicSize > aimAmount && go)  {

			mainCamera.orthographicSize -= Time.deltaTime * 10f;

			mainCamera.transform.position = Vector3.Slerp (mainCamera.transform.position, cameraZoom, Time.deltaTime * 10f);
								
		}

		if (mainCamera.orthographicSize <= aimAmount && go) {
		
			go = false;
			Debug.Log("go is false");
			//Time.timeScale = 0f;
		
		}

		//---------------------------ZOOM BACK OUT HERE--------------------------

		float aimBackAmount = 35f;

		if (mainCamera.orthographicSize < aimBackAmount && goBack)  {

			mainCamera.orthographicSize += Time.deltaTime * 10f;

			mainCamera.transform.position = Vector3.Slerp (mainCamera.transform.position, cameraDefault, Time.deltaTime * 5f);

		}

		if (mainCamera.orthographicSize >= aimBackAmount && goBack) {
		
			goBack = false;

		
		}

	
	
	}
}
