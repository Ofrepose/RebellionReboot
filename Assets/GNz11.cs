using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GNz11 : MonoBehaviour {

	public static int GNZ11hasBeenVisited;
	public static int GNZ11hasBeenScanned;
	
	
	//FACTION CONTROL
	public static string Gnz11faction;
	public Text factionControl;
	public static string Gnz11systemName = "Gnz11";
	public static int Gnz11numberOfPlanets = 6;
	public GameObject FirstPanelInfo;

	


	//For Events--------------------------------
	//public GameObject scanner;
	private Animator anim;
	public GameObject distressBeacon;
	Character character;
	
	
	//JumpGate
	public GameObject JumpGates;
	JumpGateScript jumpgate;

	
	//ForAudio Guards
	private AudioSource stayOutOfTrouble;
	private AudioSource resistingArrest;
	public GameObject audioPanel;
	
	
	//for NPCS in scene
	public GameObject[] enemyPrefabs;
	float xMin = -28f;
	float xMax= 18f;
	float yMin= 28f;
	float yMax = 29f;
	float zMin= -50f;
	float zMax = 50f;
	public static int numberOfEnemies;


	Music music;
	
	
	
	void Start () {

		music = Music.FindObjectOfType<Music> ();

		if (Music.isFighting) {



			music.newCLIP ();

			Music.isFighting = false;

		}
		FirstPanelInfo.SetActive(false);
		character = Character.FindObjectOfType<Character>();
		jumpgate = JumpGateScript.FindObjectOfType<JumpGateScript>();
		Text factionControl = GetComponent<Text>();
		var aSource = GetComponents<AudioSource>();
		
		CheckIfWarpIn();
		
		audioPanel.SetActive(false);
		stayOutOfTrouble = aSource[0];
		resistingArrest = aSource[1];	
		
		
		CheckEnemiesAndRep();
		
		
	
		if (numberOfEnemies == 0){
			PlayerPrefs.SetString("GNZ11_FACTION_CONTROL", "REBELLION");
			UpdateDisplay();
			if (PlayerPrefs.GetInt("BOSS_FIGHT_GNZ11_DONE") == 0){
				jumpgate.GNZ11EnemyJumpIntoSystem();
				PlayerPrefs.SetInt("BOSS_FIGHT_GNZ11_DONE",1);
			}
			if (PlayerPrefs.GetInt("BossGNZ11DEAD") == 0){
				jumpgate.GNZ11EnemyJumpIntoSystem();
			}
		}	
			
			
			
		
		if (numberOfEnemies == 1){
			Random.seed = System.DateTime.Now.Millisecond;
			GameObject enemyPrefab = enemyPrefabs[0];
			Vector3 newPos = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero = Quaternion.Euler(0,0,0);
			GameObject enemy = Instantiate(enemyPrefab, newPos, zero) as GameObject;
			PlayerPrefs.SetString("GNZ11_FACTION_CONTROL", "QUANTUMCORP");
			
			Debug.Log (PlayerPrefs.GetString("GNZ11_FACTION_CONTROL"));
			
			
		}
		if (numberOfEnemies == 2){
			Random.seed = System.DateTime.Now.Millisecond;
			GameObject enemyPrefab = enemyPrefabs[0];
			Vector3 newPos = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero = Quaternion.Euler(0,0,0);
			GameObject enemy = Instantiate(enemyPrefab, newPos, zero) as GameObject;
			
			
			Random.seed = System.DateTime.Now.Second;
			GameObject enemyPrefab2 = enemyPrefabs[0];
			Vector3 newPos2 = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero2 = Quaternion.Euler(0,0,0);
			GameObject enemy2 = Instantiate(enemyPrefab2, newPos2, zero2) as GameObject;
			PlayerPrefs.SetString("GNZ11_FACTION_CONTROL", "QUANTUMCORP");
			//factionControl.text = "<" + PlayerPrefs.GetString("GNZ11_FACTION_CONTROL").ToString() + ">";
			Debug.Log  (PlayerPrefs.GetString("GNZ11_FACTION_CONTROL"));
			
			
		}
		if (numberOfEnemies == 3){
			Random.seed = System.DateTime.Now.Millisecond;
			GameObject enemyPrefab = enemyPrefabs[0];
			Vector3 newPos = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero = Quaternion.Euler(0,0,0);
			GameObject enemy = Instantiate(enemyPrefab, newPos, zero) as GameObject;
			
			
			Random.seed = System.DateTime.Now.Second;
			GameObject enemyPrefab2 = enemyPrefabs[0];
			Vector3 newPos2 = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero2 = Quaternion.Euler(0,0,0);
			GameObject enemy2 = Instantiate(enemyPrefab2, newPos2, zero2) as GameObject;
			PlayerPrefs.SetString("GNZ11_FACTION_CONTROL", "QUANTUMCORP");
			
			Random.seed = System.DateTime.Now.Millisecond;
			GameObject enemyPrefab3 = enemyPrefabs[0];
			Vector3 newPos3 = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero3 = Quaternion.Euler(0,0,0);
			GameObject enemy3 = Instantiate(enemyPrefab3, newPos3, zero3) as GameObject;
			PlayerPrefs.SetString("GNZ11_FACTION_CONTROL", "QUANTUMCORP");
			factionControl.text = "<" + PlayerPrefs.GetString("GNZ11_FACTION_CONTROL").ToString() + ">";
			Debug.Log  (PlayerPrefs.GetString("GNZ11_FACTION_CONTROL"));
			
			
		}
		if (numberOfEnemies == 4){
			Random.seed = System.DateTime.Now.Millisecond;
			GameObject enemyPrefab = enemyPrefabs[0];
			Vector3 newPos = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero = Quaternion.Euler(0,0,0);
			GameObject enemy = Instantiate(enemyPrefab, newPos, zero) as GameObject;
			
			
			Random.seed = System.DateTime.Now.Second;
			GameObject enemyPrefab2 = enemyPrefabs[0];
			Vector3 newPos2 = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero2 = Quaternion.Euler(0,0,0);
			GameObject enemy2 = Instantiate(enemyPrefab2, newPos2, zero2) as GameObject;
			PlayerPrefs.SetString("GNZ11_FACTION_CONTROL", "QUANTUMCORP");
			
			Random.seed = System.DateTime.Now.Hour;
			GameObject enemyPrefab3 = enemyPrefabs[0];
			Vector3 newPos3 = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero3 = Quaternion.Euler(0,0,0);
			GameObject enemy3 = Instantiate(enemyPrefab3, newPos3, zero3) as GameObject;
			
			Random.seed = System.DateTime.Now.Month;
			GameObject enemyPrefab4 = enemyPrefabs[0];
			Vector3 newPos4 = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
			Quaternion zero4 = Quaternion.Euler(0,0,0);
			GameObject enemy4 = Instantiate(enemyPrefab4, newPos4, zero4) as GameObject;
			PlayerPrefs.SetString("GNZ11_FACTION_CONTROL", "QUANTUMCORP");
			factionControl.text = "<" + PlayerPrefs.GetString("GNZ11_FACTION_CONTROL").ToString() + ">";
			Debug.Log  (PlayerPrefs.GetString("GNZ11_FACTION_CONTROL"));
			
			
		}
		
		
		
		
		GNZ11hasBeenVisited = PlayerPrefs.GetInt ("GNZ11hasBeenVisitedSaved");
		
		PlayerPrefs.GetInt("GNZ11hasBeenScannedSaved");
		Debug.Log("has been scanned " + PlayerPrefs.GetInt("GNZ11hasBeenScannedSaved"));
		if (PlayerPrefs.GetInt("GNZ11hasBeenScannedSaved") != 0) {
			//ScanningComplete();
			//scanner.SetActive(false);			
		}
		
		//anim = Animator.FindObjectOfType<Animator>();
		
		
		
		
		
		
		
	}
	
	public void CheckIfWarpIn(){
		if (Character.where == "GNZ11"){
			character.CreatePlayerShip();
		}
		if(Character.where != "GNZ11"){
			jumpgate.JumpIntoSystem();
			Character.where = "GNZ11";
		
		}
		
	}
	
	public void SpawnEnemy(){
		Vector3 newPos = new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), Random.Range(zMin,zMax));
		//GameObject enemy = Instantiate(enemyPrefab, newPos, Quaternion.identity) as GameObject;
	}
	
	void UpdateDisplay(){
		factionControl.text = "< Rebellion >";
	}
	
	
	//-------------------------------CHECK REP AND IF VISITED TO DETERMINE HOW MANY ENEMIES------------
	public void CheckEnemiesAndRep(){
		factionControl.text = "<" + PlayerPrefs.GetString("GNZ11_FACTION_CONTROL").ToString() + ">";
		
		
		if (PlayerPrefs.GetInt("GNZ11hasBeenScannedSaved") != 0){
			FirstPanelInfo.SetActive(false);
			numberOfEnemies = PlayerPrefs.GetInt("GNZ11NUMBER_OF_ENEMIES");
			Debug.Log("this place has already bbeen visited");
		}
		
		if (PlayerPrefs.GetInt("GNZ11hasBeenScannedSaved") == 0){
			FirstVisit();
			
			if(Character.QuantumCorpReputation > 5){
				AudioPlay(0);
				
				numberOfEnemies = 1;
				PlayerPrefs.SetInt("GNZ11NUMBER_OF_ENEMIES", 1);
				
			}
			if(Character.QuantumCorpReputation >= 0 && Character.QuantumCorpReputation < 5){
				AudioPlay(0);
				Debug.Log("playsound");
				numberOfEnemies = 2;
				
				PlayerPrefs.SetInt("GNZ11NUMBER_OF_ENEMIES", 2);
				
			}
			if(Character.QuantumCorpReputation >= -5 && Character.QuantumCorpReputation < 0){
				AudioPlay(1);
				numberOfEnemies = 4;
				PlayerPrefs.SetInt("GNZ11NUMBER_OF_ENEMIES", 4);
				
			}
		}
		
	}
	
	
	
	
	// Events for this System---------------------------------
	
	public void InitialScan(){
		
		GNZ11hasBeenVisited += 1;
		Debug.Log ("GNZ11 has been visited " + GNZ11hasBeenVisited);
		PlayerPrefs.SetInt ("GNZ11hasBeenVisitedSaved", GNZ11hasBeenVisited);
		GNZ11hasBeenScanned += 1;
		PlayerPrefs.SetInt("GNZ11hasBeenScannedSaved", GNZ11hasBeenScanned);
		
	}
	
	
	
	public void ScanningComplete(){
		Vector3 startPosition1 = new Vector3(-6.81f,-90.07f,14.9f);
		Quaternion target = Quaternion.Euler(75.44f,91.07f, 0f);
		float probability = Random.Range(0,100);
		if(Random.value * 100 > probability){
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
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FirstVisit (){
		FirstPanelInfo.SetActive (true);
		Time.timeScale = 0f;
		PlayerPrefs.SetInt("GNZ11hasBeenScannedSaved",1);
		
	}
	
	public void CloseInfoPanel(){
		FirstPanelInfo.SetActive (false);
		Time.timeScale = 1f;
		
	}
	
	
	
}
