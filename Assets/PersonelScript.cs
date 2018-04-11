using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PersonelScript : MonoBehaviour {
	Character character;
	NewGameScript crewDescrip;
	public GameObject crew1DescPanel;

	public Text description1;
	public Text crew1;
	public Text crew2;
	public Text crew3;


	// Use this for initialization
	void Start () {
		character = Character.FindObjectOfType<Character> ();
		crewDescrip = NewGameScript.FindObjectOfType<NewGameScript> ();


		Text description1 = GetComponent<Text> ();
		Text crew1 = GetComponent<Text> ();
		Text crew2 = GetComponent<Text> ();
		Text crew3 = GetComponent<Text> ();
		crew1DescPanel.SetActive (false);
		UpdateDisplay ();	
	}


	void UpdateDisplay(){
		//crew1.text = Character.crewMate1.ToString ();
	}

	public void Crew1Description(){
		/*if (//Character.crewMate1 == "Bianca Schwartz") {
			crew1DescPanel.SetActive (true);
			description1.text = NewGameScript.BiancaSchwartz;
		}*/

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
