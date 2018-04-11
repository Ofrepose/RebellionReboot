using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDeflectorScript : MonoBehaviour {
	
	EnemyBasicLaserScript damage;
	public GameObject enemyProjectile;
	public GameObject EnemyShip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider deflectorshield){
		EnemyBasicLaserScript enemylaserred = deflectorshield.gameObject.GetComponent<EnemyBasicLaserScript>();
		damage = EnemyBasicLaserScript.FindObjectOfType<EnemyBasicLaserScript>();
		
		if (enemylaserred){
			Destroy (deflectorshield.gameObject);
			Vector3 startPostion = transform.position + new Vector3 (0,0,0);
			GameObject laserRedBack= Instantiate(enemyProjectile, startPostion, Quaternion.identity) as GameObject;
			
			laserRedBack.GetComponent<Rigidbody>().velocity = new Vector3 (EnemyShip.transform.position.x, EnemyShip.transform.position.y,EnemyShip.transform.position.z);
			RTSBattleController.shieldDeflectorHealth = RTSBattleController.shieldDeflectorHealth - 10;
			if (RTSBattleController.shieldDeflectorHealth <= 0 ){
				RTSBattleController.shieldDeflectorCharged = false;
				
			}
			
		}
		
	}
}
