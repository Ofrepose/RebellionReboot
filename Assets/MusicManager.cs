using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	


	private AudioSource song1;
	private AudioSource song2;
	private AudioSource song3;
	private int amountPlayed =0;

	void Awake(){
		
		DontDestroyOnLoad(this.gameObject);


		
	
		float volume = Options.GetMasterVolume ();
		ChangeVolume (volume);
	}

	void Start(){
		var aSource = GetComponents<AudioSource>();
		song1 = aSource[0];
		song2 = aSource[1];
		song3 = aSource [2];
		BackgroundMusic ();
		
	}


	public void ChangeVolume(float volume){
		
		//song1.volume= volume;
		//song2.volume= volume;
		//song3.volume= volume;



	}

	public void BackgroundMusic(){
		if (amountPlayed < 1) {
			song1.Play ();
			Debug.Log ("playing song 1");
			song1.volume = 0.2f;
			amountPlayed = 1;
			//Invoke ("BackgroundMusic", song1.clip.length);
		}

		if (amountPlayed == 1) {
			song2.Play ();
			Debug.Log ("playing song 2");
			amountPlayed = 2;
			Invoke ("BackgroundMusic", song2.clip.length);
		}
		if (amountPlayed == 2) {
			song3.Play ();
			Debug.Log ("playing song 3");
			amountPlayed = 0;
			Invoke ("BackgroundMusic", song3.clip.length);
		}

			
	}
}
