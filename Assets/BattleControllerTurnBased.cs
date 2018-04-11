using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleControllerTurnBased : MonoBehaviour {

	public Text statusText;

	public GameObject statusTextPanel;

	Animator animator;







	public static bool firePrimary;
	public static bool useShield;

	public static bool enemyFlee = false;

	public static bool playerFlee = false;

	private PlayerHealth shipHealth;

	Music music;

	int hasDoneAnimation=0;

	public GameObject aimingReticle;




	//public GameObject EnemyLaserRedWeapon;




	public int attackPoints = 100;
	float enemyattackpoints = 100;

	public bool playerTurn = false;







	RTSBattleController playercontroller;
	//EnemyFireAndDamage enemycontroller;



	void Start () {

		animator = statusTextPanel.GetComponent<Animator> ();

		music = Music.FindObjectOfType<Music> ();

		//music.BattleClip ();
		//StartPlayerTurn();
		enemyFlee = false;
		playerFlee = false;

		attackPoints = PlayerPrefs.GetInt("PLAYER_AP");
		playercontroller = RTSBattleController.FindObjectOfType<RTSBattleController>();





	}

	void Update () {
		if (playerTurn && !playerFlee){
			
			StartPlayerTurn();

			//EndTurn();
		}
		if (!playerTurn && !enemyFlee){

			StartEnemyTurn();
		}

		if (!playerTurn && enemyFlee) {
		
			
		
		}
		


	}







	public void EndTurn(){

		if (RTSBattleController.shieldCharged == false){
			RTSBattleController.shieldWait += 1;
		}
		if (RTSBattleController.repairCharged == false){
			RTSBattleController.repairWait += 1;
		}
		if (RTSBattleController.shieldDeflectorCharged == false){
			RTSBattleController.shieldDeflectorWait += 1;
		}
		if (PlayerAttackScriptMultipleEnemies.evadeCharged == false){
			PlayerAttackScriptMultipleEnemies.evadeWait += 1;
		}
		
		
		attackPoints = PlayerPrefs.GetInt("PLAYER_AP");
		enemyattackpoints = 100;
		playercontroller.moves = 0;
		playercontroller.Move1.text = "";
		playercontroller.Move2.text = "";
		playercontroller.Move3.text = "";
		playercontroller.Move4.text = "";
		playercontroller.Move5.text = "";
		playercontroller.Move6.text = "";


		playerTurn = !playerTurn;
		if (playerTurn){
			RTSBattleController.weaponIsCharged = false;
			StartPlayerTurn();
		}
		else {
			playercontroller.weaponCharge.SetActive (false);

			StartEnemyTurn();
		}



	}


	public void StartPlayerTurn(){



		statusText.text = "Your turn Captain!";

		if (hasDoneAnimation == 0) {

			aimingReticle.SetActive (true);
			
//			animator.SetTrigger ("nextTurn");

			hasDoneAnimation = 1;
		
		}
		playercontroller.attackpoints.text = attackPoints.ToString();
		playercontroller.evade = PlayerPrefs.GetFloat("EVADE");
		playercontroller.PlayerFight();


	}

	void StartEnemyTurn(){
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "NGC1300BOSS") {
			EnemyFIreAndDamageBoss enemycontroller = EnemyFIreAndDamageBoss.FindObjectOfType<EnemyFIreAndDamageBoss> ();
			enemycontroller.EnemyTurn();
		}
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "ShipSmallGreyDefault") {
			EnemyFireAndDamage enemycontroller = EnemyFireAndDamage.FindObjectOfType<EnemyFireAndDamage>();
			enemycontroller.EnemyTurn();
		}
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "QuantumDefault") {
			EnemyFireAndDamage enemycontroller = EnemyFireAndDamage.FindObjectOfType<EnemyFireAndDamage>();
			enemycontroller.EnemyTurn();
		}
		statusText.text = "Enemy Turn, Prepare Yourself!";

		if (hasDoneAnimation == 1) {

//			animator.SetTrigger ("nextTurn");

			aimingReticle.SetActive (false);

			hasDoneAnimation = 0;

		}

		//enemycontroller.EnemyTurn();

	}




































}
