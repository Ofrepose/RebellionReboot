using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleControllerTurnBasedMultipleScript : MonoBehaviour {


	//TEXT COMPONENTS
	public Text statusText;
	public GameObject statusTextPanel;
	Animator animator;
	int hasDoneAnimation=0;



	//Player Components
	public static bool firePrimary;
	public static bool useShield;

	public static bool playerFlee = false;

	private PlayerHealth shipHealth;
	PlayerAttackScriptMultipleEnemies playerController;

	XP xp;


	//Enemy Components
	public static bool enemyFlee = false;
	public static bool enemy2Flee = false;

	public TwoEnemiesAttackingScript pirate1;
	public TwoEnemiesAttackingScript pirate2;

	SelectEnemyScript selectorEnemy1;
	SelectEnemy2Script selectorEnemy2;

	public static bool enemy1Dead = false;

	public static bool enemy2Dead = false;




	//OTHER COMPONENTS
	Music music;


	//TURN BASED CONTROLLERS

	public int attackPoints = 100;
	float enemyAttackPoints = 100;
	float enemyAttackPoints2 = 100;

	public bool playerTurn = false;
	public bool enemyTurn1 = false;
	public bool enemyTurn2 = false;

	public static bool doneFighting = false;

	public GameObject aimingReticle;

	public GameObject aimingReticle2;




	void Start(){

		xp = XP.FindObjectOfType<XP> ();

		selectorEnemy1 = SelectEnemyScript.FindObjectOfType<SelectEnemyScript> ();
		selectorEnemy2 = SelectEnemy2Script.FindObjectOfType<SelectEnemy2Script> ();

		animator = statusTextPanel.GetComponent<Animator> ();

		music = Music.FindObjectOfType<Music> ();

		//TURN THIS OFF WHEN BUILDING
		//music.BattleClip ();

		enemyFlee = false;
		playerFlee = false;

		attackPoints = PlayerPrefs.GetInt("PLAYER_AP");

		playerController = PlayerAttackScriptMultipleEnemies.FindObjectOfType<PlayerAttackScriptMultipleEnemies>();

		xp.UpdateDisplay ();

		playerTurn = true;

	}



	void Update(){

		if (selectorEnemy1 == null) {
		
			selectorEnemy1 = SelectEnemyScript.FindObjectOfType<SelectEnemyScript> ();

		
		}

		if (selectorEnemy2 == null) {
		
			selectorEnemy2 = SelectEnemy2Script.FindObjectOfType<SelectEnemy2Script> ();

		
		}

		Debug.Log ("Player evade is " + playerController.evadeOn);

		if (playerTurn && !playerFlee && !enemyTurn1 && !enemyTurn2 && !doneFighting) {

			playerController.playerAnimator.SetBool ("Evade", false);

		
			StartPlayerTurn ();
		
		} 

		if (!playerTurn && enemyTurn1 && !enemyTurn2  && !doneFighting) {

			selectorEnemy1.selected.SetActive (false);
			selectorEnemy2.selected2.SetActive (false);
			SelectEnemyScript.enemy1Selected = false;
			SelectEnemy2Script.enemy2Selected = false;

			aimingReticle.SetActive (false);
			aimingReticle2.SetActive (false);


			if (pirate1.thisAiDead) {

				playerController.playerAnimator.SetBool ("Evade", false);


				EndTurn ();

			}
		
			StartEnemy1Turn ();

		}

		if (!playerTurn && !enemyTurn1 && enemyTurn2  && !doneFighting) {

			aimingReticle.SetActive (false);
			aimingReticle2.SetActive (false);

			selectorEnemy1.selected.SetActive (false);
			selectorEnemy2.selected2.SetActive (false);
			SelectEnemyScript.enemy1Selected = false;
			SelectEnemy2Script.enemy2Selected = false;

			if (pirate2.thisAiDead) {

				playerController.playerAnimator.SetBool ("Evade", false);

			
				EndTurn ();

			}

			StartEnemy2Turn ();

		}

		if (doneFighting) {
		
		
		
		}



	}



	void StartEnemy1Turn(){

		Debug.Log ("Inside start enemy 1 turn");

		//TwoEnemiesAttackingScript pirate1 = Pirate1Script.FindObjectOfType<TwoEnemiesAttackingScript> ();

		pirate1.EnemyTurn ();

		statusText.text = "Enemy Turn, Prepare Yourself!";

		if (hasDoneAnimation == 1) {

			animator.SetTrigger ("nextTurn");

			hasDoneAnimation = 0;

		}

	}




	void StartEnemy2Turn(){

		Debug.Log ("Inside start enemy 2 turn");

		//TwoEnemiesAttackingScript pirate2 = Pirate2Script.FindObjectOfType<TwoEnemiesAttackingScript> ();


		//TwoEnemiesAttackingScript pirate2 = GameObject.FindGameObjectWithTag ("Enemy2").GetComponent<TwoEnemiesAttackingScript> ();

		pirate2.EnemyTurn ();

		statusText.text = "Enemy Turn, Prepare Yourself!";

		if (hasDoneAnimation == 1) {

			animator.SetTrigger ("nextTurn");

			hasDoneAnimation = 0;

		}

	}




	public void StartPlayerTurn(){
		statusText.text = "Your turn Captain!";


		if (hasDoneAnimation == 0) {

			animator.SetTrigger ("nextTurn");

			hasDoneAnimation = 1;

		}
		playerController.attackpoints.text = attackPoints.ToString();
		playerController.evade = PlayerPrefs.GetFloat("EVADE");
		playerController.PlayerFight();


	}




	public void EndTurn(){

		if (playerTurn && !enemyTurn1 && !enemyTurn2) {
		
			if (PlayerAttackScriptMultipleEnemies.shieldCharged == false){
				PlayerAttackScriptMultipleEnemies.shieldWait += 1;
			}
			if (PlayerAttackScriptMultipleEnemies.repairCharged == false){
				PlayerAttackScriptMultipleEnemies.repairWait += 1;
			}
			if (PlayerAttackScriptMultipleEnemies.shieldDeflectorCharged == false){
				PlayerAttackScriptMultipleEnemies.shieldDeflectorWait += 1;
			}
			if (PlayerAttackScriptMultipleEnemies.evadeCharged == false){
				PlayerAttackScriptMultipleEnemies.evadeWait += 1;
			}



			attackPoints = PlayerPrefs.GetInt("PLAYER_AP");

			playerController.moves = 0;
			playerController.Move1.text = "";
			playerController.Move2.text = "";
			playerController.Move3.text = "";
			playerController.Move4.text = "";
			playerController.Move5.text = "";
			playerController.Move6.text = "";

			playerTurn = false;
			enemyTurn1 = true;
			enemyTurn2 = false;
			return;

		
		}

		if (!playerTurn && enemyTurn1 && !enemyTurn2) {
		
			enemyAttackPoints = 100;
			playerTurn = false;
			enemyTurn1 = false;
			enemyTurn2 = true;
			if (pirate2.thisAiDead) {

				playerController.evadeOn = false;


			}
			return;


		
		}

		if (!playerTurn && !enemyTurn1 && enemyTurn2) {
		
			enemyAttackPoints2 = 100;
			playerTurn = true;
			enemyTurn1 = false;
			enemyTurn2 = false;
			playerController.evadeOn = false;
			return;



		
		}


		//CHANGING TURNS

		/*if (playerTurn && !enemyTurn1 && !enemyTurn2) {
		
			playerTurn = false;
			enemyTurn1 = true;
			enemyTurn2 = false;
			return;
		
		}

		if (!playerTurn && enemyTurn1 && !enemyTurn2) {

			playerTurn = false;
			enemyTurn1 = false;
			enemyTurn2 = true;
			return;

		}

		if (!playerTurn && !enemyTurn1 && enemyTurn2) {

			playerTurn = true;
			enemyTurn1 = false;
			enemyTurn2 = false;
			return;

		} */
	
	}



}
