using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class XP : MonoBehaviour {

	public Text levelText;
	public Text credits;


	public Image xpBar;
	private static int newLevel=100;
	public static int xpForNewLevel;
	private static float multiplyBy= .01f;

	public Animator getMoneyAnime;

	public int creditsHere;

	private AudioSource levelUpAudio;



	

	void Start () {

		var aSource = GetComponents<AudioSource> ();

		levelUpAudio = aSource [0];

		creditsHere = Character.Credits;


		Text levelText = GetComponent<Text>();
		Text credits = GetComponent<Text> ();
		//SpeedIncrease.enabled = false;
		if (PlayerPrefs.GetInt("HAS_XP") == 1) {
			xpForNewLevel = PlayerPrefs.GetInt("PLAYER_XP_FILL");
			multiplyBy= PlayerPrefs.GetFloat ("XP_MULTIPLYBY");
			Character.XP = PlayerPrefs.GetInt("PLAYER_XP");
			newLevel = PlayerPrefs.GetInt ("XP_NEEDED_MAX");

			Debug.Log ("xpHas is equal to 1");
			
		}

	
		//PlayerPrefs.GetInt("PLAYER_XP");
		//PlayerPrefs.GetInt("PLAYER_LEVEL");
	
		//newLevel = 100;
	
	UpdateDisplay();
		
	}
	
	public void GainXP(int amount){
		PlayerPrefs.SetInt ("HAS_XP", 1);
		Character.XP += amount;
		Debug.Log ("character xp total is " + Character.XP);
		xpForNewLevel += amount;
		xpBar.fillAmount = xpForNewLevel * multiplyBy;
		Debug.Log("xpfornewlevel is " + xpForNewLevel);
		PlayerPrefs.SetInt("PLAYER_XP_FILL", xpForNewLevel);
		Debug.Log ("New level is befofre level up" + newLevel);


		if (xpForNewLevel >= newLevel){//Character.XP >= newLevel){
			Character.Level = Character.Level + 1;

			levelUpAudio.Play ();

			PlayerPrefs.SetInt ("LEVEL_UP_CHECK", 0);

			PlayerPrefs.SetInt ("SKILL_POINTS", PlayerPrefs.GetInt ("SKILL_POINTS") + 1);
			PlayerPrefs.SetInt("PLAYER_AP", PlayerPrefs.GetInt("PLAYER_AP") + 25);
			PlayerPrefs.SetInt("TALENT_POINTS",PlayerPrefs.GetInt("TALENT_POINTS") + 1);
			                  
			
			xpBar.fillAmount = 0;
			xpForNewLevel = 0;
			multiplyBy = multiplyBy * .5f;
			PlayerPrefs.SetFloat ("XP_MULTIPLYBY", multiplyBy);

			newLevel = newLevel * 2;
			PlayerPrefs.SetInt ("XP_NEEDED_MAX", newLevel);
			Debug.Log (newLevel);

			Debug.Log("New level goal is " + newLevel);
			PlayerPrefs.SetFloat("SHIP_SPEED", PlayerPrefs.GetFloat("SHIP_SPEED") + .1f);

			

		}
		UpdateDisplay();
	}
	
	public void UpdateDisplay(){
		

		levelText.text = "LVL " + Character.Level.ToString();
		xpBar.fillAmount = xpForNewLevel * multiplyBy;
		credits.text = Character.Credits.ToString ();
		
		//defaultPanel.text = playerHealth.ToString();
		
		PlayerPrefs.SetInt("PLAYER_XP",Character.XP);

		PlayerPrefs.SetInt("PLAYER_LEVEL",Character.Level);



		if (creditsHere != Character.Credits) {
		
			getMoneyAnime.SetTrigger ("GetMoney");

			PlayerPrefs.SetInt ("PLAYER_CREDITS", Character.Credits);

			creditsHere = Character.Credits;
		
		}

	}

}
