using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaserImpactSounds : MonoBehaviour {

	private AudioSource SoundForShield;
	private AudioSource SoundRegular;
	private AudioSource SoundRegular2;
	private AudioSource SoundRegular3;
	private AudioSource SoundForShield2;


	SingleFightScriptPlace singleFight;


	void Start(){

		var aSource = GetComponents<AudioSource> ();

		SoundForShield = aSource [0];
		SoundRegular = aSource [1];
		SoundRegular2 = aSource [2];
		SoundRegular3 = aSource [3];
		SoundForShield2 = aSource [4];


		singleFight = SingleFightScriptPlace.FindObjectOfType<SingleFightScriptPlace> ();

		if (singleFight != null) {
		
			if (RTSBattleController.shieldOn == true) {



				int whichOne = Random.Range (0, 2);

				Debug.Log ("which one is : " + whichOne);
			
				if (whichOne == 0) {
				
					SoundForShield.Play ();
				
				}

				if (whichOne == 1) {
				
				
				
				}



			
			}

			if (RTSBattleController.shieldOn == false) {

				int whichone = Random.Range (1, 4);
			
				SoundForShield.playOnAwake = false;

				aSource [whichone].Play ();

				//SoundRegular.playOnAwake = true;
			
			}
		
		}

		if (singleFight == null) {
		
			if (PlayerAttackScriptMultipleEnemies.shieldOn == true) {

				int whichOne = Random.Range (0, 2);

			

				if (whichOne == 0) {

					SoundForShield.Play ();

				}

				if (whichOne == 1) {



				}

			}

			if (PlayerAttackScriptMultipleEnemies.shieldOn == false) {

				SoundForShield.playOnAwake = false;

				//SoundRegular.playOnAwake = true;

				int whichone = Random.Range (1, 4);

				SoundForShield.playOnAwake = false;

				aSource [whichone].Play ();

			}
		
		}




	}


}
