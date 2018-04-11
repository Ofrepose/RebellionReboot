using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASyncLoadScript : MonoBehaviour {


	AsyncOperation aSync;

	public string level;

	void Start(){
	
		StartCoroutine ("Load");
	
	}



	IEnumerator Load(){
	
		Debug.LogWarning ("ASYNC LOAD STARTED - " + "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS....");

		aSync = Application.LoadLevelAsync (level);

		aSync.allowSceneActivation = false;

		yield return aSync;
	
	}

	public void ActivateScene(){
	
		aSync.allowSceneActivation = true;
	
	}

}
