using UnityEngine;
using System.Collections;

public class BasicLaserScript : MonoBehaviour {
	public int damage;
	
	// Use this for initialization
	void Start () {

		damage = Random.Range(PlayerPrefs.GetInt("GUNNER_MIN") , PlayerPrefs.GetInt("GUNNER_MAX") );
		Debug.Log("Laser  Damage is " + damage);


		//if weapon charge drop item is used charge weapon
		if (RTSBattleController.weaponIsCharged || PlayerAttackScriptMultipleEnemies.weaponIsCharged) {


		
			damage = damage * 3;
		
			Debug.Log ("Weapon damage should be higher, it is : " + damage);
		}


		
	}
	
	// Update is called once per frame
	void Update () {
	
		Destroy (gameObject, 10f);

	}
}
