using UnityEngine;
using System.Collections;

public class EnemyTrigger : MonoBehaviour {
	LevelManager levelManager;
	public GameObject playerShip;
	
	

	// Use this for initialization
	void Start () {
	levelManager = LevelManager.FindObjectOfType<LevelManager>();
	//GameObject playerShip = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider){
		if(playerShip){
			ENEMYSELECTORFORBATTLE.WhosAttacking = "ShipLarge";
			
			levelManager.LoadLevel("NGC1300FIGHT");
		}
		if (!playerShip) {
			
		}
		
		
	}
}
