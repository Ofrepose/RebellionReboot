using UnityEngine;
using System.Collections;

public class EnemyBasicLaserScript : MonoBehaviour {
	public int damage;
	
	// Use this for initialization
	void Start () {
		damage = Random.Range(1,10);
		Debug.Log("Enemy Laser Damage is " + damage);
		
	}
	
	// Update is called once per frame
	void Update () {


		Destroy (gameObject, 5f);
	
	}


}
