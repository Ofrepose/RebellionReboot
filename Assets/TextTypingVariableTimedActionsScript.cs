using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTypingVariableTimedActionsScript : MonoBehaviour {

	public Text textComp;

	public Text AlienTextBox;

	public string alienMessage;

	public float letterPaused = .001f;

	public string message;

	public string message2;

	public string message3;

	public string message4;

	public float timeBetweenMessages = 3f;

	bool finished = false;

	bool completedAllTransmissions = false;

	bool done1 = false;

	bool done2 = false;

	bool done3 = false;

	public bool AddToCurrentMessage = true;


	public GameObject otherTextPanel;







	void Start () {


		textComp = GetComponent<Text> ();

		//AlienTextBox = GetComponent<Text> ();

		message = textComp.text;

	

		textComp.text = "";

		alienMessage = AlienTextBox.text;

		AlienTextBox.text = "";

		StartCoroutine (TypeText ());
		
	}


	IEnumerator TypeText(){
		
		foreach (char letter in message.ToCharArray()) {
		
			textComp.text += letter;

			yield return 0;

			yield return new WaitForSeconds (letterPaused);
		
		}


		foreach (char letter in alienMessage.ToCharArray()) {
		
			AlienTextBox.text += letter;

			yield return 0;

			yield return new WaitForSeconds (-5f);
		
		
		}

		finished = true;
	
	
	}


	void Update(){

		if (finished == true && AddToCurrentMessage) {
		
			finished = false;


			Invoke ("WaitForSecondsBeforeContinue", timeBetweenMessages);
		
		}

	}

	void WaitForSecondsBeforeContinue(){
		if (completedAllTransmissions == true) {
		
			finished = false;
		
		}


		if (done1 == false) {
		
			StartCoroutine (TypeText2Add ());

		
		}

		if (done1 == true && done2 == false && done3 == false  ) {

			StartCoroutine (TypeText3Add ());

		
		}

		if (done1 == true && done2 == true && done3 == false ) {
		
			StartCoroutine (TypeText4Add ());

		
		}
		if (done3 == true && completedAllTransmissions == false ) {

			StartCoroutine (TypeText4Add ());


		}





	}


	IEnumerator TypeText2Add(){

		finished = false;

		textComp.text = message + "\n";


	
		foreach (char letter in message2.ToCharArray()) {

			textComp.text += letter;

			yield return 0;

			yield return new WaitForSeconds (letterPaused);

		}

		done1 = true;

		finished = true;
	
	
	
	}

	IEnumerator TypeText3Add(){

		finished = false;

		textComp.text = message + message2 + "\n";



		foreach (char letter in message3.ToCharArray()) {

			textComp.text += letter;

			yield return 0;

			yield return new WaitForSeconds (letterPaused);

		}

		done2 = true;

		finished = true;



	}


	IEnumerator TypeText4Add(){

		finished = false;

		textComp.text = message + message2 +"\n" +  message3 + "\n";



		foreach (char letter in message4.ToCharArray()) {

			textComp.text += letter;

			yield return 0;

			yield return new WaitForSeconds (letterPaused);

		}

		completedAllTransmissions = true;

		done3 = true;

		finished = true;



	}

}
