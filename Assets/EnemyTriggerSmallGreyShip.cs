using UnityEngine;
using System.Collections;

public class EnemyTriggerSmallGreyShip : MonoBehaviour {

	
	
	public GameObject playerShip;
	public GameObject levelManager;
	private LevelManager Levelmanager;

	public Transform enemyShip;

	GameObject mainCamera;

	MoveOnMouse moveOnMouse;

	ASyncLoadScript aSync;
	
	
	// Use this for initialization
	void Start () {
		moveOnMouse = MoveOnMouse.FindObjectOfType<MoveOnMouse> ();
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		aSync = ASyncLoadScript.FindObjectOfType<ASyncLoadScript> ();
		//levelManager = LevelManager.FindObjectOfType<LevelManager>();
		//GameObject playerShip = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {



		PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_X",  this.gameObject.transform.position.x);
		PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_Z",  this.gameObject.transform.position.z);


		if (moveOnMouse == null) {
		
			moveOnMouse = MoveOnMouse.FindObjectOfType<MoveOnMouse> ();
		
		}
		
	}
	
	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			PlayerPrefs.SetString ("WHOS_ATTACKING","ShipSmallGreyDefault");


			Vector3 enemyshipPos = new Vector3 (enemyShip.position.x + 5f, enemyShip.position.y + 5f, enemyShip.position.z + 5f);
			moveOnMouse.isMoving = false;

			PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_X", enemyShip.position.x);
			PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_Z",  enemyShip.position.z);
			PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_Y",  enemyShip.position.y);

			mainCamera.transform.position = Vector3.Lerp (mainCamera.transform.position, enemyshipPos, Time.deltaTime * 20); //zooms camera in
		
			//Character.xPositionNow = playerShip.transform.position.x;
			//Character.zPositionNow = playerShip.transform.position.z;

			Invoke ("LoadCorrectLevel", 1f);
		
		}
		if (!playerShip) {
			
		}
		
		
	}

	void LoadCorrectLevel(){
	
		aSync.level = "NGC1300FIGHT";

		aSync.ActivateScene ();
	
	}
}
