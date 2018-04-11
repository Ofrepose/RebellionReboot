using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDeflectorEnergyBackScript : MonoBehaviour {
	public int damage;

	// Use this for initialization
	void Start () {
	damage = Random.Range(35,100);
	Debug.Log("Shield Deflector ENergy Back Damage is " + damage);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
