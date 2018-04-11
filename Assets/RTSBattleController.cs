using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class RTSBattleController : MonoBehaviour {
	public GameObject basicLaser;
	public GameObject enemyShip;
	public GameObject Boss;
	public GameObject quantumEnemy;
	
	
	
	
	public GameObject plasmaLaser;

	public GameObject electricBoltCannon;
	
	//player components
	
	Projectile projectile;
	public float projectileSpeed = 20f;

	public FrostEffect frost;
	public Image glassCrack;

	public Animator playerAnimator;

	public GameObject weaponCharge;

	public static bool weaponIsCharged = false;




	
	//SKILLS
	public GameObject shield;	
	public static bool shieldOn = false;
	//public int shieldHealth = 25;
	
	public GameObject shieldDeflector;
	public static int shieldDeflectorHealth= 10;
	public static bool shieldDeflectorCharged = true;
	public static int shieldDeflectorWait;
	public static bool deflectorShieldOn = false;
	public GameObject shieldDeflectorEnergy;
	public Animator shieldAnimator;

	
	
	public Text attackpoints;
	
	//Talents

	public GameObject diplomacyPanel;
	
	public DiplomacyScript diplomacy;
	
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
	public GameObject EnemyImpactRedLaser;

	public Image shieldBar;
	public Image AttackPoints;

	public GameObject shieldBarPanel;
	
	//enemy components
	EnemyBasicLaserScript damage;
	public bool enemyIsDead = false;

	RedRocketScript redRocketDamage;
	
	
	BattleControllerTurnBased battlecontroller;
	PlayerHealth playerhealth;
	LevelManager levelmanager;
	
	
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


	//AUDIO VOICES
	private AudioSource shield1;
	private AudioSource shield2;
	private AudioSource repair1;
	private AudioSource repair2;
	private AudioSource okIllGetToIt;
	public AudioSource shieldOnAudio;
	private AudioSource shieldOffAudio;
	private AudioSource evadeAudio;




	public GameObject targetLocked;
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

		//---------------------------------------------------------------------------------DEBUG -----------------------------------------------------------
		//PlayerPrefs.SetInt("GUNNER_LVL", 20);
		//PlayerPrefs.SetInt ("PlasmaLaserOnResistance", 1);

		PlayerPrefs.SetFloat("EVADEBOOSTER_SKILL", 1);



		//===================================================================================================================================================

		evadeOn = false;


		aimingReticle.speed = 1 - (PlayerPrefs.GetInt("GUNNER_LVL") * .02f);
		Debug.Log("player gunner skill is " + PlayerPrefs.GetInt("GUNNER_LVL"));
		Debug.Log (aimingReticle.speed + " is the speed");

		playerAnimator = GetComponent<Animator> ();

			
			




		diplomacyPanel.SetActive (false);
		glassCrack.enabled = false;
		frost.FrostAmount = 0f;
		if (PlayerHealth.playerHealth <= 20) {
			Debug.Log ("playerhealth is less than twenty...apparently");
			frost.enabled = true;
			glassCrack.enabled = true;
			frost.FrostAmount =.26f;

			Debug.Log ("frost enabled = " + frost.enabled);



		}

		shieldBarPanel.SetActive (false);

		//diplomacy = DiplomacyScript.FindObjectOfType<DiplomacyScript> ();
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
	battlecontroller =BattleControllerTurnBased.FindObjectOfType<BattleControllerTurnBased>();
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
			Debug.Log (shieldWait + " is shield wait");

			if (shieldWait == 20){
				Debug.Log (shieldWait + " is shield wait");
				shieldCharged = true;
				shieldWait = 0;
			} 
		}
		
		if (!repairCharged){
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
		
		if (battlecontroller.attackPoints > 0){
			
		}
		else if (battlecontroller.attackPoints < 1) {
			
			
		}		
	}
	//------------------------------------PRIMARY ATTACK BUTTON---------------------
	public void BtnPrimary(){
		if (battlecontroller.attackPoints >=50 && battlecontroller.playerTurn){
			aimingReticle.enabled = false;

			FirePrimary();
		}
		
	}
	
	
	
	
	//------------------------------------Plasma ATTACK BUTTON---------------------
	
	public void PlasmaLaserBtn(){
		if (battlecontroller.attackPoints >= 100 && battlecontroller.playerTurn){
			
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

			Debug.Log ("EVade after evade btn pushed is " + evade);


		}


	}
	
	//------------------------------------SHIELD BUTTON---------------------
	public void BtnShield(){
		if (battlecontroller.attackPoints >= 100 && battlecontroller.playerTurn && shieldCharged) {
			shield.SetActive(true);
			shieldCharged = false;
			shieldAnimator.SetTrigger ("ShieldOn");
			shieldOnAudio.Play ();
			shieldBarPanel.SetActive (true);


			float whichAudio = .5f;
			/*if (whichAudio > Random.value) {
				shield1.Play ();
			} else {
				shield2.Play ();
			}*/

			shieldOn = true;
			ShieldScript.shieldHealth = PlayerPrefs.GetFloat ("SHIELD_HEALTH");
			shieldBar.fillAmount = 1;
			battlecontroller.attackPoints = battlecontroller.attackPoints - 100;
			AttackPoints.fillAmount = battlecontroller.attackPoints * .01f;
			attackpoints.text= battlecontroller.attackPoints.ToString();

		}

	}
	
	public void ShieldCharge(){

		ShieldScript.shieldHealth = PlayerPrefs.GetFloat ("SHIELD_HEALTH");
		shieldBar.fillAmount = 1;
		
	}
	
	
	//------------------------------------REPAIR SKILL BUTTON---------------------
	
	
	public void RepairSkillBtn(){
		if (battlecontroller.attackPoints >= 100 && battlecontroller.playerTurn) {
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

			diplomacyPanel.SetActive (true);
			DiplomacyDialogue ();

		}
		diplomacyUsed = true;
	
	
	}



	
	
	public void FirePlasma(){
		if (battlecontroller.attackPoints >= 100 && battlecontroller.playerTurn && PlayerPrefs.GetInt("PlasmaLaserOnResistance") == 1  || PlayerPrefs.GetInt("ElectricBoltCannon") == 1) {
			BattleControllerTurnBased.firePrimary = true;
			battlecontroller.attackPoints = battlecontroller.attackPoints - 100;
			AttackPoints.fillAmount = battlecontroller.attackPoints * .01f;
			attackpoints.text= battlecontroller.attackPoints.ToString();
			moves += 1;
			if (moves == 1) {
				Move1.text = "Firing Plasma Weapon";

				aimingReticle.enabled = false;
				move1 = targetLocked.transform.position;
				Invoke ("ReEnableReticle", 1f);
				
			}
			if (moves == 2) {
				Move2.text = "Firing Plasma Weapon";

				aimingReticle.enabled = false;
				move2 = targetLocked.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}
			if (moves == 3) {
				Move3.text = "Firing Plasma Weapon";

				aimingReticle.enabled = false;
				move3 = targetLocked.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}
			if (moves == 4) {
				Move4.text = "Firing Plasma Weapon";

				aimingReticle.enabled = false;
				move4 = targetLocked.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}
			if (moves == 5) {
				Move5.text = "Firing Plasma Weapon";

				aimingReticle.enabled = false;
				move5 = targetLocked.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}
			if (moves == 6) {
				Move6.text = "Firing Plasma Weapon";

				aimingReticle.enabled = false;
				move6 = targetLocked.transform.position;
				Invoke ("ReEnableReticle", 1f);
			}
		}
	
	
	}
	
	void ReEnableReticle(){

		aimingReticle.enabled = true;

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
		if (moves == 1) {
			Move1.text = "Firing Primary Weapon";
			aimingReticle.enabled = false;
			move1 = targetLocked.transform.position;
			Invoke ("ReEnableReticle", 1f);

		
		}
		if (moves == 2) {
			Move2.text = "Firing Primary Weapon";

			aimingReticle.enabled = false;
			move2 = targetLocked.transform.position;
			Invoke ("ReEnableReticle", 1f);

		}
		if (moves == 3) {
			Move3.text = "Firing Primary Weapon";

			aimingReticle.enabled = false;
			move3 = targetLocked.transform.position;
			Invoke ("ReEnableReticle", 1f);
		}
		if (moves == 4) {
			Move4.text = "Firing Primary Weapon";

			aimingReticle.enabled = false;
			move4 = targetLocked.transform.position;
			Invoke ("ReEnableReticle", 1f);

		}
		if (moves == 5) {
			Move5.text = "Firing Primary Weapon";

			aimingReticle.enabled = false;
			move5 = targetLocked.transform.position;
			Invoke ("ReEnableReticle", 1f);

		}
		if (moves == 6) {
			Move6.text = "Firing Primary Weapon";

			aimingReticle.enabled = false;
			move6 = targetLocked.transform.position;
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
		if (battlecontroller.playerTurn){
			if (Move1.text == "Firing Primary Weapon") {
				FirePrimaryAtTurnEnd ();
				//Invoke ("FirePrimaryAtTurnEnd", 1);
				
				
			}
			if (Move1.text == "Firing Plasma Weapon") {
				FirePlasmaAtTurnEnd ();
			}
			
			
			if (Move2.text == "Firing Primary Weapon") {
				Invoke ("FirePrimaryAtTurnEnd", 1.5f);
				
			}
			if (Move2.text == "Firing Plasma Weapon") {
				Debug.Log ("MOVe1 is equal to plasma fire");
				Invoke ("FirePlasmaAtTurnEnd", 1.5f);
				}
			
			
			
			
			if (Move3.text== "Firing Primary Weapon") {
				Invoke ("FirePrimaryAtTurnEnd", 2);
				
			}
			if (Move3.text == "Firing Plasma Weapon") {
				
				Invoke ("FirePlasmaAtTurnEnd", 2f);
			}
			
			
			
			
			
			if (Move4.text == "Firing Primary Weapon") {
				Invoke ("FirePrimaryAtTurnEnd", 3);
				
			}
			if (Move4.text == "Firing Plasma Weapon") {
				
				Invoke ("FirePlasmaAtTurnEnd", 3f);
			}
			
			
			
			
			if (Move5.text == "Firing Primary Weapon") {
				Invoke ("FirePrimaryAtTurnEnd", 4);
				
			}
			if (Move5.text == "Firing Plasma Weapon") {
				
				Invoke ("FirePlasmaAtTurnEnd", 4f);
			}
			
			
			
			
			
			
			if (Move6.text == "Firing Primary Weapon") {
				Invoke ("FirePrimaryAtTurnEnd", 5);
				
				
			}	
			if (Move6.text == "Firing Plasma Weapon") {
				
				Invoke ("FirePlasmaAtTurnEnd", 5f);
			}
			battlecontroller.EndTurn();

		
		}
		





		
	
	}
	public void FirePrimaryAtTurnEnd(){




		if (move1 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move1 - transform.position).normalized * 90f;

			move1 = nullingTheVector;

			return;
		}

		if (move2 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move2 - transform.position).normalized * 90f;

			move2 = nullingTheVector;

			return;
		}

		if (move3 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move3 - transform.position).normalized * 90f;

			move3 = nullingTheVector;

			return;

		}

		if (move4 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move4 - transform.position).normalized * 90f;

			move4 = nullingTheVector;

			return;

		}

		if (move5 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move5 - transform.position).normalized * 90f;

			move5 = nullingTheVector;

			return;
		}


		if (move6 != nullingTheVector) {

			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);

			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;

			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);

			beam.GetComponent<Rigidbody> ().velocity = (move6 - transform.position).normalized * 90f;

			move6 = nullingTheVector;

			return;

		}

	


	

	



	










		/*

		
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "NGC1300BOSS") {
			Debug.Log ("FiringLaser at boss");
			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);
			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;
			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);
			//beam.GetComponent<Rigidbody>().velocity = new Vector3 (Boss.transform.position.x,Boss.transform.position.y,Boss.transform.position.z);

			beam.GetComponent<Rigidbody>().velocity = new Vector3 (Boss.transform.position.x, Boss.transform.position.y+ 1f,Boss.transform.position.z + 3f);
			//beam.GetComponent<Rigidbody>().velocity = new Vector3 (GameObject.Find("Boss").transform.position.x , GameObject.Find("Boss").transform.position.y, GameObject.Find("Boss").transform.position.z )* .05f;

			Debug.Log ("Boss transform position is " + Boss.transform.position.x + " " + Boss.transform.position.y + " " + Boss.transform.position.z);
		}
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "ShipSmallGreyDefault") {
			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);
			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;
			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);
			//beam.GetComponent<Rigidbody>().velocity = new Vector3 (enemyShip.transform.position.x,enemyShip.transform.position.y,enemyShip.transform.position.z + .5f);

			//beam.GetComponent<Rigidbody> ().velocity = new Vector3 (targetLocked.transform.position.x, targetLocked.transform.position.y, targetLocked.transform.position.z ) * 2f;

			beam.GetComponent<Rigidbody> ().velocity = (GameObject.Find ("AimingReticle").transform.position - transform.position).normalized * 90f;


		}
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "QuantumDefault") {
			Vector3 firePosition = transform.position + new Vector3 (0,-.7f,0);
			GameObject beam = Instantiate(basicLaser, firePosition, Quaternion.identity) as GameObject;
			beam.transform.rotation = Quaternion.AngleAxis (5.5f, Vector3.down);
			//beam.GetComponent<Rigidbody>().velocity = new Vector3 (quantumEnemy.transform.position.x,quantumEnemy.transform.position.y,quantumEnemy.transform.position.z);
		}*/

	}
	
	
	public void FirePlasmaAtTurnEnd(){

		if (PlayerPrefs.GetInt ("PlasmaLaserOnResistance") == 1) {
		

			if (move1 != nullingTheVector) {

				Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);

				GameObject plasma = Instantiate(plasmaLaser, firePosition, Quaternion.identity) as GameObject;

				plasma.GetComponent<Rigidbody> ().velocity = (move1 - transform.position).normalized * 90f;

				move1 = nullingTheVector;

				return;
			}

			if (move2 != nullingTheVector) {

				Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);

				GameObject plasma = Instantiate(plasmaLaser, firePosition, Quaternion.identity) as GameObject;

				plasma.GetComponent<Rigidbody> ().velocity = (move2 - transform.position).normalized * 90f;

				move2 = nullingTheVector;

				return;
			}

			if (move3 != nullingTheVector) {

				Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);

				GameObject plasma = Instantiate(plasmaLaser, firePosition, Quaternion.identity) as GameObject;

				plasma.GetComponent<Rigidbody> ().velocity = (move3 - transform.position).normalized * 90f;

				move3 = nullingTheVector;

				return;

			}

			if (move4 != nullingTheVector) {

				Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);

				GameObject plasma = Instantiate(plasmaLaser, firePosition, Quaternion.identity) as GameObject;

				plasma.GetComponent<Rigidbody> ().velocity = (move4 - transform.position).normalized * 90f;

				move4 = nullingTheVector;

				return;

			}

			if (move5 != nullingTheVector) {

				Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);

				GameObject plasma = Instantiate(plasmaLaser, firePosition, Quaternion.identity) as GameObject;

				plasma.GetComponent<Rigidbody> ().velocity = (move5 - transform.position).normalized * 90f;

				move5 = nullingTheVector;

				return;
			}


			if (move6 != nullingTheVector) {

				Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);

				GameObject plasma = Instantiate(plasmaLaser, firePosition, Quaternion.identity) as GameObject;

				plasma.GetComponent<Rigidbody> ().velocity = (move6 - transform.position).normalized * 90f;

				move6 = nullingTheVector;

				return;

			}
		
		
		}


		//====================================================== ELECTRIC BOLT WEAPON =====================================================================

		if (PlayerPrefs.GetInt ("ElectricBoltCannon") == 1) {
		
			if (move1 != nullingTheVector) {

				Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);

				GameObject electricbolt = Instantiate(electricBoltCannon, firePosition, Quaternion.identity) as GameObject;

				electricbolt.GetComponent<Rigidbody> ().velocity = (move1 - transform.position).normalized * 90f;

				move1 = nullingTheVector;

				return;
			}

			if (move2 != nullingTheVector) {

				Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);

				GameObject electricbolt = Instantiate(electricBoltCannon, firePosition, Quaternion.identity) as GameObject;

				electricbolt.GetComponent<Rigidbody> ().velocity = (move2 - transform.position).normalized * 90f;

				move2 = nullingTheVector;

				return;
			}

			if (move3 != nullingTheVector) {

				Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);

				GameObject electricbolt = Instantiate(electricBoltCannon, firePosition, Quaternion.identity) as GameObject;

				electricbolt.GetComponent<Rigidbody> ().velocity = (move3 - transform.position).normalized * 90f;

				move3 = nullingTheVector;

				return;

			}

			if (move4 != nullingTheVector) {

				Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);

				GameObject electricbolt = Instantiate(electricBoltCannon, firePosition, Quaternion.identity) as GameObject;

				electricbolt.GetComponent<Rigidbody> ().velocity = (move4 - transform.position).normalized * 90f;

				move4 = nullingTheVector;

				return;

			}

			if (move5 != nullingTheVector) {

				Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);

				GameObject electricbolt = Instantiate(electricBoltCannon, firePosition, Quaternion.identity) as GameObject;

				electricbolt.GetComponent<Rigidbody> ().velocity = (move5 - transform.position).normalized * 90f;

				move5 = nullingTheVector;

				return;
			}


			if (move6 != nullingTheVector) {

				Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);

				GameObject electricbolt = Instantiate(electricBoltCannon, firePosition, Quaternion.identity) as GameObject;

				electricbolt.GetComponent<Rigidbody> ().velocity = (move6 - transform.position).normalized * 90f;

				move6 = nullingTheVector;

				return;

			}
		
		}

		 /*
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "NGC1300BOSS" && PlayerPrefs.GetInt("PlasmaLaserOnResistance") == 1) {
			Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);
			GameObject plasma = Instantiate(plasmaLaser, firePosition, Quaternion.identity) as GameObject;
			plasma.GetComponent<Rigidbody>().velocity = new Vector3 (Boss.transform.position.x,Boss.transform.position.y,Boss.transform.position.z);
		}
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "ShipSmallGreyDefault" && PlayerPrefs.GetInt("PlasmaLaserOnResistance") == 1) {
			Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);
			GameObject plasma = Instantiate(plasmaLaser, firePosition, Quaternion.identity) as GameObject;
			plasma.GetComponent<Rigidbody>().velocity = new Vector3 (enemyShip.transform.position.x,enemyShip.transform.position.y,enemyShip.transform.position.z);
		}
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "QuantumDefault" && PlayerPrefs.GetInt("PlasmaLaserOnResistance") == 1) {
			Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);
			GameObject plasma = Instantiate(plasmaLaser, firePosition, Quaternion.identity) as GameObject;
			plasma.GetComponent<Rigidbody>().velocity = new Vector3 (quantumEnemy.transform.position.x,quantumEnemy.transform.position.y,quantumEnemy.transform.position.z);
		}


		//-----------------------------ELCTRIC BOLT CANNON-----------------------------------------------------


		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "NGC1300BOSS" && PlayerPrefs.GetInt("ElectricBoltCannon") == 1) {
			Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);
			GameObject electricbolt = Instantiate(electricBoltCannon, firePosition, Quaternion.identity) as GameObject;
			electricbolt.GetComponent<Rigidbody>().velocity = new Vector3 (Boss.transform.position.x,Boss.transform.position.y,Boss.transform.position.z);
		}
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "ShipSmallGreyDefault" && PlayerPrefs.GetInt("ElectricBoltCannon") == 1) {
			Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);
			GameObject electricbolt = Instantiate(electricBoltCannon, firePosition, Quaternion.identity) as GameObject;
			electricbolt.GetComponent<Rigidbody>().velocity = new Vector3 (Boss.transform.position.x,Boss.transform.position.y,Boss.transform.position.z);
		}
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "QuantumDefault" && PlayerPrefs.GetInt("ElectricBoltCannon") == 1) {
			Vector3 firePosition = transform.position + new Vector3 (0,-.5f,1.5f);
			GameObject electricbolt = Instantiate(electricBoltCannon, firePosition, Quaternion.identity) as GameObject;
			electricbolt.GetComponent<Rigidbody>().velocity = new Vector3 (Boss.transform.position.x,Boss.transform.position.y,Boss.transform.position.z);
		} */

		
	}




	//-----------------------------------------------------------------------------SKILLS BUTTONS EXTRA FUNCTIONS HERE ---------------------------------------------------------------

	public void DiplomacyDialogue(){



		diplomacy.StartDialog ();



	}
	
	
	
	
	
	
	
	
	
	
	//------------------------------------PLAYER DAMAGE TAKEN HERE---------------------
	void OnTriggerEnter(Collider collider){

		Vector3 enemyProjectilePos = collider.transform.position;

		EnemyBasicLaserScript enemylaserred = collider.gameObject.GetComponent<EnemyBasicLaserScript>();
		damage = EnemyBasicLaserScript.FindObjectOfType<EnemyBasicLaserScript>();

		RedRocketScript redrocket = collider.gameObject.GetComponent<RedRocketScript> ();
		redRocketDamage = RedRocketScript.FindObjectOfType<RedRocketScript> ();

		float chanceEnemyHit = Random.Range(1,85);
		Debug.Log("Evade is " + evade);
		
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
			
			
			
			
			
			
		if (ShieldScript.shieldHealth <= 0 ){
			Debug.Log ("Shield HEalth is : " + ShieldScript.shieldHealth);

			shieldOn = false;
			shieldOffAudio.Play ();
			shieldBarPanel.SetActive (false);
		
			shieldAnimator.SetTrigger ("ShieldOff");
		
			shield.SetActive(false);
			ShieldCharge();
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

			GameObject redLaserHit = Instantiate (EnemyImpactRedLaser, enemyProjectilePos, Quaternion.identity) as GameObject;

			
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









		if (ShieldScript.shieldHealth <= 0 ){
			Debug.Log ("Shield HEalth is : " + ShieldScript.shieldHealth);
			shieldOn = false;
			shield.SetActive(false);
			ShieldCharge();
		}
		
		if (redrocket && !shieldOn && chanceEnemyHit > evade && !deflectorShieldOn){
			playerhealth.LoseHealth(redRocketDamage.damage);

			GameObject redrocketHit = Instantiate (redRocketHit, enemyProjectilePos, Quaternion.identity) as GameObject;



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







	///------------------------------------------------------------ANIMATION EVENTS --------------------------------------------------------------------------
	/// 
	/// 
	/// 
	/// 

	
}
