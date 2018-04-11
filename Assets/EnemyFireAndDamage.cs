using UnityEngine;
using System.Collections;

public class EnemyFireAndDamage : MonoBehaviour {
	//public GameObject playerPrimaryWeapon;
	//public GameObject playerplasmaLaser;
	public GameObject PlayerShip;
	public GameObject EnemyShip;
	BasicLaserScript basicLaserDamage;
	bluePlasmaLaser blueplasmalaserDamage;
	ElectricBoltScript electricBoltDamage;

	ShieldDeflectorEnergyBackScript shielddeflectorenergy;

	public Transform playerShipTarget;

	public float playershipPositionY;
	public float playershipPositionZ;
	
	
	public float EnemyHealth = 100f;
	RTSBattleController playercontroller;
	
	//Enemy Components
	public GameObject enemyProjectile;
	public GameObject BossProjectile;

	public GameObject defaultSmallGunRight;
	public GameObject defaultSmallGunLeft;
	
	//QuantumEnemy
	public GameObject QuantumProjectile;
	public GameObject QuantumFireLauncherLeft;
	public GameObject QuantumFireLauncherRight;
	public GameObject QuantumShieldKill;
	
	public float projectileSpeed = -20f;
	public float shotsPerSeconds = 0.5f;
	public float enemyattackpoints = 100f;
	
	public GameObject smoke;
	public GameObject bigExplosion;
	public GameObject DeadExplosion;
	public GameObject lotSmoke;

	public bool hasShield = false;
	
	
	public GameObject ShieldDeflectImpact;
	public GameObject BlueLaserImpact;
	public GameObject PlasmaLaserImpact;
	public GameObject ElectricBoltImpact;

	
	
	LevelManager levelmanager;
	BattleControllerTurnBased battlecontroller;
	private int takeAwayEnemy;
	
	
	public static bool justWon= false;
	
	XP xp;
	
	
	//player talents
	float playerAccuracy;
	float deflectorDamage;


	
	
	
	EnemyHealthScript enemyDamageAnimation;
	
	
	
	
	

	void Start () {

		playerShipTarget = PlayerShip.GetComponent<Transform> ();
	playerAccuracy = PlayerPrefs.GetFloat("GUNNER") + 50f;
	deflectorDamage = PlayerPrefs.GetFloat("DEFLECTORS");
	justWon = false;
	//smoke.SetActive(false);
	//bigExplosion.SetActive(false);
	levelmanager = LevelManager.FindObjectOfType<LevelManager>();
		battlecontroller = BattleControllerTurnBased.FindObjectOfType<BattleControllerTurnBased>();
	playercontroller = RTSBattleController.FindObjectOfType<RTSBattleController>();
	takeAwayEnemy = PlayerPrefs.GetInt("NGC1300NUMBER_OF_ENEMIES") - 1;
	xp = XP.FindObjectOfType<XP>();
	
	}

	void Update(){
	
		playershipPositionY = playerShipTarget.position.y;
		playershipPositionZ = playerShipTarget.position.z;
	
	}


	
	
	
//----------------------------------Enemy Taking Damage-------------------
	
