using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Options : MonoBehaviour {
	public Slider volumeSlider;
	public LevelManager levelManager;
	//public Slider difficultySlider;

	private MusicManager musicManager;



	//					PLAYERPREFS MANAGER
	//------------------------------------------------------------------------------------------

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";



	//					VOLUME SETTINGS
	//------------------------------------------------------------------------------------------
	public static void SetMasterVolume(float volume){
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		}
	}


	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}





	//------------------------------------------------------------------------------------------

	void Start(){
		musicManager = GameObject.FindObjectOfType<MusicManager> ();

		volumeSlider.value = GetMasterVolume ();

	}


	void Update(){
		musicManager.ChangeVolume (volumeSlider.value);
	}


	//saves and exits
	public void SaveAndExit(){
		SetMasterVolume (volumeSlider.value);
		levelManager.LoadLevel ("Start");
	}



}