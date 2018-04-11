using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoEnemiesAttackingScript : MonoBehaviour {

	//SHIPS
	public GameObject PlayerShip;
	public GameObject thisShip;

	public Transform playerShipTarget;

	public float playershipPositionY;
	public float playershipPositionZ;


	//PLAYER WEAPONS
	BasicLaserScript basicLaserDamage;
	bluePlasmaLaser bluePlasmaDamage;
	ElectricBoltScript electricBoltDamage;
	ShieldDeflectorEnergyBackScript shieldDeflectorEnergyDamage;


	//THIS AI WEAPONS
	public GameObject Weapon1;
	public GameObject Weapon2;

	public GameObject enemyProjectile1;
	public GameObject enemyProjectile2;


	//AI COMPONENTS
	public float EnemyHealth = 100f;
	public float projectileSpeed = -20f;
	public float shotsPerSeconds = 0.01f;
	public float enemyattackpoints = 100f;

	public bool thisAiDead = false;


	//PLAYER COMPONENTS
	PlayerAttackScriptMultipleEnemies playerController;
	XP xp;

	float playerAccuracy;
	float deflectorDamage;


	//OTHER SCRIPTS
	LevelManager levelmanager;
	BattleControllerTurnBasedMultipleScript battlecontroller;


	//EFFECTS COMPONENTS
	public GameObject smoke;
	public GameObject bigExplosion;
	public GameObject DeadExplosion;
	public GameObject lotSmoke;

	public GameObject ShieldDeflectImpact;
	public GameObject BlueLaserImpact;
	public GameObject PlasmaLaserImpact;
	public GameObject ElectricBoltImpact;


	//MULTIPLE ENEMIES COMPONENTS
	public static int numberOfAttackers = 2;





	void Start () {

		transform.LookAt (PlayerShip.transform.position);


		playerShipTarget = PlayerShip.GetComponent<Transform> ();

		playerAccuracy = PlayerPrefs.GetFloat("GUNNER") + 50f;

		deflectorDamage = PlayerPrefs.GetFloat("DEFLECTORS");

		levelmanager = LevelManager.FindObjectOfType<LevelManager>();

		battlecontroller = BattleControllerTurnBasedMultipleScript.FindObjectOfType<BattleControllerTurnBasedMultipleScript>();

		playerController = PlayerAttackScriptMultipleEnemies.FindObjectOfType<PlayerAttackScriptMultipleEnemies>();

		xp = XP.FindObjectOfType<XP> ();
		
	}



	void OnTriggerEnter(Collider collider){



		bluePlasmaDamage = bluePlasmaLaser.FindObjectOfType<bluePlasmaLaser>();
		bluePlasmaLaser plasma = collider.gameObject.GetComponent<bluePlasmaLaser>();

		basicLaserDamage = BasicLaserScript.FindObjectOfType<BasicLaserScript>();
		BasicLaserScript laser = collider.gameObject.GetComponent<BasicLaserScript>();

		shieldDeflectorEnergyDamage = ShieldDeflectorEnergyBackScript.FindObjectOfType<ShieldDeflectorEnergyBackScript>();
		ShieldDeflectorEnergyBackScript shieldDeflectEnergy = collider.gameObject.GetComponent<ShieldDeflectorEnergyBackScript>();

		electricBoltDamage = ElectricBoltScript.FindObjectOfType<ElectricBoltScript> ();
		ElectricBoltScript electricBolt = collider.gameObject.GetComponent<ElectricBoltScript> ();



		Vector3 playerHitPos = collider.transform.position;

		float chanceEnemyHit = Random.Range(1,100);



		if (shieldDeflectEnergy && chanceEnemyHit < playerAccuracy){


			Destroy (collider.gameObject);
			GameObject deflectenergyimpact= Instantiate(ShieldDeflectImpact, playerHitPos, Quaternion.identity) as GameObject;

			//xp.GainXP(10);
			//smoke.SetActive(true);
			EnemyHealth = EnemyHealth - shieldDeflectorEnergyDamage.damage * deflectorDamage;
			Debug.Log("Enemy health is " + EnemyHealth);
			//battlecontroller.enemyText.text = "Health: " + EnemyHealth;

			//SMOKE GRAPHICS
			if (EnemyHealth == 80){
				Vector3 startPostion = transform.position + new Vector3 (2,2,0);
				GameObject smokeHit= Instantiate(smoke, startPostion, Quaternion.identity) as GameObject;
			}

			if (EnemyHealth == 60){
				Vector3 startPostion = transform.position + new Vector3 (0,0,0);
				GameObject bigExplosi= Instantiate(bigExplosion, startPostion, Quaternion.identity) as GameObject;
			}	


			if (EnemyHealth < 20){
				Vector3 startPostion = transform.position + new Vector3 (0,-.38f,0.47f);
				GameObject smokeLot= Instantiate(lotSmoke, startPostion, Quaternion.identity) as GameObject;
				smokeLot.transform.parent = gameObject.transform;
			}


		}


		if (plasma && chanceEnemyHit < playerAccuracy){
			Debug.Log("EnemyShip hit by plasma");

			Destroy (collider.gameObject);
			//PLASMA IMPACT
			GameObject plas= Instantiate(PlasmaLaserImpact, playerHitPos, Quaternion.identity) as GameObject;

			//xp.GainXP(10);
			//smoke.SetActive(true);
			EnemyHealth = EnemyHealth - bluePlasmaDamage.damage;
			Debug.Log("Enemy health is " + EnemyHealth);
			//battlecontroller.enemyText.text = "Health: " + EnemyHealth;

			//SMOKE GRAPHICS
			if (EnemyHealth == 80){
				Vector3 startPostion = transform.position + new Vector3 (2,2,0);
				GameObject smokeHit= Instantiate(smoke, startPostion, Quaternion.identity) as GameObject;
			}

			if (EnemyHealth == 60){
				Vector3 startPostion = transform.position + new Vector3 (0,0,0);
				GameObject bigExplosi= Instantiate(bigExplosion, startPostion, Quaternion.identity) as GameObject;
			}
			if (EnemyHealth < 20){
				Vector3 startPostion = transform.position + new Vector3 (0,-.38f,0.47f);
				GameObject smokeLot= Instantiate(lotSmoke, startPostion, Quaternion.identity) as GameObject;
				smokeLot.transform.parent = gameObject.transform;
			}


		}


		if (laser && chanceEnemyHit < playerAccuracy){
			Debug.Log("EnemyShip hit by laser");

			Destroy (collider.gameObject);
			//LAserIMPACT
			GameObject bLImpact= Instantiate(BlueLaserImpact, playerHitPos, Quaternion.identity) as GameObject;

			//xp.GainXP(10);
			//smoke.SetActive(true);
			EnemyHealth = EnemyHealth - basicLaserDamage.damage;
			Debug.Log("Enemy health is " + EnemyHealth);
			//battlecontroller.enemyText.text = "Health: " + EnemyHealth;

			//SMOKE GRAPHICS
			if (EnemyHealth == 80){
				Vector3 startPostion = transform.position + new Vector3 (2,2,0);
				GameObject smokeHit= Instantiate(smoke, startPostion, Quaternion.identity) as GameObject;
			}

			if (EnemyHealth == 60){
				Vector3 startPostion = transform.position + new Vector3 (0,0,0);
				GameObject bigExplosi= Instantiate(bigExplosion, startPostion, Quaternion.identity) as GameObject;
			}
			if (EnemyHealth < 20){
				Vector3 startPostion = transform.position + new Vector3 (0,-.38f,0.47f);
				GameObject smokeLot= Instantiate(lotSmoke, startPostion, Quaternion.identity) as GameObject;
				smokeLot.transform.parent = gameObject.transform;
			}

		}


		if (electricBolt && chanceEnemyHit < playerAccuracy){
			Debug.Log("EnemyShip hit by plasma");

			Destroy (collider.gameObject);
			//Electric Bolt IMPACT
			GameObject electricImpact = Instantiate(ElectricBoltImpact, playerHitPos, Quaternion.identity) as GameObject;

			//xp.GainXP(10);
			//smoke.SetActive(true);
			EnemyHealth = EnemyHealth - electricBoltDamage.damage;
			Debug.Log("Enemy health is " + EnemyHealth);
			playerController.evade = 100f;
			//battlecontroller.enemyText.text = "Health: " + EnemyHealth;

			//SMOKE GRAPHICS
			if (EnemyHealth == 80){
				Vector3 startPostion = transform.position + new Vector3 (2,2,0);
				GameObject smokeHit= Instantiate(smoke, startPostion, Quaternion.identity) as GameObject;
			}

			if (EnemyHealth == 60){
				Vector3 startPostion = transform.position + new Vector3 (0,0,0);
				GameObject bigExplosi= Instantiate(bigExplosion, startPostion, Quaternion.identity) as GameObject;
			}
			if (EnemyHealth < 20){
				Vector3 startPostion = transform.position + new Vector3 (0,-.38f,0.47f);
				GameObject smokeLot= Instantiate(lotSmoke, startPostion, Quaternion.identity) as GameObject;
				smokeLot.transform.parent = gameObject.transform;
			}

		
			//	playerController.playerAnimator.SetBool ("Evade", false);


				//Invoke ("ThisEnemyDead", 2f);


		}

		if(EnemyHealth <= 0 ){

			thisShip.SetActive(false);
			Vector3 startPostion2 = transform.position + new Vector3 (0,0,0);
			GameObject deathexplosion2 = Instantiate(DeadExplosion, startPostion2,Quaternion.identity) as GameObject;
			playerController.enemyIsDead = true;
			Character.Credits = Character.Credits + 100;
			xp.GainXP (100);
			PlayerPrefs.SetInt ("PLAYER_CREDITS", Character.Credits);
			xp.UpdateDisplay ();
			//xp.GainXP(100);
			numberOfAttackers = numberOfAttackers - 1;
			playerController.playerAnimator.SetBool ("Evade", false);

			thisAiDead = true;


			if (numberOfAttackers == 0) {




				Invoke ("EnemyDead", 3f);

			}

			//Invoke ("ThisEnemyDead", 2f);
		}

	}






	//------------------------------ENEMY FIRING------------------------------





	public void EnemyTurn(){
		//	Debug.Log ("Enemyturn function in battlecontroller activated");
		float probability = Time.deltaTime * shotsPerSeconds;
		if (enemyattackpoints > 1){

			if (Random.value < probability){
				//Debug.Log("EnemyRPGFire enemyturn - enemy attack points are greater than 1 active");
				//Debug.Log("Enemy RPG Fire enemyattack points inside enemyturn function is " + enemyattackpoints);
				enemyFire();
				enemyattackpoints = enemyattackpoints -50;
			}



		}
		else {
			playerController.playerAnimator.SetBool ("Evade", false);

			playerController.playerAnimator.SetBool ("Evade2", false);

			playerController.playerAnimator.SetBool ("Evade3", false);
			enemyattackpoints= 100f;
			playerController.evade = PlayerPrefs.GetFloat("EVADE");
			battlecontroller.EndTurn();
		}

	}


	public void enemyFire(){

		if (!thisAiDead) {

			transform.LookAt (PlayerShip.transform.position);

			///EVADE ANIMATIONS
			if (playerController.evadeOn){
				
				playerController.evade += 30;

				int whichEvade = Random.Range (0, 75);

				if (whichEvade <= 24) {
				
					playerController.playerAnimator.SetBool ("Evade", true);
				
				}

				if (whichEvade > 24 && whichEvade < 50) {

					playerController.playerAnimator.SetBool ("Evade2", true);

				}

				if (whichEvade >= 50) {
				
					playerController.playerAnimator.SetBool ("Evade3", true);

				
				}





			}






			Vector3 startPostion2 = Weapon1.transform.position;
			Vector3 startPositionRight = Weapon2.transform.position;
			int whichGun = Random.Range (0, 51);

			if (whichGun > 25) {

				GameObject laserRed = Instantiate(enemyProjectile1, startPositionRight, Quaternion.identity) as GameObject;
				laserRed.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);
				//beam.GetComponent<Rigidbody>().velocity = new Vector3 (enemyShip.transform.position.x,enemyShip.transform.position.y,enemyShip.transform.position.z + .5f);
				laserRed.GetComponent<Rigidbody> ().velocity = (GameObject.Find ("PLayerShipFightTwoShips").transform.position - transform.position).normalized * 90f;





				/*GameObject laserRed= Instantiate(enemyProjectile1, startPositionRight, Quaternion.identity) as GameObject;
				laserRed.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

				laserRed.GetComponent<Rigidbody>().velocity = new Vector3 (PlayerShip.transform.position.x, PlayerShip.transform.position.y,playershipPositionZ + 1.5f);
				*/

			}

			if (whichGun <= 25) {

				GameObject laserRed = Instantiate(enemyProjectile1, startPostion2, Quaternion.identity) as GameObject;
				laserRed.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);
				//beam.GetComponent<Rigidbody>().velocity = new Vector3 (enemyShip.transform.position.x,enemyShip.transform.position.y,enemyShip.transform.position.z + .5f);
				laserRed.GetComponent<Rigidbody> ().velocity = (GameObject.Find ("PLayerShipFightTwoShips").transform.position - transform.position).normalized * 90f;






				/*GameObject laserRed= Instantiate(enemyProjectile1, startPostion2, Quaternion.identity) as GameObject;
				laserRed.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

				laserRed.GetComponent<Rigidbody>().velocity = new Vector3 (PlayerShip.transform.position.x, PlayerShip.transform.position.y,playershipPositionZ + .5f );
				*/

			}

		

		
		}


		playerController.playerAnimator.SetBool ("Evade", false);


	

	}



	public void EnemyDead(){

		RTSBattleController.shieldCharged = true;

		RTSBattleController.shieldWait = 0;

		RTSBattleController.repairCharged =true;

		RTSBattleController.repairWait = 0;

		Character.Credits = Character.Credits + 100;

		GoingToShipAfterBattleScript.doneFight = true;

		//levelmanager.LoadLevel(Character.where);

		Destroy(gameObject);

	}







	

}
