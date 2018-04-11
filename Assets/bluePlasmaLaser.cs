using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluePlasmaLaser : MonoBehaviour {
	public int damage;
	
	// Use this for initialization
	void Start () {
		damage = Random.Range(10,30);
		Debug.Log("Plasma Damage is " + damage);
		
	}
	

}
