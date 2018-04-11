using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NGC1300SystemInfo : MonoBehaviour {

	public Text p1Name;
	//public Text p1Visted;
	public Text p1Faction;
	public Text p2Name;
	//public Text p2Visted;
	public Text p2Faction;
	public Text p3Name;
	//public Text p3Visted;
	public Text p3Faction;





	void Start () {
		Text p1Name = GetComponent<Text> ();
		Text p1Visited = GetComponent<Text> ();
		Text p1Faction = GetComponent<Text> ();
		Text p2Name = GetComponent<Text> ();
		Text p2Visited = GetComponent<Text> ();
		Text p2Faction = GetComponent<Text> ();
		Text p3Name = GetComponent<Text> ();
		Text p3Visited = GetComponent<Text> ();
		Text p3Faction = GetComponent<Text> ();



		UpdateDisplay ();
		//UpdateDisplay2 ();
	}

	public void UpdateDisplay(){
		p1Name.text = "System Name: ";
		p1Faction.text = "FactionControlled by";

		p2Name.text = "System Name: ";
		p2Faction.text = "FactionControlled by";

		p3Name.text = "System Name: ";
		p3Faction.text = "FactionControlled by";




		//if (PlayerPrefs.GetInt ("NGC1300hasBeenVisitedSaved") == 0) {
		//	charted.text = "Charted: Null";
			//charted.color = Color.red;
		//}
		//if (PlayerPrefs.GetInt ("NGC1300hasBeenVisitedSaved") != 0) {
		//	charted.text = "Charted: Complete";
		//	charted.color = Color.white;
		//}
	}


	void Update () {

	}
}
