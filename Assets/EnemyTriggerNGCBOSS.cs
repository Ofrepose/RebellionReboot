using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerNGCBOSS : MonoBehaviour {



	public GameObject playerShip;
	//public GameObject levelManager;
	public GameObject Levelmanager;
	public static float bossX;
	public static float bossY;
	public static float bossZ;



	// Use this for initialization
	void Start () {
		//Levelmanager = LevelManager.FindObjectOfType<LevelManager>();
		//levelManager = LevelManager.FindObjectOfType<LevelManager>();
		//GameObject playerShip = GetComponent<BoxCollider>();
	}

	// Update is called once per frame
	void Update () {

		bossX = this.transform.position.x;
		bossY = this.transform.position.y;
		bossZ = this.transform.position.z;



	}

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			LevelManager levelmanager = LevelManager.FindObjectOfType<LevelManager>();
			PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_X", this.transform.position.x);
			PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_Z",  this.transform.position.z);
			PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_Y",  this.transform.position.y);

			PlayerPrefs.SetString ("WHOS_ATTACKING","NGC1300BOSS");
			Debug.Log("whos attacking in boss trigger is " + PlayerPrefs.GetString ("WHOS_ATTACKING"));

			//Character.xPositionNow = playerShip.transform.position.x;
			//Character.zPositionNow = playerShip.transform.position.z;

			levelmanager.LoadLevel("NGC1300FIGHT");
		}
		if (!playerShip) {

		}


	}
}
