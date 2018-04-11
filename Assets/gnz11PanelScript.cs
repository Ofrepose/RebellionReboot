using UnityEngine;
using System.Collections;

public class gnz11PanelScript : MonoBehaviour {

	public GameObject childText;
	private LevelManager levelManager;
	WarpDrive warpDrive;

	void Start(){

		childText.SetActive(false);
		levelManager = LevelManager.FindObjectOfType<LevelManager> ();
		warpDrive = WarpDrive.FindObjectOfType<WarpDrive>();

	}

	//void OnMouseEnter(){
	//	childText.SetActive (true);

	//}

	void OnMouseOver(){
		childText.SetActive (true);



	}
	public void OnMouseExit(){
		childText.SetActive (false);
	}

	void OnMouseDown(){
		//Character.where = "GNZ11";
		levelManager.LoadLevel("GNz11");
	}
}
