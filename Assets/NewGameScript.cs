using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class NewGameScript : MonoBehaviour {
	private LevelManager levelManager;
	public Text playerInputName;	
	public string playerNameNew;
	public string crewMate1;
	Character character;
	public static string CarterFellin;
	public static string BiancaSchwartz;
	
	public string playerclass;
	


	//crew selection

	string[] crewNames = {"Carter Fellin", "Isaiah Bruhanski", "Hope Terzo", "Sascha Themisto", "Lexa Stone", "Ulrich Burwin", "Tora Kerrick", "Bianca Schwartz", "Lucas Ketcher"};
	public Text crew1;
	public Text crew2;
	public Text crew3;
	private string crew1Random;
	private string crew2Random;
	private string crew3Random;
	public string crewSelection;
	
	

	public Text crewDescription;
	public GameObject crewDescriptionPanel;
	public GameObject saveAndContinue;
	public GameObject errorEnterName;


	void Start () {


		PlayerPrefs.SetInt ("NGC1300hasBeenVisitedSaved", 0);
		PlayerPrefs.SetInt("NGC1300hasBeenScannedSaved", 0);
		PlayerPrefs.SetInt ("GNZ11hasBeenVisitedSaved", 0);
		PlayerPrefs.SetInt("GNZ11hasBeenScannedSaved", 0);
		PlayerPrefs.SetString ("PLAYER_LOCATION", "Null");
		PlayerPrefs.SetInt("PLAYER_HEALTH", 100);
		PlayerPrefs.SetInt("PLAYER_XP", 0);
		PlayerPrefs.SetInt("PLAYER_LEVEL", 1);
		PlayerPrefs.SetString("PRIMARY_WEAPON", "SMALL_LASER");
		

		
						//--------------------------------setting up crew randomly
		Text crew1 = GetComponent<Text> ();
		Text crew2 = GetComponent<Text> ();
		Text crew3 = GetComponent<Text> ();
		Text crewDescription = GetComponent<Text> ();
		
	

		crew1Random = crewNames [Random.Range (0, 2)];

		crew2Random = crewNames [Random.Range (3, 5)];
		crew3Random = crewNames [Random.Range (6,8)];

		crewDescriptionPanel.SetActive (false);



		Text playerInputName = GetComponent<Text>();
		levelManager = LevelManager.FindObjectOfType<LevelManager> ();
		character = Character.FindObjectOfType<Character>();
		
		errorEnterName.SetActive(false);

		updateDisplay ();	
	}





	/// <summary>
	/// Prints the description of the currently selected crew member
	/// 
	/// </summary>

	public void crewDescription1(){
		crewDescriptionPanel.SetActive (true);
		if (crew1Random == "Carter Fellin") {
			 
			CarterFellin = "He's precise, punctilious and tactful. this isn't surprising considering for someone with his horrifying past.\n\n" +
				"He was born and grew up in a high class family in a poor spaceport, he lived free of worries unttil he was 14 years old, but at that point everything changed. \n\n" +
				"He lost both of his parents in a hit from one of the leading factions, he has spent his life seeking revenge for his fallen family.\n\n" +
				"He has spent the last ten years going from job to job, doing what he can to earn credits as a gunner on mercenary ships and cargo runs.";
			crew1.text = CarterFellin;
			crewMate1= "Carter Fellin";
		}
		crewSelection = "Carter Fellin";
		

	}



	public void CrewDescription3(){
		crewDescriptionPanel.SetActive (true);


		if (crew3Random == "Bianca Schwartz") {
			BiancaSchwartz = "She's petulant, skillful and malicious. But this is all just a facade, a mechanism to deal with her ugly past.\n\nShe was born and grew up in an ordinary family in a major capital, she lived in peace " +
			"until she was about 12 years old, but at that point life changed drastically.\n\n" +
			"She lost her father in a robbery gone wrong and was initiated in a gang. With the help of a suspicious friend she had to survive in a corrupt world. But with her perseverance and strength, " +
			"she managed to conquer all fears and doubts and battle the elements. This has turned her into the woman she is today.";
			crewDescription.text = BiancaSchwartz;
			crewMate1 = "Bianca Schwartz";
		}
		crewSelection = "Bianca Schwartz";
	
	}
	
	
	
	//-----------------------------------------------------PLAYER CLASS------------------------------------------------------
	
	public void EngineerTrait(){
		playerclass = "Engineer";

		
	//givebonuseshere
	
	}
	
	public void DiplomatTrait(){
		playerclass = "Diplomat";
		
	
		
		//givebonuseshere	
	}
	
	public void SurvivalistTrait(){
		playerclass = "Survivalist";
		
		 //MAKE ALGORITH TO HAVE STARTING HEALTH HIGHER AND FILL BAR MAINTAIN WIDTH
		
		//givebonuseshere
	}
	
	
	
	
	
	//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	
	void Update(){
		if (string.IsNullOrEmpty(playerclass)) {
			saveAndContinue.SetActive(false);
		}
		else{
			saveAndContinue.SetActive(true);
		}
	}
	
	public void ChooseShip(){
	
	
	}






	//------------------------------------------STARTING TRAITS-------------------------------------

	void GetStartingTraits(){
		
	}

	void updateDisplay(){
		crew1.text = crew1Random; 
		crew2.text = crew2Random;
		crew3.text = crew3Random;
	}


			
	public void EnterToSave(){
		
		playerNameNew = playerInputName.text.ToString();
		if(string.IsNullOrEmpty(playerNameNew)){
			errorEnterName.SetActive(true);
			
			
		}
		if(!string.IsNullOrEmpty(playerNameNew)){
			Character.playerName = playerNameNew;
			//Character.crewMate1 = crewMate1;
			character.SaveToPrefs();

			Debug.Log ("player class is " + playerclass);
			if (playerclass == "Survivalist") {
			
				PlayerPrefs.SetFloat("EVADEBOOSTER_SKILL", 1);
			
			}

			if (playerclass == "Diplomat") {
			
				PlayerPrefs.SetFloat("DIPLOMACY_SKILL", 1);
			
			}

			if (playerclass == "Engineer") {
			
				PlayerPrefs.SetFloat ("SHIELDBOOSTER_SKILL", 1);
			
			}

			levelManager.LoadLevel("GalaxyMap");
			
		}
		
		
	}
	
	
}
