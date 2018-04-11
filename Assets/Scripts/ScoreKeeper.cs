using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ScoreKeeper : MonoBehaviour {

	//make sure when you add this script into enemy behavior scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper>();
	// that the "" is the same name as the text field in the UI you are trying to attach it to, not a line in the script!!

	public int score = 0;
	public Text myText;
	
	
	
	void Start () {
		myText = GetComponent<Text>();
	
	}
	
	public void Score (int points){
		Debug.Log("scored points");
		score += points;
		myText.text = "Score: " + score.ToString();
	}
	
	public void Reset(){
		score = 0;
		myText.text = "Score: " + score.ToString();
	}
	
	
	

}
