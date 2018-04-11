using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour {


//PLAYER NAME
	
	public static string playerName;
	/*public static string crewMate1;
	public static string crewMate2;
	public static string crewMate3;*/
	NewGameScript newGameScript;
	
//SHIP 
	public static string shipChoice;
	
	public static string shipType;
	public static string Weapon1;
	
//XP
	public static int XP;
	public static int Level;

	public static int Credits;
	
//SKILLS
	public static int SkillPoints;

	public static float evade;
	public static float Speed;
	public static float Repair;
	public static float ShieldBooster;
	public static float ShieldDeflector;
	
	public static float Diplomacy;
	public static float Confusion;
	public static float TrickToRepair;
	public static float Convert;
	
	public static float EvadeBoost;
	public static float ShieldOverload;
	public static float Intimidate;
	public static float weaponsOverload;
	
	
	

//PlayerLocation
	public static string playerLocation;
	public static string where;
	
	float thisX;
	float thisY;
	float thisZ;
	
	
//Player Location in System
	
	private bool hasResetAlready= false;
	
	
//Faction Reputation
public static float NovaReputation = -3f;
public static float QuantumCorpReputation = -4f;


	public GameObject playership;
	public static bool isSilverhawk;
	public GameObject silverhawk;
	public GameObject resistance;
	
	//Weapons
	//public GameObject PlasmaLaserOnSilverHawk;
	public static int plasmalaseronsilverhawk;
	
	//public GameObject PlasmaLaserOnResistance;
	public static int plasmalaseronresistance;
	

	

	


	void Start () {
		
			
		//GameObject resistance = GameObject.FindWithTag("RESISTANCE")as GameObject;
		//GameObject silverhawk = GameObject.FindWithTag("SILVERHAWK")as GameObject;
		if (PlayerPrefs.GetString("SHIP_CHOICE") == "SILVERHAWK"){
			isSilverhawk =  true;
			
			
		}
		if (PlayerPrefs.GetString("SHIP_CHOICE") == "RESISTANCE"){
			isSilverhawk = false;
		}
		
	
		Debug.Log("where inside character is " + where);
		if (EnemyFireAndDamage.justWon == true /*|| where == "nope"*/){
			//CreatePlayerShip();
			EnemyFireAndDamage.justWon = false;
		}
		
		
		//DontDestroyOnLoad(transform.gameObject);
		newGameScript = NewGameScript.FindObjectOfType<NewGameScript>();
		hasResetAlready = false;
		Debug.Log("Has reset already in start is " + hasResetAlready);
		XP = PlayerPrefs.GetInt("PLAYER_XP");
		Level = PlayerPrefs.GetInt("PLAYER_LEVEL");
		Weapon1 = 	PlayerPrefs.GetString("PRIMARY_WEAPON");
		Credits = PlayerPrefs.GetInt ("PLAYER_CREDITS");
		if (isSilverhawk){
			silverhawk.SetActive(true);
			resistance.SetActive(false);
			
			
		}
		if (isSilverhawk == false){
			silverhawk.SetActive(false);
			resistance.SetActive(true);
			if (PlayerPrefs.GetInt("PlasmaLaserOnResistance") == 1){
				//PlasmaLaserOnResistance.SetActive(true);
			}
			
		}

	
	
	
	}
	



//-------------------------------------------------PLAYER SHIP----------\


	public void CreatePlayerShip(){
		
		//jumpingIn = true;
		//playerShip.SetActive(true);
		thisX = PlayerPrefs.GetFloat("PLAYER_POSITION_NOW_X");
		thisZ = PlayerPrefs.GetFloat("PLAYER_POSITION_NOW_Z");
		thisY = PlayerPrefs.GetFloat("PLAYER_POSITION_NOW_Y");
		Debug.Log ("Transform position inside character create player is  " + thisX + ", " + thisY + ", " + thisZ);
		Vector3 startPosition1 = new Vector3(thisX, thisY, thisZ);
		//jumpGate.CreateJumpOutEffect();
		GameObject playershipJumped = Instantiate( playership, startPosition1, Quaternion.identity) as GameObject;

	}
	
	//---------------------------------------CHARACTER SKILLS----------------------------------------------
	
	
	
	
	
	//---------------------------------------SAVE ALL AFTER CHARACTER SETU----------------------------------------------
	
	
	
	
	//---------------------------------------SAVE ALL TO PLAYERPREFS NEW GAME----------------------------------------------
	public void SaveToPrefs(){
		PlayerPrefs.SetString("PLAYER_NAME", playerName);
		//PlayerPrefs.SetString ("CREWMATE_1", crewMate1);
		PlayerPrefs.SetFloat("NOVA_REP", NovaReputation);
		//PlayerPrefs.SetFloat("PLAYER_HEALTH", PlayerHealth.playerHealth);
		PlayerPrefs.SetInt ("NGC1300hasBeenVisitedSaved", 0);
		PlayerPrefs.SetInt("NGC1300hasBeenScannedSaved", 0);
		PlayerPrefs.SetInt("NGC1300_BEACONDONE", 0);
		PlayerPrefs.SetInt ("BOSS_FIGHT_NGC1300_DONE", 0); 


		PlayerPrefs.SetString("NGC1300_FACTION_CONTROL", "NOVA");
		
		PlayerPrefs.SetInt ("GNZ11hasBeenVisitedSaved", 0);
		PlayerPrefs.SetInt("GNZ11hasBeenScannedSaved", 0);
		PlayerPrefs.SetString("GNZ11_FACTION_CONTROL", "QUANTUMCORP");
		
		PlayerPrefs.SetString ("PLAYER_LOCATION", "Null");
		//PlayerPrefs.SetInt("PLAYER_HEALTH", 100);
		//PlayerPrefs.SetInt("PLAYER_XP", 0);
		//PlayerPrefs.SetInt("PLAYER_LEVEL", 1);
		PlayerPrefs.SetString("PRIMARY_WEAPON", "SMALL_LASER");
		PlayerPrefs.SetFloat("QUANTUMCORP_REP", QuantumCorpReputation);
		PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_X", 26.55f);
		PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_Z", 46.85f);
		PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_Y", 0f);
		Character.where = "nope";
		//PlayerPrefs.SetString("SHIP_CHOICE", "RESISTANCE");
		PlayerPrefs.SetString("SHIP_CHOICE", shipChoice);
		PlayerPrefs.SetFloat("SHIP_SPEED", 1f);
		
		PlayerPrefs.SetInt("PLAYER_XP_FILL", 0);
		PlayerPrefs.SetInt ("HAS_XP", 0);
		PlayerPrefs.SetInt("PLAYER_XP",0);
		PlayerPrefs.SetInt("PLAYER_LEVEL",1);
		PlayerPrefs.SetInt ("PLAYER_CREDITS", 0);
		PlayerPrefs.SetFloat ("XP_MULTIPLYBY",.01f);
		PlayerPrefs.SetInt ("XP_NEEDED_MAX", 100);

		
		//SKILLS
		PlayerPrefs.SetFloat("REPAIR_SKILL", 0);
		PlayerPrefs.SetFloat("SHIELDBOOSTER_SKILL", 0);
		PlayerPrefs.SetFloat("SHIELDDEFLECTOR_SKILL", 0);
		PlayerPrefs.SetFloat("DIPLOMACY_SKILL", 0);
		PlayerPrefs.SetFloat("CONFUSION_SKILL", 0);
		PlayerPrefs.SetFloat("TRICKTOREPAIR_SKILL", 0);
		PlayerPrefs.SetFloat("CONVERT_SKILL", 0);
		PlayerPrefs.SetFloat("EVADEBOOSTER_SKILL", 0);
		PlayerPrefs.SetFloat("SHIELDOVERLOAD_SKILL", 0);
		PlayerPrefs.SetFloat("INTIMIDATE_SKILL", 0);
		PlayerPrefs.SetFloat("WEAPONSOVERLOAD_SKILL", 0);
		
		
		PlayerPrefs.SetInt("SKILL_POINTS", 0);
		
		//TALENTS
		PlayerPrefs.SetFloat("EVADE", 10);
		PlayerPrefs.SetFloat("GUNNER", 0);
		PlayerPrefs.SetFloat("SHIELDS",0);
		PlayerPrefs.SetFloat("DEFLECTORS",0);
		
		PlayerPrefs.SetInt("PILOT_LVL", 0);
		PlayerPrefs.SetInt("GUNNER_LVL", 0);
		PlayerPrefs.SetInt("SHIELDS_LVL",0);
		PlayerPrefs.SetInt("DEFLECTORS_LVL", 0);

		PlayerPrefs.SetFloat ("Diplomacy", 0);
		PlayerPrefs.SetFloat ("Negotiating", 0);
		PlayerPrefs.SetFloat ("Manipulating", 0);

		PlayerPrefs.SetInt("Diplomacy_LVL", 0);
		PlayerPrefs.SetInt("Negotiating_LVL", 0);
		PlayerPrefs.SetInt("Manipulating_LVL",0);



		//In Respect to Tallents
		PlayerPrefs.SetInt("GUNNER_MIN", 1);
		PlayerPrefs.SetInt("GUNNER_MAX", 15);
		
		
	
		
		PlayerPrefs.SetInt ("REPAIR_AMOUNT", 50);
		
		
		PlayerPrefs.SetInt("TALENT_POINTS",0);		
		
		PlayerPrefs.SetInt ("LEVEL_UP_CHECK", 1);		
		
		PlayerPrefs.SetInt("PLAYER_AP",100);


		PlayerPrefs.SetFloat ("SHIELD_HEALTH", 20f);
		PlayerPrefs.SetFloat ("SHIELD_MULTIPLY_BY", .05f);
		//to get correct amount divide by two the current multiply by whenever your double shield health ie upgrade.
		// shield health is 20. when it is forty divide .05 by two and you get .025 then when shield health is 80 you divide .025 by two to get .0125, etc

		
		
		//WEAPONS
		PlayerPrefs.SetInt("PlasmaLaserOnSilverHawk",0);
		PlayerPrefs.SetInt("PlasmaLaserOnResistance",0);
		PlayerPrefs.SetInt("ElectricBoltCannon",0); //CHANGE THIS AFTER DEBUG


		//BOSS FIGHTS
		PlayerPrefs.SetInt ("BOSS_FIGHT_NGC1300_DONE", 0); 
		PlayerPrefs.SetInt("BossNGC1300DEAD", 0);
		
		PlayerPrefs.SetInt("BOSS_FIGHT_GNZ11_DONE",0);
		PlayerPrefs.SetInt("BossGNZ11DEAD", 0);


		PlayerPrefs.SetString ("WHOS_ATTACKING", "");




		//INVENTORY

		PlayerPrefs.SetInt ("Slot1",0);
		PlayerPrefs.SetInt ("Slot2",0);
		PlayerPrefs.SetInt ("Slot3",0);
		PlayerPrefs.SetInt ("Slot4",0);
		//--------------------------------------------------------------------------IF   RESISTANCE--------------------------------------------------------------
		if (PlayerPrefs.GetString("SHIP_CHOICE") == "RESISTANCE"){
			PlayerPrefs.SetFloat ("EVADE", 30);
			PlayerPrefs.SetInt("PLAYER_STARTING_HEALTH",100);
			PlayerPrefs.SetInt("PLAYER_HEALTH", 100);
			PlayerPrefs.SetFloat("HEALTH_MULTIPLYBY",.01f);


		
			
		}	


		//--------------------------------------------------------------------------IF   SILVERHAWK--------------------------------------------------------------

		if (PlayerPrefs.GetString("SHIP_CHOICE") == "SILVERHAWK"){

			PlayerPrefs.SetInt("PLAYER_STARTING_HEALTH",200);
			PlayerPrefs.SetInt("PLAYER_HEALTH", 200);

			PlayerPrefs.SetFloat("HEALTH_MULTIPLYBY",.005f);


		}
		
		//Standard health level 100 is below
		//PlayerPrefs.SetFloat("HEALTH_MULTIPLYBY",.01f);
		//Debug.Log("player prefs " + PlayerPrefs.GetString("PLAYER_NAME"));
	}	
	
	public void ExitAndSave(){
	
	}
	
	public void ContinueGame(){
		
	}
			
					
}
