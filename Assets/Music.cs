using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	static Music instance = null;

	public AudioClip[] clips;
	public AudioSource source;
	public float newclip;
	public float timer;
	public float timer2;

	LevelManager levelmanager;

	public static bool isFighting = false;




	void Start () {

		if (instance != null && instance != this) {
		
			Destroy (gameObject);
		
		} else {

			instance = this;
		
			Screen.sleepTimeout = SleepTimeout.NeverSleep;

			levelmanager = LevelManager.FindObjectOfType<LevelManager> ();
			DontDestroyOnLoad (this.gameObject);

			source = gameObject.AddComponent<AudioSource> ();
		
		}



	
		
	}
	
	void Update () {
		timer += Time.deltaTime;


		/*if (isFighting && timer2 >= newclip ) {
		
			BattleClip ();
			timer2 = 0;
		
		}*/


		if (timer >= newclip + 1 && !isFighting) {
			newCLIP ();
			timer = 0;
		}
	}

	public void newCLIP(){
		source.Stop ();
		int clipNum = Random.Range (0, 4);
		if (!source.isPlaying) {
			source.loop = true;
			source.volume = .5f;
			source.PlayOneShot (clips [clipNum]);
		}
		newclip = clips [clipNum].length;
	}

	public void BattleClip(){

		isFighting = true;

		source.Stop ();

		int clipNum = Random.Range (4, 7);

		if (!source.isPlaying) {
			source.loop = true;
			source.PlayOneShot (clips [clipNum]);
		}
		newclip = clips [clipNum].length;
	
	
	
	}
}
