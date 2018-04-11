using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerQuantumSmall : MonoBehaviour {

	public GameObject playerShip;
	public GameObject levelManager;
	private LevelManager Levelmanager;
	
	
	
	// Use this for initialization
	void Start () {
		Levelmanager = levelManager.GetComponent<LevelManager>();
		//levelManager = LevelManager.FindObjectOfType<LevelManager>();
		//GameObject playerShip = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_X",  this.gameObject.transform.position.x);
		PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_Z",  this.gameObject.transform.position.z);
		
		
	}
	
	void OnTriggerEnter(Collider collider){
		if(playerShip){
			PlayerPrefs.SetString ("WHOS_ATTACKING","QuantumDefault");
			
			//Character.xPositionNow = playerShip.transform.position.x;
			//Character.zPositionNow = playerShip.transform.position.z;
			
			Levelmanager.LoadLevel("GNZ11FIGHT");
		}
		if (!playerShip) {
			
		}
		
		
	}
}
