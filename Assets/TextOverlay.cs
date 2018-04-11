using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextOverlay : MonoBehaviour {
	public GameObject childText;
	private LevelManager levelManager;
	public GameObject hereNGC1300;
	public GameObject HighLightOnHover;


	public GameObject hereGNZ;

	
	
	void Start(){
		
			childText.SetActive(false);
		levelManager = LevelManager.FindObjectOfType<LevelManager> ();
		HighLightOnHover.SetActive (false);

		Debug.Log (PlayerPrefs.GetString ("PLAYER_LOCATION"));


		if (PlayerPrefs.GetString ("PLAYER_LOCATION") == "NGC1300") {
		
			hereNGC1300.SetActive (true);
			hereGNZ.SetActive (false);
		
		}
		if (PlayerPrefs.GetString ("PLAYER_LOCATION") == "GNZ11") {

			hereNGC1300.SetActive (false);
			hereGNZ.SetActive (true);

		}
		if (PlayerPrefs.GetString ("PLAYER_LOCATION") == "Null") {
		
			hereNGC1300.SetActive (false);
			hereGNZ.SetActive (false);
		
		}

		
	}

	//void OnMouseEnter(){
	//	childText.SetActive (true);
		
	//}

	void OnMouseOver(){
		childText.SetActive (true);
		HighLightOnHover.SetActive (true);


	
	}
	public void OnMouseExit(){
		childText.SetActive (false);
		HighLightOnHover.SetActive (false);
	}

	void OnMouseDown(){
		levelManager.LoadLevel("NGC1300");
	}
	
	//---------------------------------------------------NGC1300-----------------------------------------------------------------------
	public void NGC1300GalaxyON(){
		childText.SetActive (true);
		HighLightOnHover.SetActive (true);

	}
	
	public void NGC1300GalaxyOFF(){
		childText.SetActive (false);
		HighLightOnHover.SetActive (false);

	}
	
	public void LoadThisLevelNGC1300(){

		Character.where = "NGC1300";
		PlayerPrefs.SetString ("PLAYER_LOCATION", Character.where);
		levelManager.LoadLevel("NGC1300");
	}
	
	
	
	
	
	//---------------------------------------------------GNZ11-----------------------------------------------------------------------
	
	public void GNZ11GalaxyON(){
		childText.SetActive (true);
		HighLightOnHover.SetActive (true);

	}
	
	public void GNZ11GalaxyOFF(){
		childText.SetActive (false);
		HighLightOnHover.SetActive (false);

	}
	
	public void LoadThisLevelGNZ11(){

		if (PlayerPrefs.GetString ("NGC1300_FACTION_CONTROL") == "REBELLION") {

			Character.where = "GNZ11";
			PlayerPrefs.SetString ("PLAYER_LOCATION", Character.where);
		
			levelManager.LoadLevel("GNZ11");

		
		}
			

	}
	
}
