using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarShipComputerScript : MonoBehaviour {


		public float letterPaused = .001f;
		public string message;
		public Text textComp;

		void Start ()
		{
			textComp = GetComponent<Text> ();

		if (PlayerPrefs.GetString ("NGC1300_FACTION_CONTROL") != "REBELLION") {
		
			message = "WELCOME COMMANDER \n=================\n -Please maintain speed while approaching Space Station. \n \n FACTION CONTROL\n ================= \n \n -Please be advised we are currently in a 'Transitional' Government stage. \n -Maintain Caution when entering and exiting the Station. \n -Please notify the " +
			"Authorities if you observe any hostile pirate activites.";
		
		}


			//message = textComp.text;
			textComp.text = "";
			StartCoroutine (TypeText ());
		}

		IEnumerator TypeText()
		{
			foreach (char letter in message.ToCharArray()) 
			{
				textComp.text += letter;
				yield return 0;
				yield return new WaitForSeconds(letterPaused);
			}
		}
}
