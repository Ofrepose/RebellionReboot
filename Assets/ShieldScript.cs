using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldScript : MonoBehaviour {

	SingleFightScriptPlace singleFight;
	bool isThisSingleFight;

	//Enemy Projectiles
	EnemyBasicLaserScript enemyBasicLaser;
	RedRocketScript redRocketDamage;

	public Collider enemyLaserRed;
	public Collider enemyRedRocket;


	//Enemy Projectile Impact Animations
	public GameObject redLaserImpact;
	public GameObject redRocketImpact;


	//PlayerComponents
	float evade;


	//ShieldComponents
	public static float shieldHealth;
	public Image shieldBar;







	void Start(){

		shieldHealth = PlayerPrefs.GetFloat ("SHIELD_HEALTH");

		evade = PlayerPrefs.GetFloat ("Evade");

		//---------------------------------DETERMINE IF THIS IS A SINGLE FIGHT OR MULTI --------------------------------------
	
		singleFight = SingleFightScriptPlace.FindObjectOfType<SingleFightScriptPlace> ();

		if (singleFight == null) {
		
			isThisSingleFight = false;
		
		}

		if (singleFight != null) {
		
			isThisSingleFight = true;
		
		}

		//---------------------------------------------------------------------------------------------------------------------



	
	}

	void OnTriggerEnter(Collider col){



		Vector3 enemyImpactPos = col.transform.position;

		//enemyLaserRed = GetComponent<Collider> ();
		enemyBasicLaser = EnemyBasicLaserScript.FindObjectOfType<EnemyBasicLaserScript> ();

		//enemyRedRocket = GetComponent<Collider> ();
		redRocketDamage = RedRocketScript.FindObjectOfType<RedRocketScript> ();

		float chanceEnemyHit = Random.Range (1, 100);



		if (chanceEnemyHit > evade) {

			if (enemyLaserRed) {
			
				GameObject redLaserHit = Instantiate (redLaserImpact, enemyImpactPos, Quaternion.identity) as GameObject;

				Destroy (col.gameObject);

				shieldHealth = shieldHealth - enemyBasicLaser.damage;

				shieldBar.fillAmount = shieldHealth * PlayerPrefs.GetFloat ("SHIELD_MULTIPLY_BY");

			
			}
		
		
		
		}






	}



}
