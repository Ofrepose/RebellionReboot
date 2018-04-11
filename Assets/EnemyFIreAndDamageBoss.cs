using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFIreAndDamageBoss : MonoBehaviour {
	//public GameObject playerPrimaryWeapon;
	//public GameObject playerplasmaLaser;
	public GameObject PlayerShip;
	public GameObject EnemyShip;
	public GameObject LeftFire;
	public GameObject RightFire;
	BasicLaserScript basicLaserDamage;
	bluePlasmaLaser blueplasmalaserDamage;
	ShieldDeflectorEnergyBackScript shielddeflectorenergy;


	public float EnemyHealth = 100f;
	RTSBattleController playercontroller;

	//Enemy Components
	public GameObject enemyProjectile;
	public GameObject BossProjectile;
	public float projectileSpeed = -20f;
	public float shotsPerSeconds = 0.5f;
	public float enemyattackpoints = 100f;

	public GameObject smoke;
	public GameObject bigExplosion;
	public GameObject DeadExplosion;


	public GameObject ShieldDeflectImpact;
	public GameObject BlueLaserImpact;
	public GameObject PlasmaLaserImpact;


	LevelManager levelmanager;
	BattleControllerTurnBased battlecontroller;
	private int takeAwayEnemy;


	public static bool justWon= false;

	XP xp;











	void Start () {
		justWon = false;
		//smoke.SetActive(false);
		//bigExplosion.SetActive(false);
		levelmanager = LevelManager.FindObjectOfType<LevelManager>();
		battlecontroller = BattleControllerTurnBased.FindObjectOfType<BattleControllerTurnBased>();
		playercontroller = RTSBattleController.FindObjectOfType<RTSBattleController>();
		takeAwayEnemy = PlayerPrefs.GetInt("NGC1300NUMBER_OF_ENEMIES") - 1;
		xp = XP.FindObjectOfType<XP>();

	}





	//----------------------------------Enemy Taking Damage-------------------

	void OnTriggerEnter(Collider collider){
		blueplasmalaserDamage = bluePlasmaLaser.FindObjectOfType<bluePlasmaLaser>();
		bluePlasmaLaser plasma = collider.gameObject.GetComponent<bluePlasmaLaser>();

		basicLaserDamage = BasicLaserScript.FindObjectOfType<BasicLaserScript>();
		BasicLaserScript laser = collider.gameObject.GetComponent<BasicLaserScript>();

		shielddeflectorenergy = ShieldDeflectorEnergyBackScript.FindObjectOfType<ShieldDeflectorEnergyBackScript>();
		ShieldDeflectorEnergyBackScript shieldDeflectEnergy = collider.gameObject.GetComponent<ShieldDeflectorEnergyBackScript>();



		float chanceEnemyHit = Random.Range(1,100);





		if (shieldDeflectEnergy && chanceEnemyHit > 50){


			Destroy (collider.gameObject);
			Vector3 startPostionDeflectImpact = EnemyShip.transform.position + new Vector3 (0,0,0);
			GameObject deflectenergyimpact= Instantiate(ShieldDeflectImpact, startPostionDeflectImpact, Quaternion.identity) as GameObject;

			xp.GainXP(10);
			//smoke.SetActive(true);
			EnemyHealth = EnemyHealth - shielddeflectorenergy.damage;
			Debug.Log("Enemy health is " + EnemyHealth);
			//battlecontroller.enemyText.text = "Health: " + EnemyHealth;

			//SMOKE GRAPHICS
			if (EnemyHealth == 80){
				Vector3 startPostion = EnemyShip.transform.position + new Vector3 (2,2,0);
				GameObject smokeHit= Instantiate(smoke, startPostion, Quaternion.identity) as GameObject;
			}

			if (EnemyHealth == 60){
				Vector3 startPostion = EnemyShip.transform.position + new Vector3 (0,0,0);
				GameObject bigExplosi= Instantiate(bigExplosion, startPostion, Quaternion.identity) as GameObject;
			}

			if(EnemyHealth <= 0 ){
				EnemyShip.SetActive(false);
				Vector3 startPostion = EnemyShip.transform.position + new Vector3 (0,0,0);
				GameObject deathexplosion = Instantiate(DeadExplosion, startPostion,Quaternion.identity) as GameObject;
				playercontroller.enemyIsDead = true;
				Character.Credits = Character.Credits + 100;
				PlayerPrefs.SetInt ("PLAYER_CREDITS", Character.Credits);
				xp.UpdateDisplay ();
				//xp.GainXP(100);
				Invoke ("EnemyDead", 6);
			}
		}


		if (plasma && chanceEnemyHit > 50){
			Debug.Log("EnemyShip hit by plasma");

			Destroy (collider.gameObject);
			//PLASMA IMPACT
			Vector3 plasmaImpactPostion = EnemyShip.transform.position + new Vector3 (2,2,0);
			GameObject plas= Instantiate(PlasmaLaserImpact, plasmaImpactPostion, Quaternion.identity) as GameObject;

			xp.GainXP(10);
			//smoke.SetActive(true);
			EnemyHealth = EnemyHealth - blueplasmalaserDamage.damage;
			Debug.Log("Enemy health is " + EnemyHealth);
			//battlecontroller.enemyText.text = "Health: " + EnemyHealth;

			//SMOKE GRAPHICS
			if (EnemyHealth == 80){
				Vector3 startPostion = EnemyShip.transform.position + new Vector3 (2,2,0);
				GameObject smokeHit= Instantiate(smoke, startPostion, Quaternion.identity) as GameObject;
			}

			if (EnemyHealth == 60){
				Vector3 startPostion = EnemyShip.transform.position + new Vector3 (0,0,0);
				GameObject bigExplosi= Instantiate(bigExplosion, startPostion, Quaternion.identity) as GameObject;
			}

			if(EnemyHealth <= 0 ){
				EnemyShip.SetActive(false);
				Vector3 startPostion = EnemyShip.transform.position + new Vector3 (0,0,0);
				GameObject deathexplosion = Instantiate(DeadExplosion, startPostion,Quaternion.identity) as GameObject;
				playercontroller.enemyIsDead = true;
				Character.Credits = Character.Credits + 100;
				PlayerPrefs.SetInt ("PLAYER_CREDITS", Character.Credits);
				xp.UpdateDisplay ();
				//xp.GainXP(100);
				Invoke ("EnemyDead", 6);
			}
		}


		if (laser && chanceEnemyHit > 50){
			Debug.Log("EnemyShip hit by laser");

			Destroy (collider.gameObject);
			//LAserIMPACT
			Vector3 laserimpactPostion = EnemyShip.transform.position + new Vector3 (2,2,0);
			GameObject bLImpact= Instantiate(BlueLaserImpact, laserimpactPostion, Quaternion.identity) as GameObject;

			xp.GainXP(10);
			//smoke.SetActive(true);
			EnemyHealth = EnemyHealth - basicLaserDamage.damage;
			Debug.Log("Enemy health is " + EnemyHealth);
			//battlecontroller.enemyText.text = "Health: " + EnemyHealth;

			//SMOKE GRAPHICS
			if (EnemyHealth == 80){
				Vector3 startPostion = EnemyShip.transform.position + new Vector3 (2,2,0);
				GameObject smokeHit= Instantiate(smoke, startPostion, Quaternion.identity) as GameObject;
			}

			if (EnemyHealth == 60){
				Vector3 startPostion = EnemyShip.transform.position + new Vector3 (0,0,0);
				GameObject bigExplosi= Instantiate(bigExplosion, startPostion, Quaternion.identity) as GameObject;
			}

			if(EnemyHealth <= 0 ){
				EnemyShip.SetActive(false);
				Vector3 startPostion = EnemyShip.transform.position + new Vector3 (0,0,0);
				GameObject deathexplosion = Instantiate(DeadExplosion, startPostion,Quaternion.identity) as GameObject;
				deathexplosion.transform.parent = gameObject.transform;

				playercontroller.enemyIsDead = true;
				Character.Credits = Character.Credits + 100;
				PlayerPrefs.SetInt ("PLAYER_CREDITS", Character.Credits);
				xp.UpdateDisplay ();
				PlayerPrefs.SetInt ("BOSS_FIGHT_NGC1300_DONE", 1);
				//xp.GainXP(100);
				Invoke ("EnemyDead", 6);

			}
		}








	}



	public void EnemyDead(){


		justWon = true;
		RTSBattleController.shieldCharged = true;
		RTSBattleController.shieldWait = 0;
		RTSBattleController.repairCharged =true;
		RTSBattleController.repairWait = 0;

		PlayerPrefs.SetInt("BossNGC1300DEAD", 1);



		levelmanager.LoadLevel(Character.where);


		//PLACE BACK IN WHEN DONE 
		//levelmanager.LoadLevel(WarpDrive.where);




		Destroy(gameObject);
	}

	void LoadLevelAfterFight(){
		//levelmanager.LoadLevel(WarpDrive.where);
		levelmanager.LoadLevel("NGC1300");
	}

	public void Dead(){
		battlecontroller.playerTurn = true;
		battlecontroller.StartPlayerTurn();
	}

	//------------------------------ENEMY FIRING------------------------------





	public void EnemyTurn(){
		//	Debug.Log ("Enemyturn function in battlecontroller activated");
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability){
			if (enemyattackpoints > 1){
				//Debug.Log("EnemyRPGFire enemyturn - enemy attack points are greater than 1 active");
				//Debug.Log("Enemy RPG Fire enemyattack points inside enemyturn function is " + enemyattackpoints);
				enemyFire();
				enemyattackpoints = enemyattackpoints -50;


			}
			else {
				enemyattackpoints= 100f;
				battlecontroller.EndTurn();
			}

		}
	}


	public void enemyFire(){

		if (playercontroller.enemyIsDead == false){

			if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "NGC1300BOSS") {
				float randomizePosition = Random.Range (0, 20);
				if (randomizePosition >= 10 ) {
					//Vector3 startPostion = new Vector3 (-40f,-.3f,-2f);
					//CHANGE THIS SOON POSSIBLY!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! ---BELOW
					Vector3 startPostion = LeftFire.transform.position;
					Quaternion rot = Quaternion.AngleAxis (85f, Vector3.up);

					GameObject bossprojectile= Instantiate(BossProjectile, startPostion, rot) as GameObject;
					//bossprojectile.transform.parent = gameObject.transform;
					//bossprojectile.transform.rotation = Quaternion.AngleAxis (85f, Vector3.up);
					bossprojectile.GetComponent<Rigidbody>().velocity = new Vector3 (PlayerShip.transform.position.x, PlayerShip.transform.position.y,PlayerShip.transform.position.z + 1f);
				}
				if (randomizePosition < 10) {
					Vector3 startPostion = RightFire.transform.position;
					Quaternion rot = Quaternion.AngleAxis (85f, Vector3.up);

					GameObject bossprojectile= Instantiate(BossProjectile, startPostion, rot) as GameObject;
					//bossprojectile.transform.parent = gameObject.transform;

					bossprojectile.transform.rotation = Quaternion.AngleAxis (85f, Vector3.up);
					//bossprojectile.GetComponent<Rigidbody>().velocity = (GameObject.Find("PLayerShipFightDefaultShip").transform.position);


					bossprojectile.GetComponent<Rigidbody>().velocity = new Vector3 (PlayerShip.transform.position.x, PlayerShip.transform.position.y,PlayerShip.transform.position.z + 3f);
				}

			}

			if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "ShipSmallGreyDefault") {
				Vector3 startPostion2 = transform.position + new Vector3 (0,0,0);
				GameObject laserRed= Instantiate(enemyProjectile, startPostion2, Quaternion.identity) as GameObject;

				laserRed.GetComponent<Rigidbody>().velocity = new Vector3 (PlayerShip.transform.position.x, PlayerShip.transform.position.y,PlayerShip.transform.position.z);
			}
			//offsets the firing position so the laser shoot from the front of the ship


			//enemyattackpoints = enemyattackpoints - 50;
			//Debug.Log("Enemy attack points in enemyfire funtion is " + enemyattackpoints);

		}



		//if (enemyattackpoints < 1 ){

		//}
		//Destroy(GameObject);
		//Laser.Play();	



	}

}
