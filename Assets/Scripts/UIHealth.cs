using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour {
	public string message;
	//Text for the message to display
	public Text textComp;
	PlayerDamage health;
	private float health2;

	// Use this for initialization
	void Start () {
		health = PlayerDamage.FindObjectOfType<PlayerDamage>();
		health2 = health.PlayerHealth;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		textComp.text= health.PlayerHealth + " %";
	
	}
}
