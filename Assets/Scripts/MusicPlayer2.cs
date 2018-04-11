using UnityEngine;
using System.Collections;

public class MusicPlayer2 : MonoBehaviour {
	static MusicPlayer2 instance = null;
	int destructNumber;
	
	void Awake(){
		Debug.Log("Music player Awake " + GetInstanceID());	
		
		if (instance != null){
			int destructing=1;
			Destroy(gameObject);
			destructNumber = destructing + 1;
			
			print ("Audio instance self Destructing " + destructNumber );
			
		}
		else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		Debug.Log ("Music player Start " + GetInstanceID());	
	}
	

}
