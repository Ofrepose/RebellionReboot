 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
	public float autoLoadNextLevelAfter;
	string here;



	public void LoadLevelPause(string name){
	
		here = name;
		Invoke("LoadLevelContinued", 3f);
	
	}



	public void LoadLevel(string name){
	


		here = name;

		//Debug.Log ("this is working for " + name);
		LoadLevelContinued();
		
		
	}
	
	void Start(){
		if (autoLoadNextLevelAfter > 0){
			Invoke("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}
	
	public void QuitLevel(){
		//Debug.Log ("This is workng for " + name);
		Application.Quit();
	}
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
		
		
	}
	
	public void OnMouseDown(){
		if(Input.GetMouseButtonDown(0)){
			LoadLevel("GalaxyMap");
		}
	}

	public void LoadWhere(){

		LoadLevel (Character.where);

	}


	private void LoadLevelContinued(){


		Application.LoadLevel (here);


	}
	
}
	

