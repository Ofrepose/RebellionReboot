using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBoltScript : MonoBehaviour {
	public int damage;

	// Use this for initialization
	void Start () {
		damage = Random.Range(5,20);
		Debug.Log("Plasma Damage is " + damage);

	}
}
