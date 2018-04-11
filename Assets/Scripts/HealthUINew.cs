using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthUINew : MonoBehaviour {
	public int health = 100;
	public Text myText;

	void Start(){
		myText = GetComponent<Text>();
	
	}
	
	public void Health(int healthamount){
		health=health + healthamount;
		myText.text = health + "%";
	
	}
	
	public void Reset(){
		health = 100;
		myText.text = health + "%";
	
	}
	
}
