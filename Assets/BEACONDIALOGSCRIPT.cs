using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BEACONDIALOGSCRIPT : MonoBehaviour {

	public Text textComp;

	public Text SecondaryTextBox;

	public string SecondaryMessage;

	public Text AIComp;

	public string AImessage;

	public string AImessage2;

	public string AImessage3;

	public string AImessage4;

	public string AImessage5;

	public string AImessage6;

	public float letterPaused = .001f;

	public string message;

	//public string message2;

	//public string message3;

	//public string message4;

	public float timeBetweenMessages = 2f;

	bool finished = false;

	bool completedAllTransmissions = false;

	bool done1 = false;

	bool done2 = false;

	bool done3 = false;

	public bool AddToCurrentMessage = true;


	//public GameObject otherTextPanel;

	bool playerTalkTurn = true;

	int cycle = 0;


	//Choices

	public GameObject yesButton;

	public GameObject noButton;

	public GameObject killButton;

	public Text yesText;

	public Text noText;

	public Text killText;

	public string yesString;

	public string noString;

	public string killString;

	bool timeForChoices = false;

	ASyncLoadScript aSync;

	LevelManager levelmanager;

	private AudioSource typeWriter1;
	private AudioSource typeWriter2;
	private AudioSource typeWriter3;









	void Start () {

		var aSource = GetComponents<AudioSource> ();

		typeWriter1 = aSource [0];

		typeWriter2 = aSource [1];

		typeWriter3 = aSource [2];

		levelmanager = LevelManager.FindObjectOfType<LevelManager> ();

		aSync = ASyncLoadScript.FindObjectOfType<ASyncLoadScript> ();

		cycle = 0;

		yesButton.SetActive (false);

		noButton.SetActive (false);
		 
		killButton.SetActive (false);

		textComp = GetComponent<Text> ();

		AImessage = AIComp.text;

		//AlienTextBox = GetComponent<Text> ();

		message = "We received your Distress Beacon, what can I do to help?";



		textComp.text = "";

		AImessage = "Thank you Commander. We have come under attack by Pirates and wont survive much longer! If you destroy them we will pay you handsomly!";



		//CHOICES STRINGS

		yesString = "They won't bother you soon enough!!";

		noString = "It is not my job to watch your back!";

		killString = "Pirates are the least of your concerns!";



		SecondaryMessage = SecondaryTextBox.text;

		SecondaryTextBox.text = "";

		StartCoroutine (TypeText ());





	}


	IEnumerator TypeText(){

		foreach (char letter in message.ToCharArray()) {

			int randomAmount = Random.Range (1, 75);

			if (randomAmount < 24) {
			
				typeWriter1.Play ();
			
			}
			if (randomAmount >= 25 && randomAmount < 50) {

				typeWriter2.Play ();

			}

			if (randomAmount >= 50 && randomAmount <= 75) {

				typeWriter3.Play ();

			}

			textComp.text += letter;

			yield return 0;

			yield return new WaitForSeconds (letterPaused);

		}


		/*foreach (char letter in SecondaryMessage.ToCharArray()) {

			SecondaryTextBox.text += letter;

			yield return 0;

			yield return new WaitForSeconds (-5f);


		}*/

		playerTalkTurn = true;
		cycle += 1;


	}


	void Update(){

		if (playerTalkTurn == true) {

			playerTalkTurn = false;


			Invoke ("WaitForSecondsBeforeContinue", timeBetweenMessages);

		}

	}

	void WaitForSecondsBeforeContinue(){
		if (completedAllTransmissions == true) {

			finished = false;

		}

		if (cycle == 1) {
		
			StartCoroutine (AIFirstCycle ());
		
		}

		if (cycle == 2) {

			//StartCoroutine (PlayerChoices ());
			PlayerChoices();

		}



		Debug.Log ("cycle is " + cycle);



		}

	IEnumerator AIFirstCycle(){

		foreach (char letter in AImessage.ToCharArray()) {

			int randomAmount = Random.Range (1, 75);

			if (randomAmount < 24) {

				typeWriter1.Play ();

			}
			if (randomAmount >= 25 && randomAmount < 50) {

				typeWriter2.Play ();

			}

			if (randomAmount >= 50 && randomAmount <= 75) {

				typeWriter3.Play ();

			}

			AIComp.text += letter;

			yield return 0;

			yield return new WaitForSeconds (.00001f);




			yesButton.SetActive (true);

			killButton.SetActive (true);

			noButton.SetActive (true);
		

		}

		playerTalkTurn = true;

		cycle += 1;

	}


	public void PlayerChoices(){



		yesText.text = yesString.ToString ();
		noText.text = noString;
		killText.text = killString;
		


	

		cycle += 1;

	}


	public void AttackPirates(){
	
		//load Pirate Attack level
		PlayerPrefs.SetString ("WHOS_ATTACKING","TWOPIRATES" );
		//levelmanager.LoadLevel ("NGC1300FIGHTPIRATES");
		aSync.level = "NGC1300FIGHTPIRATES";

		aSync.ActivateScene ();
	
	
	}


	public void IgnorePirates(){
	
		//return to where

		levelmanager.LoadLevel (Character.where);
	
	
	}


	public void KillAI(){
	
	
		yesButton.SetActive (false);

		noButton.SetActive (false);

		killButton.SetActive (false);

		AIComp.text = "";

		textComp.text = "";

	
	}












}
