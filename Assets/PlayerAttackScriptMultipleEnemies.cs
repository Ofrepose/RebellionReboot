using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackScriptMultipleEnemies : MonoBehaviour {


	public GameObject basicLaser;
	public GameObject enemyShip;
	public GameObject enemyShip2;

	public GameObject plasmaLaser;

	public GameObject electricBoltCannon;

	//player components

	Projectile projectile;
	public float projectileSpeed = 20f;

	public Animator playerAnimator;

	public FrostEffect frost;
	public Image glassCrack;

	public GameObject weaponCharge;
	public static bool weaponIsCharged = false;




	//SKILLS
	public GameObject shield;	
	public Animator shieldAnimator;

	public static bool shieldOn = false;
	int shieldHealth = 25;

	public GameObject shieldDeflector;
	public static int shieldDeflectorHealth= 10;
	public static bool shieldDeflectorCharged = true;
	public static int shieldDeflectorWait;
	public static bool deflectorShieldOn = false;
	public GameObject shieldDeflectorEnergy;


	public GameObject shieldBarPanel;



	public Text attackpoints;

	//Talents

	DiplomacyScript diplomacy;

	public static bool shieldCharged = true;
	public static int shieldWait;

	public static bool repairCharged = true;
	public static int repairWait;

	public static bool diplomacyUsed = false;


	public static bool evadeCharged = true;
	public bool evadeOn = true;
	public static int evadeWait;

	//Damage Animations
	public GameObject smoke;
	public GameObject bigExplosion;
	public GameObject DeadExplosion;
	public GameObject redRocketHit;

	public Image shieldBar;
	public Image AttackPoints;

	//enemy components
	EnemyBasicLaserScript damage;
	public bool enemyIsDead = false;

	RedRocketScript redRocketDamage;
	public GameObject redlaserImpact;


	BattleControllerTurnBasedMultipleScript battlecontroller;
	PlayerHealth playerhealth;
	LevelManager levelmanager;

	public TwoEnemiesAttackingScript pirate1;
	public TwoEnemiesAttackingScript pirate2;


	public float evade;
	public GameObject silverhawk;
	public GameObject resistance;
	public GameObject playership;

	public int moves;

	public GameObject MovesPanel;
	public Text Move1;
	public Text Move2;
	public Text Move3;
	public Text Move4;
	public Text Move5;
	public Text Move6;

	int Move1Target;
	int Move2Target;
	int Move3Target;
	int Move4Target;
	int Move5Target;
	int Move6Target;

	bool Target1 = false;
	bool Target2 = false;


	//AUDIO VOICES
	private AudioSource shield1;
	private AudioSource shield2;
	private AudioSource repair1;
	private AudioSource repair2;
	private AudioSource okIllGetToIt;
	public AudioSource shieldOnAudio;
	private AudioSource shieldOffAudio;
	private AudioSource evadeAudio;


	//Aiming
	public GameObject targetLocked;
	public GameObject targetLocked2;
	public Animator aimingReticle;
	public Animator aimingReticle2;


	Vector3 move1;
	Vector3 move2;
	Vector3 move3;
	Vector3 move4;
	Vector3 move5;
	Vector3 move6;

	Vector3 nullingTheVector;






	void Start () {

		//---------------------!!!!!!!!!!!!!!!!!!!!! FOR TESTING ONLY!!!!!!!!!!!!!!!!!!!--------------------------



		//PlayerPrefs.SetFloat ("EVADEBOOSTER_SKILL", 1f);
		//evadeOn = true;
		//PlayerPrefs.SetFloat("REPAIR_SKILL", 1f);
		//GoingToShipAfterBattleScript.doneFight = true;





		//---------------------!!!!!!!!!!!!!!!!!!!!! END TESTING !!!!!!!!!!!!!!!!!!!--------------------------

		evadeOn = false;

		aimingReticle.speed = 1 - (PlayerPrefs.GetInt("GUNNER_LVL") * .02f);

		glassCrack.enabled = false;
		frost.FrostAmount = 0f;
		if (PlayerHealth.playerHealth <= 20) {
			Debug.Log ("playerhealth is less than twenty...apparently");
			frost.enabled = true;
			glassCrack.enabled = true;
			frost.FrostAmount =.26f;

			Debug.Log ("frost enabled = " + frost.enabled);



		}


		playerAnimator = GetComponent<Animator> ();
		diplomacy = DiplomacyScript.FindObjectOfType<DiplomacyScript> ();
		diplomacyUsed = false;
		shieldOn = false;
		evade = PlayerPrefs.GetFloat("EVADE");
		shieldBar.fillAmount = 0;

		//resistance = GameObject.FindWithTag("RESISTANCEBATTLE")as GameObject;
		//silverhawk = GameObject.FindWithTag("SILVERHAWKBATTLE")as GameObject;
		if (Character.isSilverhawk){
			silverhawk.SetActive(true);
			resistance.SetActive(false);

		}
		if (!Character.isSilverhawk){
			silverhawk.SetActive(false);
			resistance.SetActive(true);
		}

		var aSource = GetComponents<AudioSource>();

		shield1 = aSource [0];
		shield2 = aSource [1];
		repair1 = aSource [2];
		repair2 = aSource [3];
		okIllGetToIt = aSource [4];
		shieldOnAudio = aSource [5];
		shieldOffAudio = aSource [6];
		evadeAudio = aSource [7];

		//GameObject enemyParent = GameObject.Find("EnemyList");
		//enemyShip = enemyParent.transform.GetChild(0).gameObject;
		//enemyShipSmallGrayDefault = enemyParent.transform.GetChild(0).gameObject;
		battlecontroller =BattleControllerTurnBasedMultipleScript.FindObjectOfType<BattleControllerTurnBasedMultipleScript>();
		playerhealth = PlayerHealth.FindObjectOfType<PlayerHealth>();
		shield.SetActive(false);
		playerhealth.UpdateDisplay();
		levelmanager = LevelManager.FindObjectOfType<LevelManager>();
		Text attackpoints = GetComponent<Text>();
		if (Character.isSilverhawk){
			silverhawk.SetActive(true);
			resistance.SetActive(false);

		}
		if (Character.isSilverhawk == false){
			silverhawk.SetActive(false);
			resistance.SetActive(true);
		}
		AttackPoints.fillAmount = 1f;

		//attackpoints.text= "100";



	}

	void Update () {
		if (!shieldCharged){
			Debug.Log ("Shield Wait is " + shieldWait);
			if (shieldWait == 10){
				shieldCharged = true;
				shieldWait = 0;
			} 
		}

		if (!repairCharged){
			Debug.Log("repair wait is " + repairWait);
			if (repairWait == 8){
				repairCharged = true;
				repairWait = 0;
			}
		}
		if (!shieldDeflectorCharged){

			if (shieldDeflectorWait == 10){
				shieldDeflectorCharged = true;
				shieldDeflectorHealth = 10;
				shieldDeflectorWait = 0;
			}
		}
		if (!evadeCharged){

			if (evadeWait == 4){
				evadeCharged = true;

				evadeWait = 0;
			}
		}

	



		if (Input.GetKeyDown(KeyCode.Return)){

			EndTurnDoAttacks();

		}
		if (Input.GetKeyDown(KeyCode.Alpha1)){

			BtnPrimary();

		}

		if (Input.GetKeyDown(KeyCode.Alpha2 )){

			PlasmaLaserBtn();

		}

		if ( PlayerHealth.playerHealth <= 20) {
			glassCrack.enabled = true;
			frost.enabled = true;



			float maxAmount = .26f;


			if (frost.FrostAmount < maxAmount) {

				frost.FrostAmount += Time.deltaTime * 0.01f;

			}


		}





	}


	//----------------------------PLAYER FIGHT--------------------------------

	public void PlayerFight(){

		Debug.Log("Inside Player Fight");

		if (battlecontroller.attackPoints > 0){

				Debug.Log("player attack points greater than 0");

		}
		else if (battlecontroller.attackPoints < 1) {


		}		
	}
	//------------------------------------PRIMARY ATTACK BUTTON---------------------
	public void BtnPrimary(){
		if (battlecontroller.attackPoints >=50 && battlecontroller.playerTurn && SelectEnemyScript.enemy1Selected || battlecontroller.attackPoints >=50  && battlecontroller.playerTurn &&  SelectEnemy2Script.enemy2Selected){
			aimingReticle.enabled = false;
			aimingReticle2.enabled = false;

			FirePrimary();
		}

	}




	//------------------------------------Plasma ATTACK BUTTON---------------------

	public void PlasmaLaserBtn(){
		if (battlecontroller.attackPoints >= 100 && battlecontroller.playerTurn && SelectEnemyScript.enemy1Selected || SelectEnemy2Script.enemy2Selected){

			aimingReticle.enabled = false;
			aimingReticle2.enabled = false;


			FirePlasma();
		}
	}



	//------------------------------------EVADE BUTTON---------------------
	public void BtnEvade(){

		if (battlecontroller.attackPoints >= 25 && battlecontroller.playerTurn && evadeCharged) {
			evadeCharged = false;
			evadeOn = true;

			evade = 90;

			evadeAudio.Play ();

			battlecontroller.attackPoints -= 25;
			attackpoints.text = battlecontroller.attackPoints.ToString ();
		
		
		}




	}

	//------------------------------------SHIELD BUTTON---------------------
	public void BtnShield(){
		if (battlecontroller.attackPoints >= 100 && battlecontroller.playerTurn && shieldCharged) {
			shield.SetActive(true);
			shieldAnimator.SetTrigger ("ShieldOn");
			shieldCharged = false;
			float whichAudio = .5f;
			/*if (whichAudio > Random.value) {
				shield1.Play ();
			} else {
				shield2.Play ();
			}*/
			shieldOnAudio.Play ();
			shieldOn = true;
			shieldHealth = 100;
			shieldBar.fillAmount = 1;
			battlecontroller.attackPoints = battlecontroller.attackPoints - 100;
			AttackPoints.fillAmount = battlecontroller.attackPoints * .01f;
			attackpoints.text= battlecontroller.attackPoints.ToString();

		}


	}

	public void ShieldCharge(){

	}


	//------------------------------------REPAIR SKILL BUTTON---------------------


	public void RepairSkillBtn(){
		if (battlecontroller.attackPoints >= 100 && battlecontroller.playerTurn && repairCharged) {
			repairCharged = false;
			float whichAudio =  .3f;
			if (whichAudio > Random.value) {
				repair1.Play ();
			} else {
				repair2.Play ();
			}
			PlayerHealth.playerHealth += PlayerPrefs.GetInt("REPAIR_AMOUNT");
			playerhealth.UpdateDisplay();
			battlecontroller.attackPoints = battlecontroller.attackPoints - 100;
			AttackPoints.fillAmount = battlecontroller.attackPoints * .01f;
			attackpoints.text= battlecontroller.attackPoints.ToString();



		}
	}

	//------------------------------------Shield Deflector SKILL BUTTON---------------------
	public void ShieldDeflectorSkillBtn(){
		if (battlecontroller.attackPoints >= 200 && battlecontroller.playerTurn && shieldDeflectorCharged) {
			shieldDeflector.SetActive(true);
			shieldDeflectorCharged = false;
			deflectorShieldOn = true;
			Debug.Log("Deflect Shield is set to true");
			//float whichAudio =  .3f;
			//if (whichAudio > Random.value) {
			//repair1.Play ();
			//} else {
			//repair2.Play ();
			//}

			battlecontroller.attackPoints = battlecontroller.attackPoints - 200;
			AttackPoints.fillAmount = battlecontroller.attackPoints * .01f;
			attackpoints.text= battlecontroller.attackPoints.ToString();



		}
	}


	//------------------------------------Diplomacy SKILL BUTTON---------------------

	public void DiplomacySkillBtn(){
		if (!diplomacyUsed) {

			DiplomacyDialogue ();

		}
		diplomacyUsed = true;


	}


	void ReEnableReticle(){

		aimingReticle.enabled = true;

		aimingReticle2.enabled = true;

	}






	public void FirePlasma(){
		if (battlecontroller.attackPoints >= 100 && battlecontroller.playerTurn && PlayerPrefs.GetInt("PlasmaLaserOnResistance") == 1  || PlayerPrefs.GetInt("ElectricBoltCannon") == 1) {
			BattleControllerTurnBased.firePrimary = true;
			battlecontroller.attackPoints = battlecontroller.attackPoints - 100;
			AttackPoints.fillAmount = battlecontroller.attackPoints * .01f;
			attackpoints.text= battlecontroller.attackPoints.ToString();
			moves += 1;
			if (moves == 1 && SelectEnemyScript.enemy1Selected && !SelectEnemy2Script.enemy2Selected) {
				Move1.text = "Firing Plasma Weapon";
				Move1Target = 1;

				aimingReticle.enabled = false;
				move1 = targetLocked.transform.position;
				Invoke ("ReEnableReticle", 1f);

			}
			if (moves == 1 && !SelectEnemyScript.enemy1Selected && SelectEnemy2Script.enemy2Selected) {
				Move1.text = "Firing Plasma Weapon";
				Move1Target = 2;

				aimingReticle.enabled = false;
				move1 = targetLocked2.transform.position;
				Invoke ("ReEnableReticle", 1f);

			}



			if (moves == 2 && SelectEnemyScript.enemy1Selected && !SelectEnemy2Script.enemy2Selected) {
				Move2.text = "Firing Plasma Weapon";
				Move2Target = 1;

				aimingReticle.enabled = false;
				move2 = targetLocked.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}
			if (moves == 2 && !SelectEnemyScript.enemy1Selected && SelectEnemy2Script.enemy2Selected) {
				Move2.text = "Firing Plasma Weapon";
				Move2Target = 2;

				aimingReticle.enabled = false;
				move2 = targetLocked2.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}






			if (moves == 3 && SelectEnemyScript.enemy1Selected && !SelectEnemy2Script.enemy2Selected) {
				Move3.text = "Firing Plasma Weapon";
				Move3Target = 1;

				aimingReticle.enabled = false;
				move3 = targetLocked.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}
			if (moves == 3 && !SelectEnemyScript.enemy1Selected && SelectEnemy2Script.enemy2Selected) {
				Move3.text = "Firing Plasma Weapon";
				Move3Target = 2;

				aimingReticle.enabled = false;
				move3 = targetLocked2.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}



			if (moves == 4 && SelectEnemyScript.enemy1Selected && !SelectEnemy2Script.enemy2Selected) {
				Move4.text = "Firing Plasma Weapon";
				Move4Target = 1;

				aimingReticle.enabled = false;
				move4 = targetLocked.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}
			if (moves == 4 && !SelectEnemyScript.enemy1Selected && SelectEnemy2Script.enemy2Selected) {
				Move4.text = "Firing Plasma Weapon";
				Move4Target = 2;

				aimingReticle.enabled = false;
				move4 = targetLocked2.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}



			if (moves == 5 && SelectEnemyScript.enemy1Selected && !SelectEnemy2Script.enemy2Selected) {
				Move5.text = "Firing Plasma Weapon";
				Move5Target = 1;

				aimingReticle.enabled = false;
				move5 = targetLocked.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}
			if (moves == 5 && !SelectEnemyScript.enemy1Selected && SelectEnemy2Script.enemy2Selected) {
				Move5.text = "Firing Plasma Weapon";
				Move5Target = 2;

				aimingReticle.enabled = false;
				move5 = targetLocked2.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}


			if (moves == 6 && SelectEnemyScript.enemy1Selected && !SelectEnemy2Script.enemy2Selected) {
				Move6.text = "Firing Plasma Weapon";
				Move6Target = 1;

				aimingReticle.enabled = false;
				move6 = targetLocked.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}
			if (moves == 6 && !SelectEnemyScript.enemy1Selected && SelectEnemy2Script.enemy2Selected) {
				Move6.text = "Firing Plasma Weapon";
				Move6Target = 2;

				aimingReticle.enabled = false;
				move6 = targetLocked2.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}
		}


	}






	public void FirePrimary(){
		/*Move1 = GetComponent<Text> ();
		Move2 = GetComponent<Text> ();
		Move3 = GetComponent<Text> ();
		Move4 = GetComponent<Text> ();
		Move5 = GetComponent<Text> ();
		Move6 = GetComponent<Text> ();*/
		BattleControllerTurnBased.firePrimary = true;
		battlecontroller.attackPoints = battlecontroller.attackPoints - 50;
		AttackPoints.fillAmount = battlecontroller.attackPoints * .01f;
		attackpoints.text= battlecontroller.attackPoints.ToString();
		moves += 1;
		if (moves == 1 && SelectEnemyScript.enemy1Selected && !SelectEnemy2Script.enemy2Selected) {
			Move1.text = "Firing Primary Weapon";
			Move1Target = 1;
			aimingReticle.enabled = false;
			move1 = targetLocked.transform.position;
			Invoke ("ReEnableReticle", 1f);
		}

		if (moves == 1 && !SelectEnemyScript.enemy1Selected && SelectEnemy2Script.enemy2Selected) {
			Move1.text = "Firing Primary Weapon";
			Move1Target = 2;
			aimingReticle.enabled = false;
			move1 = targetLocked2.transform.position;
			Invoke ("ReEnableReticle", 1f);
		}







		if (moves == 2 && SelectEnemyScript.enemy1Selected && !SelectEnemy2Script.enemy2Selected) {
			Move2.text = "Firing Primary Weapon";
			Move2Target = 1;
			aimingReticle.enabled = false;
			move2 = targetLocked.transform.position;
			Invoke ("ReEnableReticle", 1f);
		}
		if (moves == 2 && !SelectEnemyScript.enemy1Selected && SelectEnemy2Script.enemy2Selected) {
			Move2.text = "Firing Primary Weapon";
			Move2Target = 2;

			aimingReticle.enabled = false;
			move2 = targetLocked2.transform.position;
			Invoke ("ReEnableReticle", 1f);
		}



		if (moves == 3 && SelectEnemyScript.enemy1Selected && !SelectEnemy2Script.enemy2Selected) {
			Move3.text = "Firing Primary Weapon";
			Move3Target = 1;

			aimingReticle.enabled = false;
			move3 = targetLocked.transform.position;
			Invoke ("ReEnableReticle", 1f);
		}
		if (moves == 3 && !SelectEnemyScript.enemy1Selected && SelectEnemy2Script.enemy2Selected) {
			Move3.text = "Firing Primary Weapon";
			Move3Target = 2;

			aimingReticle.enabled = false;
			move3 = targetLocked2.transform.position;
			Invoke ("ReEnableReticle", 1f);
		}





		if (moves == 4 && SelectEnemyScript.enemy1Selected && !SelectEnemy2Script.enemy2Selected) {
			Move4.text = "Firing Primary Weapon";
			Move4Target = 1;

			aimingReticle.enabled = false;
			move4 = targetLocked.transform.position;
			Invoke ("ReEnableReticle", 1f);
		}
		if (moves == 4 && !SelectEnemyScript.enemy1Selected && SelectEnemy2Script.enemy2Selected) {
			Move4.text = "Firing Primary Weapon";
			Move4Target = 2;

			aimingReticle.enabled = false;
			move4 = targetLocked2.transform.position;
			Invoke ("ReEnableReticle", 1f);
		}




		if (moves == 5 && SelectEnemyScript.enemy1Selected && !SelectEnemy2Script.enemy2Selected) {
			Move5.text = "Firing Primary Weapon";
			Move5Target = 1;

			aimingReticle.enabled = false;
			move5 = targetLocked.transform.position;
			Invoke ("ReEnableReticle", 1f);
		}
		if (moves == 5 && !SelectEnemyScript.enemy1Selected && SelectEnemy2Script.enemy2Selected) {
			Move5.text = "Firing Primary Weapon";
			Move5Target = 2;

			aimingReticle.enabled = false;
			move5 = targetLocked2.transform.position;
			Invoke ("ReEnableReticle", 1f);
		}





		if (moves == 6 && SelectEnemyScript.enemy1Selected && !SelectEnemy2Script.enemy2Selected) {
			Move6.text = "Firing Primary Weapon";
			Move6Target = 1;

			aimingReticle.enabled = false;
			move6 = targetLocked.transform.position;
			Invoke ("ReEnableReticle", 1f);
		}
		if (moves == 6 && !SelectEnemyScript.enemy1Selected && SelectEnemy2Script.enemy2Selected) {
			Move6.text = "Firing Primary Weapon";
			Move6Target = 2;

			aimingReticle.enabled = false;
			move6 = targetLocked2.transform.position;
			Invoke ("ReEnableReticle", 1f);
		}

		/*Vector3 firePosition = transform.position + new Vector3 (0,0,0);
		GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

		beam.GetComponent<Rigidbody>().velocity = new Vector3 (enemyShip.transform.position.x,enemyShip.transform.position.y,enemyShip.transform.position.z);
		battlecontroller.attackPoints = battlecontroller.attackPoints - 50;
		AttackPoints.fillAmount = battlecontroller.attackPoints * .01f;
		attackpoints.text= battlecontroller.attackPoints.ToString();
		
		print ("beam is here " + beam.transform.position);
		Debug.Log ("laser should have fired");
		Debug.Log (firePosition);
		Debug.Log ("player position is " + transform.position); */
	}



	//-------------------END TURN DO ATTACKS

	public void EndTurnDoAttacks(){

		Debug.Log ("inside end turn do attacks");
		if (battlecontroller.playerTurn){
			if (Move1.text == "Firing Primary Weapon" && Move1Target == 1) {
				Target1 = true;
				Target2 = false;
				FirePrimaryAtTurnEnd ();

			}
			if (Move1.text == "Firing Primary Weapon" && Move1Target == 2) {
				Target1 = false;
				Target2 = true;
				FirePrimaryAtTurnEnd2 ();

			}

			if (Move1.text == "Firing Plasma Weapon" && Move1Target == 1) {
				Target1 = true;
				Target2 = false;
				FirePlasmaAtTurnEnd ();
			}

			if (Move1.text == "Firing Plasma Weapon" && Move1Target == 2) {
				Target1 = false;
				Target2 = true;
				FirePlasmaAtTurnEnd2 ();
			}














			if (Move2.text == "Firing Primary Weapon" && Move2Target == 1) {
				Target1 = true;
				Target2 = false;
				Invoke ("FirePrimaryAtTurnEnd", 1f);
			}

			if (Move2.text == "Firing Primary Weapon" && Move2Target == 2) {
				Target1 = false;
				Target2 = true;
				Invoke ("FirePrimaryAtTurnEnd2", 1f);
			}


			if (Move2.text == "Firing Plasma Weapon" && Move2Target == 1) {
				Target1 = true;
				Target2 = false;
				Invoke ("FirePlasmaAtTurnEnd", 1f);
			}
			if (Move2.text == "Firing Plasma Weapon" && Move2Target == 2) {
				Target1 = false;
				Target2 = true;
				Invoke ("FirePlasmaAtTurnEnd2", 1f);
			}







			if (Move3.text== "Firing Primary Weapon" && Move3Target == 1) {
				Target1 = true;
				Target2 = false;
				Invoke ("FirePrimaryAtTurnEnd", 2f);

			}

			if (Move3.text== "Firing Primary Weapon" && Move3Target == 2) {
				Target1 = false;
				Target2 = true;
				Invoke ("FirePrimaryAtTurnEnd2", 2f);

			}

			if (Move3.text == "Firing Plasma Weapon" && Move3Target == 1) {
				Target1 = true;
				Target2 = false;
				Invoke ("FirePlasmaAtTurnEnd", 2f);
			}
			if (Move3.text == "Firing Plasma Weapon" && Move3Target == 2) {
				Target1 = false;
				Target2 = true;
				Invoke ("FirePlasmaAtTurnEnd2", 2f);
			}






			if (Move4.text == "Firing Primary Weapon" && Move4Target == 1) {
				Target1 = true;
				Target2 = false;
				Invoke ("FirePrimaryAtTurnEnd", 3f);

			}
			if (Move4.text == "Firing Primary Weapon" && Move4Target == 2) {
				Target1 = false;
				Target2 = true;
				Invoke ("FirePrimaryAtTurnEnd2", 3f);

			}

			if (Move4.text == "Firing Plasma Weapon" && Move4Target == 1) {
				Target1 = true;
				Target2 = false;
				Invoke ("FirePlasmaAtTurnEnd", 3f);
			}


			if (Move4.text == "Firing Plasma Weapon" && Move4Target == 2) {
				Target1 = false;
				Target2 = true;
				Invoke ("FirePlasmaAtTurnEnd2", 3f);
			}








			if (Move5.text == "Firing Primary Weapon" && Move5Target == 1) {
				Target1 = true;
				Target2 = false;
				Invoke ("FirePrimaryAtTurnEnd", 4f);
			}

			if (Move5.text == "Firing Primary Weapon" && Move5Target == 2) {
				Target1 = false;
				Target2 = true;
				Invoke ("FirePrimaryAtTurnEnd2", 4f);
			}
			if (Move5.text == "Firing Plasma Weapon" && Move5Target == 1) {
				Target1 = true;
				Target2 = false;

				Invoke ("FirePlasmaAtTurnEnd", 4f);
			}
			if (Move5.text == "Firing Plasma Weapon" && Move5Target == 2) {
				Target1 = false;
				Target2 = true;

				Invoke ("FirePlasmaAtTurnEnd2", 4f);
			}






			if (Move6.text == "Firing Primary Weapon" && Move6Target == 1) {
				Target1 = true;
				Target2 = false;
				Invoke ("FirePrimaryAtTurnEnd", 5);
			}	
			if (Move6.text == "Firing Primary Weapon" && Move6Target == 2) {
				Target1 = false;
				Target2 = true;
				Invoke ("FirePrimaryAtTurnEnd2", 5);
			}


			if (Move6.text == "Firing Plasma Weapon" && Move6Target == 1) {
				Target1 = true;
				Target2 = false;
				Invoke ("FirePlasmaAtTurnEnd", 5f);
			}
			if (Move6.text == "Firing Plasma Weapon" && Move6Target == 2) {
				Target1 = false;
				Target2 = true;
				Invoke ("FirePlasmaAtTurnEnd2", 5f);
			}

			battlecontroller.EndTurn();

		}








	}
	public void FirePrimaryAtTurnEnd(){


		//Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);
		//GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;
		//beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

		if (move1 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move1 - transform.position).normalized * 50f;

			move1 = nullingTheVector;

			return;
		}

		if (move2 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move2 - transform.position).normalized * 50f;

			move2 = nullingTheVector;

			return;
		}

		if (move3 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move3 - transform.position).normalized * 50f;

			move3 = nullingTheVector;

			return;

		}

		if (move4 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move4 - transform.position).normalized * 50f;

			move4 = nullingTheVector;

			return;

		}

		if (move5 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move5 - transform.position).normalized * 50f;

			move5 = nullingTheVector;

			return;
		}


		if (move6 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move6 - transform.position).normalized * 50f;

			move6 = nullingTheVector;

			return;

		}

		weaponIsCharged = false;
		weaponCharge.SetActive (false);










			if (pirate1.thisAiDead) {
				playerAnimator.SetBool ("Evade", false);

				//Destroy (beam);
			} //else {

			//	beam.GetComponent<Rigidbody> ().velocity = (GameObject.Find ("EnemyPirate0").transform.position - transform.position).normalized * 50f;					

		//	}		
	


			

		

	}

	public void FirePrimaryAtTurnEnd2(){
	
	//	Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);
		//GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;
		//beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

		if (move1 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move1 - transform.position).normalized * 50f;

			move1 = nullingTheVector;

			return;
		}

		if (move2 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move2 - transform.position).normalized * 50f;

			move2 = nullingTheVector;

			return;
		}

		if (move3 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move3 - transform.position).normalized * 50f;

			move3 = nullingTheVector;

			return;

		}

		if (move4 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move4 - transform.position).normalized * 50f;

			move4 = nullingTheVector;

			return;

		}

		if (move5 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move5 - transform.position).normalized * 50f;

			move5 = nullingTheVector;

			return;
		}


		if (move6 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move6 - transform.position).normalized * 50f;

			move6 = nullingTheVector;

			return;

		}

		weaponIsCharged = false;
		weaponCharge.SetActive (false);






		if (pirate2.thisAiDead) {
			playerAnimator.SetBool ("Evade", false);

			//Destroy (beam);
		} 
	
	}


	public void FirePlasmaAtTurnEnd(){

				
			Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);
			GameObject plasma = Instantiate(plasmaLaser, firePosition, Quaternion.identity) as GameObject;
			if (pirate1.thisAiDead) {

				Destroy (plasma);
			} else {
			
				plasma.GetComponent<Rigidbody> ().velocity = (GameObject.Find ("EnemyPirate0").transform.position - transform.position).normalized * 50f;					

			}




			
	}
			


	public void FirePlasmaAtTurnEnd2(){


		Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);
		GameObject plasma = Instantiate(plasmaLaser, firePosition, Quaternion.identity) as GameObject;
		//plasma.GetComponent<Rigidbody>().velocity = new Vector3 (enemyShip.transform.position.x,enemyShip.transform.position.y,enemyShip.transform.position.z);


		if (pirate2.thisAiDead) {

			Destroy (plasma);
		} else {

			plasma.GetComponent<Rigidbody> ().velocity = (GameObject.Find ("EnemyPirate2").transform.position - transform.position).normalized * 50f;					

		}

	}


		//-----------------------------ELCTRIC BOLT CANNON-----------------------------------------------------









	//-----------------------------------------------------------------------------SKILLS BUTTONS EXTRA FUNCTIONS HERE ---------------------------------------------------------------

	public void DiplomacyDialogue(){



		diplomacy.StartDialog ();



	}










	//------------------------------------PLAYER DAMAGE TAKEN HERE---------------------
	void OnTriggerEnter(Collider collider){
		EnemyBasicLaserScript enemylaserred = collider.gameObject.GetComponent<EnemyBasicLaserScript>();
		damage = EnemyBasicLaserScript.FindObjectOfType<EnemyBasicLaserScript>();

		RedRocketScript redrocket = collider.gameObject.GetComponent<RedRocketScript> ();
		redRocketDamage = RedRocketScript.FindObjectOfType<RedRocketScript> ();

		float chanceEnemyHit = Random.Range(1,100);

		Vector3 enemyHitPos = collider.transform.position;

		if (enemylaserred && deflectorShieldOn && chanceEnemyHit > evade){
			Debug.Log("INSIDE SHIELD DEFLECT");
			Destroy (collider.gameObject);
			Vector3 startPostion2 = transform.position + new Vector3 (0,0,0);

			GameObject deflectBack= Instantiate(shieldDeflectorEnergy, startPostion2, Quaternion.identity) as GameObject;

			deflectBack.GetComponent<Rigidbody>().velocity = new Vector3 (enemyShip.transform.position.x, enemyShip.transform.position.y,enemyShip.transform.position.z);
			shieldDeflectorHealth = shieldDeflectorHealth - 10;
			if (shieldDeflectorHealth <= 0 ){
				deflectorShieldOn= false;
				shieldDeflector.SetActive(false);



			}
		}


		if (enemylaserred && shieldOn && chanceEnemyHit > evade && !deflectorShieldOn){
			int shieldDamageRandom = Random.Range(5,30);
			shieldHealth = shieldHealth - shieldDamageRandom;
			shieldBar.fillAmount = shieldHealth * .01f;
			Destroy (collider.gameObject);

			GameObject enemyHit = Instantiate (redlaserImpact, enemyHitPos, Quaternion.identity) as GameObject;










			if (shieldHealth <= 0 ){
				shieldOffAudio.Play ();
				shieldAnimator.SetTrigger ("ShieldOff");
				shieldOn = false;
				//shield.SetActive(false);
				ShieldCharge();

			}
		}


		// create if for shieldkill here 	CREATE NEW SCRIPT ON TOP OF SHIELD KILL PROCJECTILE AND ACTIVATE IT HERE
		/* if (shieldKill = true && chanceEnemyHit > evade){
			
			shieldHealth = 0;
			shieldBar.fillAmount = 0;
			Destroy (collider.gameObject);
				
			shieldOn = false;
			shield.SetActive(false);
			ShieldCharge();
		}*/ 



		if (enemylaserred && !shieldOn && chanceEnemyHit > evade && !deflectorShieldOn){
			playerhealth.LoseHealth(damage.damage);

			Destroy (collider.gameObject);

			GameObject enemyHit = Instantiate (redlaserImpact, enemyHitPos, Quaternion.identity) as GameObject;


			//SMOKE GRAPHICS
			if (PlayerHealth.playerHealth == 80 ){
				Vector3 startPostion = transform.position + new Vector3 (0,-.38f,0.47f);
				GameObject smokeHit= Instantiate(smoke, startPostion, Quaternion.identity) as GameObject;
				smokeHit.transform.parent = gameObject.transform;

			}

			if (PlayerHealth.playerHealth == 60){
				Vector3 startPostion = transform.position + new Vector3 (0,0,0);
				GameObject bigExplosi= Instantiate(bigExplosion, startPostion, Quaternion.identity) as GameObject;
			}

			if (PlayerHealth.playerHealth < 20){
				Vector3 startPostion = transform.position + new Vector3 (0,-.38f,0.47f);
				GameObject smokeHit= Instantiate(smoke, startPostion, Quaternion.identity) as GameObject;
				smokeHit.transform.parent = gameObject.transform;
			}

			if (PlayerHealth.playerHealth <=0 ){
				Vector3 startPostion = transform.position + new Vector3 (0,0,0);
				GameObject deathexplosion = Instantiate(DeadExplosion, startPostion,Quaternion.identity) as GameObject;
				this.gameObject.SetActive(false);


				Application.LoadLevel("GameOver");
				Destroy(gameObject);
			}
		}


		//RED ROCKET DAMAGE ------------------------------------------------------------------------------------------------------------------
		/// 
		/// 
		/// 
		if (redrocket && deflectorShieldOn && chanceEnemyHit > evade){
			Debug.Log("INSIDE SHIELD DEFLECT");
			Destroy (collider.gameObject);
			Vector3 startPostion2 = transform.position + new Vector3 (0,0,0);
			GameObject deflectBack= Instantiate(shieldDeflectorEnergy, startPostion2, Quaternion.identity) as GameObject;

			deflectBack.GetComponent<Rigidbody>().velocity = new Vector3 (enemyShip.transform.position.x, enemyShip.transform.position.y,enemyShip.transform.position.z);
			shieldDeflectorHealth = shieldDeflectorHealth - 10;
			if (shieldDeflectorHealth <= 0 ){
				deflectorShieldOn= false;
				shieldDeflector.SetActive(false);



			}
		}


		if (redrocket && shieldOn && chanceEnemyHit > evade && !deflectorShieldOn){
			int shieldDamageRandom = Random.Range(5,25);
			shieldHealth = shieldHealth - shieldDamageRandom;
			shieldBar.fillAmount = shieldHealth * .01f;
			Destroy (collider.gameObject);







			if (shieldHealth <= 0 ){
				shieldOn = false;
				shield.SetActive(false);
				ShieldCharge();
			}
		}
		if (redrocket && !shieldOn && chanceEnemyHit > evade && !deflectorShieldOn){
			playerhealth.LoseHealth(redRocketDamage.damage);
			Vector3 bossmissileimpactposition = transform.position + new Vector3 (0,0,0);
			GameObject rocketHit = Instantiate(redRocketHit, bossmissileimpactposition, Quaternion.identity) as GameObject;


			Destroy (collider.gameObject);

			//SMOKE GRAPHICS
			if (PlayerHealth.playerHealth == 80 ){
				Vector3 startPostion = transform.position + new Vector3 (0,-.38f,0.47f);
				GameObject smokeHit= Instantiate(smoke, startPostion, Quaternion.identity) as GameObject;
				smokeHit.transform.parent = gameObject.transform;

			}

			if (PlayerHealth.playerHealth == 60){
				Vector3 startPostion = transform.position + new Vector3 (0,0,0);
				GameObject bigExplosi= Instantiate(bigExplosion, startPostion, Quaternion.identity) as GameObject;
			}

			if (PlayerHealth.playerHealth < 20){
				Vector3 startPostion = transform.position + new Vector3 (0,-.38f,0.47f);
				GameObject smokeHit= Instantiate(smoke, startPostion, Quaternion.identity) as GameObject;
				smokeHit.transform.parent = gameObject.transform;
			}

			if (PlayerHealth.playerHealth <=0 ){
				Vector3 startPostion = transform.position + new Vector3 (0,0,0);
				GameObject deathexplosion = Instantiate(DeadExplosion, startPostion,Quaternion.identity) as GameObject;
				this.gameObject.SetActive(false);


				Application.LoadLevel("GameOver");
				Destroy(gameObject);
			}
		}


	}



}