	void OnTriggerEnter(Collider collider){
		//Damage Animations

		enemyDamageAnimation = EnemyHealthScript.FindObjectOfType<EnemyHealthScript> ();




		blueplasmalaserDamage = bluePlasmaLaser.FindObjectOfType<bluePlasmaLaser>();
		bluePlasmaLaser plasma = collider.gameObject.GetComponent<bluePlasmaLaser>();
		
		basicLaserDamage = BasicLaserScript.FindObjectOfType<BasicLaserScript>();
		BasicLaserScript laser = collider.gameObject.GetComponent<BasicLaserScript>();
		
		shielddeflectorenergy = ShieldDeflectorEnergyBackScript.FindObjectOfType<ShieldDeflectorEnergyBackScript>();
		ShieldDeflectorEnergyBackScript shieldDeflectEnergy = collider.gameObject.GetComponent<ShieldDeflectorEnergyBackScript>();

		electricBoltDamage = ElectricBoltScript.FindObjectOfType<ElectricBoltScript> ();
		ElectricBoltScript electricBolt = collider.gameObject.GetComponent<ElectricBoltScript> ();

		Vector3 playerHitPos = collider.transform.position;
		
		
		
		float chanceEnemyHit = Random.Range(1,100);

		if (EnemyHealth <= 0) {

			playercontroller.playerAnimator.SetBool ("Evade", false);

		
			collider.enabled = false;

		
		}
		
		
		
		
		
		if (shieldDeflectEnergy && chanceEnemyHit < playerAccuracy){

			enemyDamageAnimation.ReceiveDamage (shielddeflectorenergy.damage);

		
			
			Destroy (collider.gameObject);
			GameObject deflectenergyimpact= Instantiate(ShieldDeflectImpact, playerHitPos, Quaternion.identity) as GameObject;
			
			xp.GainXP(10);
			//smoke.SetActive(true);
			EnemyHealth = EnemyHealth - shielddeflectorenergy.damage * deflectorDamage;
			Debug.Log("Enemy health is " + EnemyHealth);
			//battlecontroller.enemyText.text = "Health: " + EnemyHealth;
			
			//SMOKE GRAPHICS
			if (EnemyHealth == 80){
				Vector3 startPostion = transform.position + new Vector3 (2,2,0);
				GameObject smokeHit= Instantiate(smoke, playerHitPos, Quaternion.identity) as GameObject;
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
			
			if(EnemyHealth <= 0 ){
				EnemyShip.SetActive(false);
				Vector3 startPostion = transform.position + new Vector3 (0,0,0);
				GameObject deathexplosion = Instantiate(DeadExplosion, startPostion,Quaternion.identity) as GameObject;
				playercontroller.enemyIsDead = true;
				Character.Credits = Character.Credits + 100;
				PlayerPrefs.SetInt ("PLAYER_CREDITS", Character.Credits);
				xp.UpdateDisplay ();
				//xp.GainXP(100);
				Invoke ("EnemyDead", 6);
			}
		}
		
		
		if (plasma && chanceEnemyHit < playerAccuracy){

			enemyDamageAnimation.ReceiveDamage (blueplasmalaserDamage.damage);



			Debug.Log("EnemyShip hit by plasma");
			
			Destroy (collider.gameObject);
			 //PLASMA IMPACT
			GameObject plas= Instantiate(PlasmaLaserImpact, playerHitPos, Quaternion.identity) as GameObject;
			
			xp.GainXP(10);
			//smoke.SetActive(true);
			EnemyHealth = EnemyHealth - blueplasmalaserDamage.damage;
			Debug.Log("Enemy health is " + EnemyHealth);
			//battlecontroller.enemyText.text = "Health: " + EnemyHealth;
			
			//SMOKE GRAPHICS
			if (EnemyHealth == 80){
				Vector3 startPostion = transform.position + new Vector3 (2,2,0);
				GameObject smokeHit= Instantiate(smoke, playerHitPos, Quaternion.identity) as GameObject;
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
			
			if(EnemyHealth <= 0 ){
				
				EnemyShip.SetActive(false);
				Vector3 startPostion = transform.position + new Vector3 (0,0,0);
				GameObject deathexplosion = Instantiate(DeadExplosion, startPostion,Quaternion.identity) as GameObject;
				playercontroller.enemyIsDead = true;
				Character.Credits = Character.Credits + 100;
				PlayerPrefs.SetInt ("PLAYER_CREDITS", Character.Credits);
				xp.UpdateDisplay ();
				//xp.GainXP(100);
				Invoke ("EnemyDead", 6);
			}
		}
		
		
		if (laser && chanceEnemyHit < playerAccuracy){

			enemyDamageAnimation.ReceiveDamage (basicLaserDamage.damage);






			Debug.Log("EnemyShip hit by laser");
			
			Destroy (collider.gameObject);
			 //LAserIMPACT
			GameObject bLImpact= Instantiate(BlueLaserImpact, playerHitPos, Quaternion.identity) as GameObject;
			
			xp.GainXP(10);
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
			
			if(EnemyHealth <= 0 ){
				if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "NGC1300BOSS") {
					EnemyShip.SetActive(false);
					Vector3 startPostion = transform.position + new Vector3 (0,0,0);
					GameObject deathexplosion = Instantiate(DeadExplosion, startPostion,Quaternion.identity) as GameObject;
					playercontroller.enemyIsDead = true;
					Character.Credits = Character.Credits + 100;
					PlayerPrefs.SetInt ("PLAYER_CREDITS", Character.Credits);
					xp.UpdateDisplay ();
					//xp.GainXP(100);
					Invoke ("BossEnemyDead", 6);
				}
				EnemyShip.SetActive(false);
				Vector3 startPostion2 = transform.position + new Vector3 (0,0,0);
				GameObject deathexplosion2 = Instantiate(DeadExplosion, startPostion2,Quaternion.identity) as GameObject;
				playercontroller.enemyIsDead = true;
				Character.Credits = Character.Credits + 100;
				PlayerPrefs.SetInt ("PLAYER_CREDITS", Character.Credits);
				xp.UpdateDisplay ();
				//xp.GainXP(100);
				DropItem.DROPITEM = 1;
				Invoke ("EnemyDead", 6);
			}
		}


		if (electricBolt && chanceEnemyHit < playerAccuracy){


			enemyDamageAnimation.ReceiveDamage (electricBoltDamage.damage);



			Debug.Log("EnemyShip hit by plasma");

			Destroy (collider.gameObject);
			//Electric Bolt IMPACT
			GameObject electricImpact = Instantiate(ElectricBoltImpact, playerHitPos, Quaternion.identity) as GameObject;

			xp.GainXP(10);
			//smoke.SetActive(true);
			EnemyHealth = EnemyHealth - electricBoltDamage.damage;
			Debug.Log("Enemy health is " + EnemyHealth);
			playercontroller.evade = 100f;
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

			if(EnemyHealth <= 0 ){

				EnemyShip.SetActive(false);
				Vector3 startPostion = transform.position + new Vector3 (0,0,0);
				xp.GainXP (50);

				GameObject deathexplosion = Instantiate(DeadExplosion, startPostion,Quaternion.identity) as GameObject;
				playercontroller.enemyIsDead = true;

				PlayerPrefs.SetInt ("PLAYER_CREDITS", Character.Credits);
				xp.UpdateDisplay ();
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
		Character.Credits = Character.Credits + 100;

		Debug.Log("take away enemy is " + takeAwayEnemy);
		PlayerPrefs.SetInt("NGC1300NUMBER_OF_ENEMIES", takeAwayEnemy);
		NGC1300.numberOfEnemies = NGC1300.numberOfEnemies - 1;
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "QuantumDefault") {
			PlayerPrefs.SetInt ("GNZ11NUMBER_OF_ENEMIES", takeAwayEnemy);
			GNz11.numberOfEnemies = GNz11.numberOfEnemies - 1;
		}
		
		
		levelmanager.LoadLevel(Character.where);
		
		
		//PLACE BACK IN WHEN DONE 
		//levelmanager.LoadLevel(WarpDrive.where);
		
		
		
		
		Destroy(gameObject);
	}

	public void BossEnemyDead(){
		justWon = true;
		RTSBattleController.shieldCharged = true;
		RTSBattleController.shieldWait = 0;
		RTSBattleController.repairCharged =true;
		RTSBattleController.repairWait = 0;

	


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

			if (enemyattackpoints > 1){
				if (Random.value < probability) {
				//Debug.Log("EnemyRPGFire enemyturn - enemy attack points are greater than 1 active");
				//Debug.Log("Enemy RPG Fire enemyattack points inside enemyturn function is " + enemyattackpoints);
					enemyFire ();
					enemyattackpoints = enemyattackpoints - 50;
				}
				
				
			}
			else {
			enemyattackpoints= 100f;

			playercontroller.evade = PlayerPrefs.GetFloat("EVADE");

			playercontroller.playerAnimator.SetBool ("Evade", false);

			playercontroller.playerAnimator.SetBool ("Evade2", false);

			playercontroller.playerAnimator.SetBool ("Evade3", false);

			battlecontroller.EndTurn();

			playercontroller.evadeOn = false;

			}
			

	}
	
	
	public void enemyFire(){
	
		if (playercontroller.enemyIsDead == false){

			///EVADE ANIMATIONS
			if (playercontroller.evadeOn){

				playercontroller.evade += 30;

				int whichEvade = Random.Range (0, 75);

				if (whichEvade <= 24) {

					playercontroller.playerAnimator.SetBool ("Evade", true);

				}

				if (whichEvade > 24 && whichEvade < 50) {

					playercontroller.playerAnimator.SetBool ("Evade2", true);

				}

				if (whichEvade >= 50) {

					playercontroller.playerAnimator.SetBool ("Evade3", true);


				}





			}

			if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "NGC1300BOSS") {
				Vector3 startPostion = transform.position + new Vector3 (0,0,0);
				GameObject bossprojectile= Instantiate(BossProjectile, startPostion, Quaternion.identity) as GameObject;

				bossprojectile.GetComponent<Rigidbody>().velocity = new Vector3 (PlayerShip.transform.position.x, PlayerShip.transform.position.y,PlayerShip.transform.position.z);
			}

			if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "ShipSmallGreyDefault") {
				Vector3 startPostion2 = defaultSmallGunLeft.transform.position;
				Vector3 startPositionRight = defaultSmallGunRight.transform.position;
				int whichGun = Random.Range (0, 51);

				if (whichGun > 25) {
				
					GameObject laserRed= Instantiate(enemyProjectile, startPositionRight, Quaternion.identity) as GameObject;
					laserRed.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

					laserRed.GetComponent<Rigidbody> ().velocity = (PlayerShip.transform.position - transform.position).normalized * 90f;

					//laserRed.GetComponent<Rigidbody>().velocity = new Vector3 (PlayerShip.transform.position.x, PlayerShip.transform.position.y,playershipPositionZ + 1.5f);
				
				}

				if (whichGun <= 25) {
				
					GameObject laserRed= Instantiate(enemyProjectile, startPostion2, Quaternion.identity) as GameObject;
					laserRed.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

					laserRed.GetComponent<Rigidbody> ().velocity = (PlayerShip.transform.position - transform.position).normalized * 90f;


					//laserRed.GetComponent<Rigidbody>().velocity = new Vector3 (PlayerShip.transform.position.x, PlayerShip.transform.position.y,playershipPositionZ + .5f );
				
				
				}


			}
			if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "QuantumDefault") {
				Vector3 startPostion = QuantumFireLauncherLeft.transform.position;
				GameObject quantumWeapon= Instantiate(QuantumProjectile, startPostion, Quaternion.identity) as GameObject;
				quantumWeapon.transform.rotation = Quaternion.AngleAxis (85f, Vector3.up);
				
				//quantumWeapon.GetComponent<Rigidbody>().velocity = new Vector3 (PlayerShip.transform.position.x, PlayerShip.transform.position.y,PlayerShip.transform.position.z);
				quantumWeapon.GetComponent<Rigidbody>().velocity = new Vector3 (playerShipTarget.position.x, playershipPositionY,playershipPositionZ + .5f);



				Vector3 startPostion2 = QuantumFireLauncherRight.transform.position;
				GameObject quantumWeapon2= Instantiate(QuantumProjectile, startPostion2, Quaternion.identity) as GameObject;
				quantumWeapon2.transform.rotation = Quaternion.AngleAxis (85f, Vector3.up);
				
				quantumWeapon2.GetComponent<Rigidbody>().velocity = new Vector3 (playerShipTarget.position.x, playershipPositionY,playershipPositionZ + .5f);
				
				int randomizeSpecial = Random.Range(1,50);
				if (randomizeSpecial < 5){
					if (RTSBattleController.shieldOn){
						Vector3 startPostion3 = QuantumFireLauncherLeft.transform.position;
						GameObject shieldKill= Instantiate(QuantumShieldKill, startPostion3, Quaternion.identity) as GameObject;
						shieldKill.transform.rotation = Quaternion.AngleAxis (86.9f, Vector3.up);
						
						shieldKill.GetComponent<Rigidbody>().velocity = new Vector3 (PlayerShip.transform.position.x, PlayerShip.transform.position.y,PlayerShip.transform.position.z);
						//send to rtsbattlecontroller that once hit by shieldkill projectile remove shield health.
						
						playercontroller.shield.SetActive(false);
					}
				}
			}


		
		
		}
		
		
		
		//if (enemyattackpoints < 1 ){
		
		//}
		//Destroy(GameObject);
		//Laser.Play();	
		
		
		
	}


	//------------------------------------------------------------------------------------ENEMYFLEE------------------------

	public void EnemyFlee(){
	
	
	
	}
}
