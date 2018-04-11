using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NGC1300 : MonoBehaviour {

	public static int NGC1300hasBeenVisited;
	public static int NGC1300hasBeenScanned;
	//FACTION CONTROL
	public static string NGC1300faction;
	public Text factionControl;
	public static string NGC1300systemName = "NGC1300";
	public static int NGC1300numberOfPlanets = 3;
	public GameObject FirstPanelInfo;
	
	//For Events--------------------------------
	public GameObject scanner;
	private Animator anim;
	public GameObject distressBeacon;

	public static bool NGC1300BeaconDone = false;

	Character character;

	//JumpGateScript jumpgate;
	//public GameObject jumpgate;
	
	public GameObject JumpGates;
	private JumpGateScript jumpgate;
	
	//ForAudio Guards
	public AudioSource stayOutOfTrouble;
	public AudioSource resistingArrest;
	public GameObject audioPanel;
	
	
	//for NPCS in scene
	public GameObject[] enemyPrefabs;
	float xMin = -28f;
	float xMax= 28f;
	float yMin= 29f;
	float yMax = 29f;
	float zMin= -50f;
	float zMax = 50f;
	public static int numberOfEnemies;

	Music music;
	
	
	
	void Start () {

		//------------------------------------------------------------DEBUG----------------------------------------


		//numberOfEnemies = 0;
		//PlayerPrefs.SetInt("NGC1300NUMBER_OF_ENEMIES", 4);




		//-----------------------------------------------------------------------------------------------------



		music = Music.FindObjectOfType<Music> ();

		if (Music.isFighting) {



			music.newCLIP ();

			Music.isFighting = false;
		
		}
		//JumpGates = GameObject.FindGameObjectsWithTag("JumpGateTag");
		jumpgate = JumpGates.GetComponent<JumpGateScript>();
		character = Character.FindObjectOfType<Character>();
		Text factionControl = GetComponent<Text>();
		var aSource = GetComponents<AudioSource>();
		//jumpgate = JumpGateScript.FindObjectOfType<JumpGateScript>();
		CheckIfWarpIn();
		
		audioPanel.SetActive(false);
		stayOutOfTrouble = aSource[0];
		resistingArrest = aSource[1];
		
		
		CheckEnemiesAndRep();
		
		Debug.Log(" number of enemies inside start function in ngc1300 is " + numberOfEnemies);
		//numberOfEnemies = PlayerPrefs.GetInt("NGC1300NUMBER_OF_ENEMIES");

		
		
		
		if (numberOfEnemies == 0){
			PlayerPrefs.SetString("NGC1300_FACTION_CONTROL", "REBELLION");
			UpdateDisplay();

			//tHIS GETs rid of bossfight for now
			/*
			if (PlayerPrefs.GetInt ("BOSS_FIGHT_NGC1300_DONE") == 0) {
				jumpgate.EnemyJumpIntoSystem ();
				//PlayerPrefs.SetInt ("BOSS_FIGHT_NGC1300_DONE", 1); 

			}*/
			//if (PlayerPrefs.GetInt ("BossNGC1300DEAD") == 0) {
			//	jumpgate.EnemyJumpIntoSystem ();

		//	}


			
			
			
		}
		if (numberOfEnemies == 1){
			Random.seed = System.DateTime.Now.Millisecond;
			GameObject enemyPrefab = enemyPrefabs[1];
			Vector3 newPos = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero = Quaternion.Euler(0,0,0);
			GameObject enemy = Instantiate(enemyPrefab, newPos, zero) as GameObject;
			PlayerPrefs.SetString("NGC1300_FACTION_CONTROL", "NOVA");
			
			
			
		}
		if (numberOfEnemies == 2){
			Random.seed = System.DateTime.Now.Millisecond;
			GameObject enemyPrefab = enemyPrefabs[1];
			Vector3 newPos = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero = Quaternion.Euler(0,0,0);
			GameObject enemy = Instantiate(enemyPrefab, newPos, zero) as GameObject;
			
			
			Random.seed = System.DateTime.Now.Second;
			GameObject enemyPrefab2 = enemyPrefabs[1];
			Vector3 newPos2 = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero2 = Quaternion.Euler(0,0,0);
			GameObject enemy2 = Instantiate(enemyPrefab2, newPos2, zero2) as GameObject;
			PlayerPrefs.SetString("NGC1300_FACTION_CONTROL", "NOVA");
			//factionControl.text = "<" + PlayerPrefs.GetString("NGC1300_FACTION_CONTROL").ToString() + ">";
			
			
		}
		if (numberOfEnemies == 3){
			Random.seed = System.DateTime.Now.Millisecond;
			GameObject enemyPrefab = enemyPrefabs[1];
			Vector3 newPos = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero = Quaternion.Euler(0,0,0);
			GameObject enemy = Instantiate(enemyPrefab, newPos, zero) as GameObject;
			
			
			Random.seed = System.DateTime.Now.Second;
			GameObject enemyPrefab2 = enemyPrefabs[1];
			Vector3 newPos2 = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero2 = Quaternion.Euler(0,0,0);
			GameObject enemy2 = Instantiate(enemyPrefab2, newPos2, zero2) as GameObject;
			PlayerPrefs.SetString("NGC1300_FACTION_CONTROL", "NOVA");
			
			Random.seed = System.DateTime.Now.Millisecond;
			GameObject enemyPrefab3 = enemyPrefabs[1];
			Vector3 newPos3 = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero3 = Quaternion.Euler(0,0,0);
			GameObject enemy3 = Instantiate(enemyPrefab3, newPos3, zero3) as GameObject;
			PlayerPrefs.SetString("NGC1300_FACTION_CONTROL", "NOVA");
			//factionControl.text = "<" + PlayerPrefs.GetString("NGC1300_FACTION_CONTROL").ToString() + ">";
			
			
		}
		if (numberOfEnemies == 4){
			Random.seed = System.DateTime.Now.Millisecond;
			GameObject enemyPrefab = enemyPrefabs[1];
			Vector3 newPos = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero = Quaternion.Euler(0,0,0);
			GameObject enemy = Instantiate(enemyPrefab, newPos, zero) as GameObject;
			
			
			Random.seed = System.DateTime.Now.Second;
			GameObject enemyPrefab2 = enemyPrefabs[1];
			Vector3 newPos2 = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero2 = Quaternion.Euler(0,0,0);
			GameObject enemy2 = Instantiate(enemyPrefab2, newPos2, zero2) as GameObject;
			PlayerPrefs.SetString("NGC1300_FACTION_CONTROL", "NOVA");
			
			Random.seed = System.DateTime.Now.Hour;
			GameObject enemyPrefab3 = enemyPrefabs[1];
			Vector3 newPos3 = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero3 = Quaternion.Euler(0,0,0);
			GameObject enemy3 = Instantiate(enemyPrefab3, newPos3, zero3) as GameObject;
			
			Random.seed = System.DateTime.Now.Month;
			GameObject enemyPrefab4 = enemyPrefabs[1];
			Vector3 newPos4 = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero4 = Quaternion.Euler(0,0,0);
			GameObject enemy4 = Instantiate(enemyPrefab4, newPos4, zero4) as GameObject;
			PlayerPrefs.SetString("NGC1300_FACTION_CONTROL", "NOVA");
			//factionControl.text = "<" + PlayerPrefs.GetString("NGC1300_FACTION_CONTROL").ToString() + ">";
			
			
		}
		
		
		

		NGC1300hasBeenVisited = PlayerPrefs.GetInt ("NGC1300hasBeenVisitedSaved");
		//NGC1300hasBeenScanned = PlayerPrefs.GetInt("NGC1300hasBeenScannedSaved");
		PlayerPrefs.GetInt("NGC1300hasBeenScannedSaved");
		if (PlayerPrefs.GetInt("NGC1300hasBeenScannedSaved") != 0) {
			ScanningComplete();
			scanner.SetActive(false);			
		}
	
		anim = Animator.FindObjectOfType<Animator>();
		
		
		
	
		
		
		
	}
	
	public void CheckIfWarpIn(){
		if (Character.where == "NGC1300"){
			character.CreatePlayerShip();
			JumpGateScript.jumpingIn = false;
		}
		if(Character.where != "NGC1300"){
			
			jumpgate.JumpIntoSystem();
			Character.where = "NGC1300";
			
		}
	}
	
	//public void SpawnEnemy(){
		//Vector3 newPos = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
		//GameObject enemy = Instantiate(enemyPrefab, newPos, Quaternion.identity) as GameObject;
	//}
	
	void UpdateDisplay(){
		factionControl.text = "< Rebellion >";
	}
	
	
	//-------------------------------CHECK REP AND IF VISITED TO DETERMINE HOW MANY ENEMIES------------
	public void CheckEnemiesAndRep(){
		factionControl.text = "<" + PlayerPrefs.GetString("NGC1300_FACTION_CONTROL").ToString() + ">";
		
		
		if (PlayerPrefs.GetInt("NGC1300hasBeenScannedSaved") != 0){
			FirstPanelInfo.SetActive (false);
			numberOfEnemies = PlayerPrefs.GetInt("NGC1300NUMBER_OF_ENEMIES");
	 }
	 
		if (PlayerPrefs.GetInt("NGC1300hasBeenScannedSaved") == 0){
			FirstVisit ();

			//FirstPanelInfo.SetActive (true);
			//Time.timeScale = 0f;
			if(Character.NovaReputation > 5){
				AudioPlay(0);
				
				numberOfEnemies = 1;
				PlayerPrefs.SetInt("NGC1300NUMBER_OF_ENEMIES", 1);
				
			}
			if(Character.NovaReputation >= 0 && Character.NovaReputation < 5){
				AudioPlay(0);
				//Debug.Log("playsound");
				numberOfEnemies = 2;
				
				PlayerPrefs.SetInt("NGC1300NUMBER_OF_ENEMIES", 2);
					
			}
			if(Character.NovaReputation >= -5 && Character.NovaReputation < 0){
				AudioPlay(1);
				numberOfEnemies = 4;
				PlayerPrefs.SetInt("NGC1300NUMBER_OF_ENEMIES", 4);
				
			}
		}
		
	}


	
	
	
	
	// Events for this System---------------------------------
	
	public void InitialScan(){
		
		NGC1300hasBeenVisited += 1;
		PlayerPrefs.SetInt ("NGC1300hasBeenVisitedSaved", NGC1300hasBeenVisited);
		NGC1300hasBeenScanned += 1;
		PlayerPrefs.SetInt("NGC1300hasBeenScannedSaved", NGC1300hasBeenScanned);
		
	}
	
	
	
	public void ScanningComplete(){
		Vector3 startPosition1 = new Vector3(-6.81f,21f,14.9f);
		Quaternion target = Quaternion.Euler(75.44f,91.07f, 0f);
		float probability = Random.Range(0,100);


		//randomize if there is a beacon
		if(/*Random.value * 100 > probability &&*/ PlayerPrefs.GetInt("NGC1300_BEACONDONE") == 0){
			GameObject distressBeaconSpawn = Instantiate( distressBeacon, startPosition1, target) as GameObject;
		}
		
	}
	
	
	public void AudioPlay(int clip){
		if ( clip == 0){
			audioPanel.SetActive(true);
			float timeToWait = stayOutOfTrouble.clip.length;
			stayOutOfTrouble.Play();
			Invoke ("closeAudioPanel", timeToWait);
		}
		if ( clip == 1){
			audioPanel.SetActive(true);
			float timeToWait = resistingArrest.clip.length;
			resistingArrest.Play();
			Invoke ("closeAudioPanel", timeToWait);
		}
	
	}
	
	void closeAudioPanel(){
		audioPanel.SetActive(false);
	}
	


	void FirstVisit (){
		FirstPanelInfo.SetActive (true);
		Time.timeScale = 0f;
	
	}

	public void CloseInfoPanel(){
		FirstPanelInfo.SetActive (false);
		Time.timeScale = 1f;

	}
}
