using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WarpDrive : MonoBehaviour {
	//public GameObject NGC1300;
	/*
	private LevelManager levelManager;
	public ShipComputer shipComputer;
	public GameObject background;
	public GameObject warpField;
	private Animator anime;
	 static bool hasCoordinates;

	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad (this.gameObject);
	Debug.Log("where is equal to " + where);
	levelManager = LevelManager.FindObjectOfType<LevelManager>();
	shipComputer = ShipComputer.FindObjectOfType<ShipComputer>();
	warpField.SetActive(false);
	background.SetActive(true);
	anime = Animator.FindObjectOfType<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void WarpHere(){
		if(string.IsNullOrEmpty(where)){
			shipComputer.NoFTLPosition();
			//break;
		}
		else {
			hasCoordinates = false;	
			background.SetActive(false);
			warpField.SetActive(true);
			anime.SetBool("hasLocation",hasCoordinates);
			anime.SetTrigger("isWarping");
			Invoke ("Go",10);
		}
	
	}
	
	public void Go(){
		PlayerPrefs.SetString ("PLAYER_LOCATION", where);
		levelManager.LoadLevel(where);
	
	}
	public void PlotNGC1300(){
		if (PlayerPrefs.GetString ("PLAYER_LOCATION") == "NGC1300") {
			levelManager.LoadLevel ("NGC1300");
		} else {
			hasCoordinates = true;
			anime.SetBool("hasLocation",hasCoordinates);
			where = "NGC1300";
			levelManager.LoadLevel("WarpDrive");
		}
		

	}

	public void PlotGNZ11(){
		if (PlayerPrefs.GetString ("PLAYER_LOCATION") == "GNZ11") {
			levelManager.LoadLevel ("GNZ11");
		} else {
			hasCoordinates = true;
			anime.SetBool("hasLocation",hasCoordinates);
				where = "GNZ11";
			levelManager.LoadLevel("WarpDrive");
		}
	} */
	
}
