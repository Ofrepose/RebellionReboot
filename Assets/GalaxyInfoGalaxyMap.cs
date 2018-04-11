using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GalaxyInfoGalaxyMap : MonoBehaviour {

	public Text systemName;
	public Text charted;
	public Text numberPlanets;
	public Text factionControl;
	public Text Rep;
	public Text GNZ11systemName;
	public Text GNZ11charted;
	public Text GNZ11numberPlanets;
	public Text GNZ11factionControl;
	public Text GNZ11REP;



	private NGC1300 ngc1300;
	private GNz11 gnz11;

	void Start () {
		Text systemName = GetComponent<Text> ();
		Text charted = GetComponent<Text> ();
		Text numberPlanets = GetComponent<Text> ();
		Text factionControl = GetComponent<Text> ();
		Text Rep = GetComponent<Text>();
		Text GNZ11systemName = GetComponent<Text> ();
		Text GNZ11charted = GetComponent<Text> ();
		Text GNZ11numberPlanets = GetComponent<Text> ();
		Text GNZ11factionControl = GetComponent<Text> ();
		Text GNZ11REP = GetComponent<Text>();
		ngc1300 = NGC1300.FindObjectOfType<NGC1300> ();
		gnz11 = GNz11.FindObjectOfType<GNz11> ();
		UpdateDisplay ();
		UpdateDisplay2 ();
	}

	public void UpdateDisplay(){
		systemName.text = "System Name: " + NGC1300.NGC1300systemName;
		numberPlanets.text = "# Planets: " + NGC1300.NGC1300numberOfPlanets;
		factionControl.text = "Faction: " + PlayerPrefs.GetString("NGC1300_FACTION_CONTROL").ToString();

	

		if (PlayerPrefs.GetInt ("NGC1300hasBeenVisitedSaved") == 0) {
			charted.text = "Uncharted";
			charted.color = Color.red;
		}
		if (PlayerPrefs.GetInt ("NGC1300hasBeenVisitedSaved") != 0) {
			charted.text = "Charted: Complete";
			charted.color = Color.white;
		}
		if (Character.NovaReputation >= 0 ){
			Rep.color = Color.white;
			Rep.text = "Neutral";
		}
		if (Character.NovaReputation < 0  && PlayerPrefs.GetString("NGC1300_FACTION_CONTROL") != "REBELLION"){
			Rep.color = Color.red;
			Rep.text = "Hostile";
		}
		if (PlayerPrefs.GetString("NGC1300_FACTION_CONTROL") == "REBELLION"){
			Rep.enabled = false;
		}
		
	}
	public void UpdateDisplay2(){
		///gnz11 info-----------------------------------------------------------

		GNZ11systemName.text = "System Name: " + GNz11.Gnz11systemName;
		GNZ11numberPlanets.text = "# Planets: " + GNz11.Gnz11numberOfPlanets;
		GNZ11factionControl.text = "Faction: " + PlayerPrefs.GetString("GNZ11_FACTION_CONTROL").ToString();
		
		if (PlayerPrefs.GetInt("GNZ11hasBeenVisitedSaved") == 0) {
			GNZ11charted.text = "Uncharted";
			GNZ11charted.color = Color.red;
		}
		if (PlayerPrefs.GetInt("GNZ11hasBeenVisitedSaved") != 0) {
			GNZ11charted.text = "Charted: Complete";
			GNZ11charted.color = Color.white;
		}
		if (Character.QuantumCorpReputation >= 0 ){
			GNZ11REP.color = Color.white;
			GNZ11REP.text = "Neutral";
		}
		if (Character.QuantumCorpReputation < 0 && PlayerPrefs.GetString("GNZ11_FACTION_CONTROL") != "REBELLION"){
			GNZ11REP.color = Color.red;
			GNZ11REP.text = "Hostile";
		}
		if (PlayerPrefs.GetString("GNZ11_FACTION_CONTROL") == "REBELLION"){
			GNZ11REP.enabled = false;
		}


	}
	
	void Update () {
	
	}
}
