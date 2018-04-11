using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRocketScript : MonoBehaviour {
	public int damage;

	// Use this for initialization
	void Start () {
		damage = Random.Range(5,20);
		Debug.Log("Enemy Laser Damage is " + damage);

	}

	// Update is called once per frame
	void Update () {

	}
}
