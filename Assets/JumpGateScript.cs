using UnityEngine;
using System.Collections;

public class JumpGateScript : MonoBehaviour {
	public GameObject playerShip;
	public GameObject enemyShip;
	
	
	float thisX;
	float thisY;
	float thisZ;
	
	float num = 1f;
	
	public static bool jumpingIn;
	
	
	public GameObject JumpgateSpawnEffectPrefab;
	public GameObject JumpOutEffectPrefab;
	
	public GameObject redringlight;
	public GameObject blueringlight;
	
	
	//AudioFor JumpGate
	private AudioSource userUnrecognized;
	public GameObject audioPanel;
	static bool tripped;
	static bool bossSeen = false;
	
	void Start () {
		
		jumpingIn = true; //CHANGE BACK TO FALSE IF UNFORSEEN ERRORS OCCUR
		var aSource = GetComponents<AudioSource>();
		
		userUnrecognized = aSource[0];
		
	
	}
	
	void Update () {
	
		if (jumpingIn){
			
			redringlight.SetActive(true);
			blueringlight.SetActive(false);
			
		}
	
		if (jumpingIn == false){
			Quaternion target = Quaternion.Euler(transform.rotation.x,transform.rotation.y, num);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5f);
			num = num + .1f;
			
			redringlight.SetActive(false);
			blueringlight.SetActive(true);
			
			
		}
		
		if (tripped){
			redringlight.SetActive(true);
			blueringlight.SetActive(false);
		}
		if (playerShip && !jumpingIn && PlayerPrefs.GetString("NGC1300_FACTION_CONTROL") == "REBELLION" || PlayerPrefs.GetString("GNZ11_FACTION_CONTROL") == "REBELLION" ){
			tripped = false;
			redringlight.SetActive(false);
			blueringlight.SetActive(true);
			
		}
		
		/*if (playerShip && !jumpingIn && Character.where == "REBELLION"){
			Quaternion target = Quaternion.Euler(transform.rotation.x,transform.rotation.y, num);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5f);
			num = num + .1f;
		}*/
	
	}
	
	void OnTriggerEnter(Collider collider){

		Debug.Log (PlayerPrefs.GetString ("GNZ11_FACTION_CONTROL"));
		//check to see if first level in complete
		if (collider.tag == "Player" && !jumpingIn && PlayerPrefs.GetString("NGC1300_FACTION_CONTROL") == "REBELLION" || collider.tag == "Player" && PlayerPrefs.GetString("GNZ11_FACTION_CONTROL") == "REBELLION" )
		{
			CreateJumpgateEffect();
			
			Invoke ("loadGalaxyMap", 3);
			
		}
		if (collider.tag == "Player" && !jumpingIn && PlayerPrefs.GetString("NGC1300_FACTION_CONTROL") != "REBELLION"){
			userUnrecognized.Play ();
			
			tripped = true;
			
		}

		
		
	
	}
	
	void loadGalaxyMap(){
		LevelManager levelmanager = LevelManager.FindObjectOfType<LevelManager>();
		
		levelmanager.LoadLevel("GalaxyMap");
		
	}
	
	public void JumpIntoSystem(){
		jumpingIn = true;
		
		thisX = transform.position.x;
		thisY = transform.position.y;
		thisZ = transform.position.z;
		Vector3 startPosition1 = new Vector3(thisX, thisY, thisZ);
	
		GameObject playershipJumped = Instantiate( playerShip, startPosition1, Quaternion.identity) as GameObject;
		
		CreateJumpOutEffect();
		
		Invoke ("JumpingInComplete", 20);
		
	}
	
	void JumpingInComplete(){
		
		jumpingIn = !jumpingIn;
		Debug.Log("Jumping in complete" + jumpingIn);
	}
	
	
	public void CreateJumpgateEffect() {
		GameObject newSpawnEffect = Instantiate (JumpgateSpawnEffectPrefab, transform.position, transform.rotation) as GameObject;
		newSpawnEffect.name = "JumpgateSpawnEffect";		
	}
	
	public void CreateJumpOutEffect() {
		GameObject newSpawnEffect2 = Instantiate (JumpOutEffectPrefab, transform.position, transform.rotation) as GameObject;
		newSpawnEffect2.name = "JumpOutSpawnEffect";		
	}

	public void EnemyJumpIntoSystem(){

		if (bossSeen) {

			Vector3 WhereWasHe = new Vector3 (EnemyTriggerNGCBOSS.bossX, EnemyTriggerNGCBOSS.bossY, EnemyTriggerNGCBOSS.bossZ);

			GameObject enemyShipJumped = Instantiate( enemyShip, WhereWasHe, Quaternion.identity) as GameObject;


		}

		if (!bossSeen) {
		
			//sjumpingIn = true;

			thisX = transform.position.x;
			thisY = transform.position.y;
			thisZ = transform.position.z;
			Vector3 startPosition1 = new Vector3(thisX, thisY, thisZ);

			GameObject enemyShipJumped = Instantiate( enemyShip, startPosition1, Quaternion.identity) as GameObject;

			CreateJumpOutEffect();

			bossSeen = true;

			Invoke ("JumpingInComplete", 20f);
		
		}

	


	}
	
	public void GNZ11EnemyJumpIntoSystem(){
	//CREATE BOSS FOR GNZ11 HERE
	
	}
}
