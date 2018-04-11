using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiplomacyScript : MonoBehaviour {

	public GameObject diplomacyPanel;

	public GameObject yourDialogPanel;

	public GameObject enemyDialogPanel;

	public GameObject yourAnswerPanel1;

	public GameObject yourAnswerPanel2;

	public GameObject yourAnswerPanel3;

	public Text yourDialog;

	public Text enemyDialog;

	public Text yourAnswer1;

	public Text yourAnswer2;

	public Text yourAnswer3;

	int differentGreetings;

	int enemyGreetingsHostile;

	public int chanceOfDipolomacyWorking;


	//Other Scripts Needed

	EnemyFireAndDamage enemyScript;


	void Start () {

		//chanceOfDipolomacyWorking = 5;

		Text yourDialog = GetComponent<Text> ();

		Text yourAnswer1 = GetComponent<Text> ();

		Text yourAnswer2 = GetComponent<Text> ();

		Text yourAnswer3 = GetComponent<Text> ();

		Text enemyDialog = GetComponent<Text> ();

		yourAnswerPanel1.SetActive (false);

		yourAnswerPanel2.SetActive (false);

		yourAnswerPanel3.SetActive (false);

		diplomacyPanel.SetActive (false);

		yourDialogPanel.SetActive (false);

		enemyDialogPanel.SetActive (false);

		enemyScript = EnemyFireAndDamage.FindObjectOfType<EnemyFireAndDamage> ();
		
	}

	public void StartDialog(){

		diplomacyPanel.SetActive (true);

		yourDialogPanel.SetActive (true);

		enemyDialogPanel.SetActive (false);

		differentGreetings = Random.Range (0, 4);

		Debug.Log ("greeting number is " + differentGreetings);

		if (differentGreetings == 0) {
		
			yourDialog.text = "Enemy Vessel!... I am Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + " I have a proposal for you!";
		
		}

		if (differentGreetings == 1) {

			yourDialog.text = ".....Attention wayward Vessel, we are not your enemy!......";

		}

		if (differentGreetings == 2) {

			yourDialog.text = "This is Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + " , Please Respond!";

		}

		if (differentGreetings == 3) {

			yourDialog.text = "This is Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + ", let us discuss this!";

		}

		if (differentGreetings == 4) {

			yourDialog.text = "Attacker, we mean you no harm! I am Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + ", let me speak to your Commander";

		}

		if (differentGreetings == 5) {

			yourDialog.text = "This is Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + " of vessel " + PlayerPrefs.GetString ("SHIP_CHOICE") + ". Let us handle this diplomatically!";

		}

		if (differentGreetings == 6) {

			yourDialog.text = "I am Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + " of vessel " + PlayerPrefs.GetString ("SHIP_CHOICE") + ". Please respond!";

		}

		enemyDialogPanel.SetActive (true);

		Invoke ("EnemyInitialResponse", 5f);

	
		
	
	}

	public void EnemyInitialResponse(){

		Debug.Log (enemyScript.EnemyHealth + " is the enemy health");
		Debug.Log (chanceOfDipolomacyWorking + " is the chance for diplomacy");

		Debug.Log (PlayerPrefs.GetFloat ("Diplomacy") + " is the diplomacy level");

		float health = enemyScript.EnemyHealth;

		if (health <60  && PlayerPrefs.GetFloat ("Diplomacy") < 5f) {

			chanceOfDipolomacyWorking = 1;

			EnemyResponsePossibleChance ();		

		}

		if (health > 90f && PlayerPrefs.GetFloat ("Diplomacy") < 10f) {

			chanceOfDipolomacyWorking = 0;

			EnemyResponseNoChance ();
		} else {
		
			chanceOfDipolomacyWorking = 1;
			EnemyResponsePossibleChance ();
		
		}


	}


	public void EnemyResponseNoChance (){
		
	
			enemyGreetingsHostile = Random.Range (0, 4);

			Debug.Log ("enemyGreeting Hostile is " + enemyGreetingsHostile);

			if (differentGreetings == 0) {

				if (enemyGreetingsHostile == 0) {

					Debug.Log ("Should print enemy dialog");

					enemyDialog.text = "Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + " no proposal would interest us! Surrender your Vessel or be destroyed!";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + " unless you propose to Surrender your Ship and Crew, we are not interested!";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "HA HA! There is nothing that you could propose that would deter us from ripping your ship apart. You do not worry us little Captain " + PlayerPrefs.GetString ("PLAYER_NAME");

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "We have never heard the name, Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + ". Prepare your ship for Battle!";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "Ah, it is Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + " you say?!....Never heard of you! Prepare to be Destroyed!";

				}


			}

			if (differentGreetings == 1) {

				if (enemyGreetingsHostile == 0) {

					enemyDialog.text = "It is for us to decide who are enemy is! Your ship will make a fine trophy!";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Not our enemy you say?! Well, we are yours!";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "Enemy or not, you are in our vector and as such you must be destroyed! Surrender your Ship and Crew Now!!";

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "We have orders to dismantle your ship. Enemy or not you must be eliminated!";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "*silence*";

				}


			}

			if (differentGreetings == 2) {

				if (enemyGreetingsHostile == 0) {

					enemyDialog.text = "Greetings Captain " +  PlayerPrefs.GetString ("PLAYER_NAME")  + " please retreat or prepare to be destroyed!";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Captain " +  PlayerPrefs.GetString ("PLAYER_NAME")  + " this is your death speaking, surrender now!";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "Your name is irrelevant, Captain " +  PlayerPrefs.GetString ("PLAYER_NAME")  + ". ";

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "*Silence*";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "Ah, Captain " +  PlayerPrefs.GetString ("PLAYER_NAME")  + ". You may want to keep the line open to send out your distress signal, surrender or be destroyed!";

				}

			}

			if (differentGreetings == 3) {

				if (enemyGreetingsHostile == 0) {

					enemyDialog.text = "There is nothing to discuss, Captain!";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Unless you wish to discuss you surrender, prepare to be destroyed!";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "Leave that dicussing to your God!";

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "*Silence*";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "Go ahead Captain, discuss away. *unintelligible* Fire at enemy Ship!!";

				}

			}

			if (differentGreetings == 4 || differentGreetings == 3) {

				if (enemyGreetingsHostile == 0) {

					enemyDialog.text = "We are not diplomats! We are Soldiers, prepare yourselves!";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Diplomacy means nothing to us!";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "Your words have no weight with us!";

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "We will not succum to your words! Prepare your ship, Captain!";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "There is nothing that can deter us, Captain!";

				}

			}

			Invoke ("FirstResponseToHostileEnemy", 2f);


			///DEFAULT ENEMY GREETINGS HOSTILE!


		}




	public void EnemyResponsePossibleChance (){
	
		int chanceOfWorking = Random.Range (1, 50);

		if (chanceOfWorking >= 25) {
			if (differentGreetings == 0) {

				if (enemyGreetingsHostile == 0) {

					enemyDialog.text = "Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + " we will listen to your proposal!";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + ", please do not destroy us, we will listen!";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "Perhaps it would benefit us to listen, Captain " + PlayerPrefs.GetString ("PLAYER_NAME");

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "We have never heard the name, Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + ". What do you propose?";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "Ah, it is Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + " you say?!....Go on..";

				}


			}

			if (differentGreetings == 1) {

				if (enemyGreetingsHostile == 0) {

					enemyDialog.text = "Enemy or not, why should we spare you?";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Not our enemy you say?! What is it you want?!";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "Enemy or not, you are in our vector and as such you must be destroyed! Why should we spare you?";

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "We have orders to dismantle your ship. Why should we disobey our leadership?!";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "*We are listening...*";

				}


			}

			if (differentGreetings == 2) {

				if (enemyGreetingsHostile == 0) {

					enemyDialog.text = "Greetings Captain " +  PlayerPrefs.GetString ("PLAYER_NAME")  + " please make it brief..";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Captain " +  PlayerPrefs.GetString ("PLAYER_NAME")  + " what is it you want?";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "Your name is unimportant, Captain " +  PlayerPrefs.GetString ("PLAYER_NAME")  + ". All that matters is what you have to offer us!";

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "*Go on....*";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "Ah, Captain " +  PlayerPrefs.GetString ("PLAYER_NAME")  + ". What do you want with us?";

				}

			}

			if (differentGreetings == 3) {

				if (enemyGreetingsHostile == 0) {

					enemyDialog.text = "What would you like to discuss, Captain?";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Unless you wish to discuss you surrender, I doubt we will listen... but go ahead and try!";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "Continue, Captain....";

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "*We are listening...*";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "Go ahead Captain, discuss away. *unintelligible* ";

				}

			}

			if (differentGreetings == 4 || differentGreetings == 3) {

				if (enemyGreetingsHostile == 0) {

					enemyDialog.text = "We are not diplomats! We are Soldiers, what common ground can we find?!";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Diplomacy is not in our blood, but we will hear you out!";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "Your words had better be good!";

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "What is it you want Captain?!";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "You think diplomacy will deter us?! Go on...";

				}

			}

			Invoke ("FirstResponseToHostileEnemy", 2f);		
		}




		if (chanceOfWorking < 25) {
			#region
			if (differentGreetings == 0) {

				if (enemyGreetingsHostile == 0) {

					Debug.Log ("Should print enemy dialog");

					enemyDialog.text = "Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + " no proposal would interest us! Surrender your Vessel or be destroyed!";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + " unless you propose to Surrender your Ship and Crew, we are not interested!";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "HA HA! There is nothing that you could propose that would deter us from ripping your ship apart. You do not worry us little Captain " + PlayerPrefs.GetString ("PLAYER_NAME");

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "We have never heard the name, Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + ". Prepare your ship for Battle!";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "Ah, it is Captain " + PlayerPrefs.GetString ("PLAYER_NAME") + " you say?!....Never heard of you! Prepare to be Destroyed!";

				}


			}

			if (differentGreetings == 1) {

				if (enemyGreetingsHostile == 0) {

					enemyDialog.text = "It is for us to decide who are enemy is! Your ship will make a fine trophy!";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Not our enemy you say?! Well, we are yours!";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "Enemy or not, you are in our vector and as such you must be destroyed! Surrender your Ship and Crew Now!!";

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "We have orders to dismantle your ship. Enemy or not you must be eliminated!";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "*silence*";

				}


			}

			if (differentGreetings == 2) {

				if (enemyGreetingsHostile == 0) {

					enemyDialog.text = "Greetings Captain " +  PlayerPrefs.GetString ("PLAYER_NAME")  + " please retreat or prepare to be destroyed!";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Captain " +  PlayerPrefs.GetString ("PLAYER_NAME")  + " this is your death speaking, surrender now!";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "Your name is irrelevant, Captain " +  PlayerPrefs.GetString ("PLAYER_NAME")  + ". ";

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "*Silence*";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "Ah, Captain " +  PlayerPrefs.GetString ("PLAYER_NAME")  + ". You may want to keep the line open to send out your distress signal, surrender or be destroyed!";

				}

			}

			if (differentGreetings == 3) {

				if (enemyGreetingsHostile == 0) {

					enemyDialog.text = "There is nothing to discuss, Captain!";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Unless you wish to discuss you surrender, prepare to be destroyed!";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "Leave that dicussing to your God!";

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "*Silence*";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "Go ahead Captain, discuss away. *unintelligible* Fire at enemy Ship!!";

				}

			}

			if (differentGreetings == 4 || differentGreetings == 3) {

				if (enemyGreetingsHostile == 0) {

					enemyDialog.text = "We are not diplomats! We are Soldiers, prepare yourselves!";

				}

				if (enemyGreetingsHostile == 1) {

					enemyDialog.text = "Diplomacy means nothing to us!";

				}

				if (enemyGreetingsHostile == 2) {

					enemyDialog.text = "Your words have no weight with us!";

				}

				if (enemyGreetingsHostile == 3) {

					enemyDialog.text = "We will not succum to your words! Prepare your ship, Captain!";

				}

				if (enemyGreetingsHostile == 4) {

					enemyDialog.text = "There is nothing that can deter us, Captain!";

				}

			}
			#endregion //code is hidden in region. expand to investigate
		
		
		
		}
	
	
	
	}
	









	public void FirstResponseToHostileEnemy(){

		Debug.Log ("Chance diplomacy working is " + chanceOfDipolomacyWorking);

		if (chanceOfDipolomacyWorking == 0) {
		
			yourAnswerPanel1.SetActive (true);

			yourAnswerPanel2.SetActive (true);

			yourAnswerPanel3.SetActive (true);

			yourAnswer1.text = "You will regret this!";

			yourAnswer2.text = "You will learn to fear my name!";

			yourAnswer3.text = "*End Transmission*";
		
		}

		if (chanceOfDipolomacyWorking == 1) {
		
			yourAnswerPanel1.SetActive (true);

			yourAnswerPanel2.SetActive (true);

			yourAnswerPanel3.SetActive (true);

			yourAnswer1.text = "We have no fight with you. Let us both go in Peace!";

			yourAnswer2.text = "Blood will do neither of us any good, let us leave!";

			yourAnswer3.text = "We are not here for a fight, let us part ways!";
		
		}
	
	
	
	}





	//-------------------------------------------------ANSWERS-------------------------------------------

	public void HostileEnemyOne(){

		int chanceOfWorking = Random.Range (1, 50);
		if (chanceOfDipolomacyWorking == 0) {
		
			diplomacyPanel.SetActive (false);
		
		}

		if (chanceOfDipolomacyWorking == 1) {

			if (chanceOfWorking >= 25) {

				yourAnswerPanel1.SetActive (false);

				yourAnswerPanel2.SetActive (false);

				yourAnswerPanel3.SetActive (false);


				Invoke ("BeginFleeDialog", 5f);
			
			}

			if (chanceOfWorking < 25) {
			
				diplomacyPanel.SetActive (false);
			
			}
		
		}
	
	}


	public void HostileEnemyTwo(){

		int chanceOfWorking = Random.Range (1, 50);
		if (chanceOfDipolomacyWorking == 0) {

			diplomacyPanel.SetActive (false);

		}

		if (chanceOfDipolomacyWorking == 1) {

			if (chanceOfWorking >= 25) {

				yourAnswerPanel1.SetActive (false);

				yourAnswerPanel2.SetActive (false);

				yourAnswerPanel3.SetActive (false);

				Invoke ("BeginFleeDialog", 5f);

			}

			if (chanceOfWorking < 25) {

				diplomacyPanel.SetActive (false);

			}

		}


	}

	public void HostileEnemyThree(){

		int chanceOfWorking = Random.Range (1, 50);
		if (chanceOfDipolomacyWorking == 0) {

			diplomacyPanel.SetActive (false);

		}

		if (chanceOfDipolomacyWorking == 1) {

			if (chanceOfWorking >= 25) {

				yourAnswerPanel1.SetActive (false);

				yourAnswerPanel2.SetActive (false);

				yourAnswerPanel3.SetActive (false);

				Invoke ("BeginFleeDialog", 5f);

			}

			if (chanceOfWorking < 25) {

				diplomacyPanel.SetActive (false);

			}

		}

	}






	//---------------------------------------------FLEE DIALOG-------------------------------

	public void BeginFleeDialog(){
	
		enemyDialog.text = "Please Forgive us, Captain.";

		BattleControllerTurnBased.enemyFlee = true;
	
	
	}

}