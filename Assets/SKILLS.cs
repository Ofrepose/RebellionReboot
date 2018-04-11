using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SKILLS : MonoBehaviour {
	public Text characterLevel;
	public Text characterSkillPoints;
	public Text characterTalentPoints;
	
	public Text pilotlvl;
	public Text gunnerlvl;
	public Text shieldslvl;
	public Text deflectorslvl;

	public Text diplomacylvl;
	public Text negotiatinglvl;
	public Text manipulatinglvl;




	public GameObject Skill1EngineerLocked;
	public GameObject Skill1EngineerActive;
	public Text Skill1EngineerLvl;
	
	public GameObject Skill2EngineerLocked;
	public GameObject Skill2EngineerActive;
	public Text Skill2EngineerLvl;

	public GameObject Skill3EngineerLocked;
	public GameObject Skill3EngineerActive;
	public Text Skill3EngineerLvl;
	
	public GameObject Skill4EngineerLocked;
	public GameObject Skill4EngineerActive;
	public Text Skill4EngineerLvl;
	


	public GameObject Skill1DiplomacyLocked;
	public GameObject Skill1DiplomacyActive;
	public Text Skill1DiplomacyLvl;
	
	public GameObject Skill2DiplomacyLocked;
	public GameObject Skill2DiplomacyActive;
	public Text Skill2DiplomacyLvl;
	
	public GameObject Skill3DiplomacyLocked;
	public GameObject Skill3DiplomacyActive;
	public Text Skill3DiplomacyLvl;
	
	public GameObject Skill4DiplomacyLocked;
	public GameObject Skill4DiplomacyActive;
	public Text Skill4DiplomacyLvl;
	
	

	public GameObject Skill1SurvivalistLocked;
	public GameObject Skill1SurvivalistActive;
	public Text Skill1SurvivalistLvl;
	
	public GameObject Skill2SurvivalistLocked;
	public GameObject Skill2SurvivalistActive;
	public Text Skill2SurvivalistLvl;
	
	public GameObject Skill3SurvivalistLocked;
	public GameObject Skill3SurvivalistActive;
	public Text Skill3SurvivalistLvl;
	
	public GameObject Skill4SurvivalistLocked;
	public GameObject Skill4SurvivalistActive;
	public Text Skill4SurvivalistLvl;
	
	
	public static bool S1_Eng_isActive;
	public static bool S2_Eng_isActive;
	public static bool S3_Eng_isActive;
	public static bool S4_Eng_isActive;

	public static bool S1_Dip_isActive;
	public static bool S2_Dip_isActive;
	public static bool S3_Dip_isActive;
	public static bool S4_Dip_isActive;
	
	public static bool S1_Sur_isActive;
	public static bool S2_Sur_isActive;
	public static bool S3_Sur_isActive;
	public static bool S4_Sur_isActive;

	public static bool S1_Eng_isUnlocked;
	public static bool S2_Eng_isUnlocked;
	public static bool S3_Eng_isUnlocked;
	public static bool S4_Eng_isUnlocked;


	public static bool S1_Dip_isUnlocked;
	public static bool S2_Dip_isUnlocked;
	public static bool S3_Dip_isUnlocked;
	public static bool S4_Dip_isUnlocked;
	
	public static bool S1_Sur_isUnlocked;
	public static bool S2_Sur_isUnlocked;
	public static bool S3_Sur_isUnlocked;
	public static bool S4_Sur_isUnlocked;
	
	
	//talents
	public GameObject pilotlocked;
	public GameObject gunnerlocked;
	public GameObject shieldslocked;
	public GameObject deflectorslocked;

	public GameObject Diplomacylocked;
	public GameObject Negotiatinglocked;
	public GameObject Manipulatinglocked;


	//HASLEVELED UP

	public GameObject levelUpPanel;







	void Start () {
		//--------------------------------------------------------------FOR DEBUG PURPOSES ONLY-----------------------------------------------------------------


		//PlayerPrefs.SetInt("SKILL_POINTS", 100);



		//PlayerPrefs.SetInt("TALENT_POINTS",100);




		//----------------------------------------------------------------------------------------------------------------------------------------------------------



	


		 
		Text characterLevel = GetComponent<Text> ();
		Text characterSkillPoints = GetComponent<Text> ();
		Text characterTalentPoints = GetComponent<Text>();
		
		
		Text pilotlvl = GetComponent<Text>();
		Text gunnerlvl = GetComponent<Text>();
		Text shieldslvl = GetComponent<Text>();
		Text deflectorslvl = GetComponent<Text>();

		Text diplomacylvl = GetComponent<Text>();
		Text negotiatinglvl= GetComponent<Text>();
		Text manipulatinglvl= GetComponent<Text>();
	
	
		
		PlayerPrefs.GetFloat("REPAIR_SKILL");
		PlayerPrefs.GetFloat("SHIELDBOOSTER_SKILL");
		PlayerPrefs.GetFloat("SHIELDDEFLECTOR_SKILL");
		PlayerPrefs.GetFloat("DIPLOMACY_SKILL");
		PlayerPrefs.GetFloat("CONFUSION_SKILL");
		PlayerPrefs.GetFloat("TRICKTOREPAIR_SKILL");
		PlayerPrefs.GetFloat("CONVERT_SKILL");
		PlayerPrefs.GetFloat("EVADEBOOSTER_SKILL");
		PlayerPrefs.GetFloat("SHIELDOVERLOAD_SKILL");
		PlayerPrefs.GetFloat("INTIMIDATE_SKILL");
		PlayerPrefs.GetFloat("WEAPONSOVERLOAD_SKILL");
		
		if( PlayerPrefs.GetFloat("SHIELDBOOSTER_SKILL") == 0){
			S1_Eng_isUnlocked = true;
			S1_Eng_isActive = false;
			Skill1EngineerLocked.SetActive(false);
			Skill1EngineerActive.SetActive(false);
		}
		
		if (PlayerPrefs.GetFloat("SHIELDBOOSTER_SKILL") > 0){
			Skill1EngineerActive.SetActive(true);
			Skill1EngineerLocked.SetActive(false);
			Skill2EngineerLocked.SetActive(false);
			
		}
		if (PlayerPrefs.GetFloat("REPAIR_SKILL") == 1){
			Skill2EngineerActive.SetActive(true);
			Skill2EngineerLocked.SetActive(false);
			Skill3EngineerLocked.SetActive(false);
			Skill3EngineerActive.SetActive(false);
			Skill4EngineerLocked.SetActive(false);
			Skill4EngineerActive.SetActive(false);
		}
		
		
		/*if (PlayerPrefs.GetFloat("SHIELDBOOSTER_SKILL") == 1){
			Skill2EngineerActive.SetActive(true);
			Skill2EngineerLocked.SetActive(false);
			Skill3EngineerLocked.SetActive(false);
			Skill3EngineerActive.SetActive(true);
			Skill4EngineerLocked.SetActive(false);
			Skill4EngineerActive.SetActive(false);
		}*/
		if (PlayerPrefs.GetFloat("SHIELDDEFLECTOR_SKILL") == 1){
			Skill2EngineerActive.SetActive(true);
			Skill2EngineerLocked.SetActive(false);
			Skill3EngineerLocked.SetActive(false);
			Skill3EngineerActive.SetActive(false);
			Skill4EngineerLocked.SetActive(false);
			Skill4EngineerActive.SetActive(true);
		}
		if (PlayerPrefs.GetFloat("SHIELDBOOSTER_SKILL") == 1 && PlayerPrefs.GetFloat("SHIELDDEFLECTOR_SKILL") == 1){
			Skill2EngineerActive.SetActive(true);
			Skill2EngineerLocked.SetActive(false);
			Skill3EngineerLocked.SetActive(false);
			Skill3EngineerActive.SetActive(true);
			Skill4EngineerLocked.SetActive(false);
			Skill4EngineerActive.SetActive(true);
		}


		if (PlayerPrefs.GetFloat ("DIPLOMACY_SKILL") == 0) {
		
			S1_Dip_isUnlocked = true;
			S1_Dip_isActive = false;
			Skill1DiplomacyLocked.SetActive(false);
			Skill1DiplomacyActive.SetActive(false);		
			Skill2DiplomacyLocked.SetActive(true);

		
		}

		if (PlayerPrefs.GetFloat("DIPLOMACY_SKILL") == 1){
			Skill1DiplomacyActive.SetActive(true);
			Skill1DiplomacyLocked.SetActive(false);
			Skill2DiplomacyLocked.SetActive(false);

		}

		if (PlayerPrefs.GetFloat("CONFUSION_SKILL") == 1){
			Skill2DiplomacyActive.SetActive(true);
			Skill2DiplomacyLocked.SetActive(false);
			Skill3DiplomacyLocked.SetActive(false);
			Skill3DiplomacyActive.SetActive(false);
			Skill4DiplomacyLocked.SetActive(false);
			Skill4DiplomacyActive.SetActive(false);
		}

		if (PlayerPrefs.GetFloat ("TRICKTOREPAIR_SKILL") == 1) {
			Skill2DiplomacyActive.SetActive (true);
			Skill2DiplomacyLocked.SetActive (false);
			Skill3DiplomacyLocked.SetActive (false);
			Skill3DiplomacyActive.SetActive (false);
			Skill4DiplomacyLocked.SetActive (false);
			Skill4DiplomacyActive.SetActive (true);

		}

		if (PlayerPrefs.GetFloat("CONVERT_SKILL") == 1){
			Skill2DiplomacyActive.SetActive (true);
			Skill2DiplomacyLocked.SetActive (false);
			Skill3DiplomacyLocked.SetActive (false);
			Skill3DiplomacyActive.SetActive (true);
			Skill4DiplomacyLocked.SetActive (false);
			Skill4DiplomacyActive.SetActive (false);
		}

		if (PlayerPrefs.GetFloat("TRICKTOREPAIR_SKILL") == 1 && PlayerPrefs.GetFloat("CONVERT_SKILL") == 1){
			Skill2DiplomacyActive.SetActive (true);
			Skill2DiplomacyLocked.SetActive (false);
			Skill3DiplomacyLocked.SetActive (false);
			Skill3DiplomacyActive.SetActive (true);
			Skill4DiplomacyLocked.SetActive (false);
			Skill4DiplomacyActive.SetActive (true);
		}

		
		
		//talents
		if (PlayerPrefs.GetInt("TALENT_POINTS") > 0 ){
			pilotlocked.SetActive(false);
			gunnerlocked.SetActive(false);
			shieldslocked.SetActive(false);
			deflectorslocked.SetActive(false);

			Diplomacylocked.SetActive (false);
			Negotiatinglocked.SetActive (false);
			Manipulatinglocked.SetActive (false);
		}
		if (PlayerPrefs.GetInt("TALENT_POINTS") == 0 ){
			pilotlocked.SetActive(true);
			gunnerlocked.SetActive(true);
			shieldslocked.SetActive(true);
			deflectorslocked.SetActive(true);
			Diplomacylocked.SetActive (true);
			Negotiatinglocked.SetActive (true);
			Manipulatinglocked.SetActive (true);
		}

	
		    
		
		updateScreen ();
		
		
		//S1_Eng_isUnlocked = true;
		//S1_Eng_isActive = false;
		//Skill1EngineerLocked.SetActive(false);
		//Skill1EngineerActive.SetActive(true);
		
		
		
	}
	


	public void updateScreen(){
		characterLevel.text = "LVL: " + PlayerPrefs.GetInt("PLAYER_LEVEL").ToString ();
		characterSkillPoints.text = "Skill Points Available: " + PlayerPrefs.GetInt ("SKILL_POINTS").ToString ();
		characterTalentPoints.text = "Talent Points Available: " + PlayerPrefs.GetInt("TALENT_POINTS").ToString();
		pilotlvl.text = PlayerPrefs.GetInt("PILOT_LVL").ToString();		
		gunnerlvl.text = PlayerPrefs.GetInt("GUNNER_LVL").ToString();
		shieldslvl.text =PlayerPrefs.GetInt("SHIELDS_LVL").ToString();		
		deflectorslvl.text = PlayerPrefs.GetInt("DEFLECTORS_LVL").ToString();

		diplomacylvl.text = PlayerPrefs.GetInt("Diplomacy_LVL").ToString();
		negotiatinglvl.text = PlayerPrefs.GetInt("Negotiating_LVL").ToString();
		manipulatinglvl.text = PlayerPrefs.GetInt("Manipulating_LVL").ToString();
		Skill2EngineerLvl.text = Skill2EngineerLvl.text;


		//Adjusts Skill Level for Additional Skill Points on Available skills

		//-----------------------SHIELD SKILL ADDITIONAL-------------------------------------------
		if (PlayerPrefs.GetFloat ("SHIELDBOOSTER_SKILL") == 2) {
		
			Skill1EngineerLvl.text = "II";

		
		}
		if (PlayerPrefs.GetFloat ("SHIELDBOOSTER_SKILL") == 3) {

			Skill1EngineerLvl.text = "III";


		}
		if (PlayerPrefs.GetFloat ("SHIELDBOOSTER_SKILL") == 4) {

			Skill1EngineerLvl.text = "IV";


		}

		//-----------------------REPAIR SKILL ADDITIONAL-------------------------------------------


		if (PlayerPrefs.GetFloat ("REPAIR_SKILL") == 2) {
		
			Skill1EngineerLvl.text = "II";
		
		}

		if (PlayerPrefs.GetFloat ("REPAIR_SKILL") == 3) {

			Skill1EngineerLvl.text = "III";

		}

		if (PlayerPrefs.GetFloat ("REPAIR_SKILL") == 4) {

			Skill1EngineerLvl.text = "IV";

		}





		
		
	}
	//----------------------------------------------------------ENGINEER SKILL TREE-----------------------------------------
	public void Skill1EngineerChoose(){
		if (  PlayerPrefs.GetInt ("SKILL_POINTS") > 0 && PlayerPrefs.GetFloat("SHIELDBOOSTER_SKILL") == 0){
			PlayerPrefs.SetFloat("SHIELDBOOSTER_SKILL",1);
			Character.ShieldBooster = PlayerPrefs.GetFloat("SHIELDBOOSTER_SKILL");
			S1_Eng_isActive = true;
			Skill1EngineerActive.SetActive(true);
			S2_Eng_isUnlocked = true;
			Skill2EngineerLocked.SetActive(false);
			PlayerPrefs.SetInt ("SKILL_POINTS", PlayerPrefs.GetInt ("SKILL_POINTS") - 1);
			Skill1EngineerLvl.text = "I";
			updateScreen ();
			return;
		}

		if (PlayerPrefs.GetInt ("SKILL_POINTS") > 0 && PlayerPrefs.GetFloat ("SHIELDBOOSTER_SKILL") == 1) {
		
			Skill1EngineerLvl.text = "II";
			PlayerPrefs.SetFloat("SHIELDBOOSTER_SKILL",2);
			PlayerPrefs.SetInt ("SKILL_POINTS", PlayerPrefs.GetInt ("SKILL_POINTS") - 1);
			PlayerPrefs.SetFloat ("SHIELD_HEALTH", 40f);
			PlayerPrefs.SetFloat ("SHIELD_MULTIPLY_BY", .025f);
			updateScreen ();

			return;
		}

		if (PlayerPrefs.GetInt ("SKILL_POINTS") > 0 && PlayerPrefs.GetFloat ("SHIELDBOOSTER_SKILL") == 2) {
		
			Skill1EngineerLvl.text = "III";
			PlayerPrefs.SetFloat("SHIELDBOOSTER_SKILL",3);
			PlayerPrefs.SetInt ("SKILL_POINTS", PlayerPrefs.GetInt ("SKILL_POINTS") - 1);
			PlayerPrefs.SetFloat ("SHIELD_HEALTH", 80f);
			PlayerPrefs.SetFloat ("SHIELD_MULTIPLY_BY", .0125f);
			updateScreen ();

			return;
		
		}

		
	}
	
	public void Skill2EngineerChoose(){
		if (PlayerPrefs.GetFloat("SHIELDBOOSTER_SKILL") == 1 &&  PlayerPrefs.GetInt ("SKILL_POINTS") >= 2){
			PlayerPrefs.SetFloat("REPAIR_SKILL", 1);
			Character.Repair = PlayerPrefs.GetFloat ("REPAIR_SKILL");
			Skill2EngineerActive.SetActive(true);
			Skill3EngineerLocked.SetActive(false);
			Skill4EngineerLocked.SetActive(false);
			PlayerPrefs.SetInt ("SKILL_POINTS", PlayerPrefs.GetInt ("SKILL_POINTS") - 2);
			Skill2EngineerLvl.text = "I";


			updateScreen ();
			return;
		}

		if (PlayerPrefs.GetFloat ("REPAIR_SKILL") == 1 && PlayerPrefs.GetInt ("SKILL_POINTS") >= 2 ) {
			PlayerPrefs.SetFloat ("REPAIR_SKILL", 2);
			PlayerPrefs.SetInt ("SKILL_POINTS", PlayerPrefs.GetInt ("SKILL_POINTS") - 2);
			Skill2EngineerLvl.text = "II";
			PlayerPrefs.SetInt ("REPAIR_AMOUNT", PlayerPrefs.GetInt ("REPAIR_AMOUNT") + 20);
			updateScreen ();


			return;
		}
		if (PlayerPrefs.GetFloat ("REPAIR_SKILL") == 2 && PlayerPrefs.GetInt ("SKILL_POINTS") >= 2 ) {
			PlayerPrefs.SetFloat ("REPAIR_SKILL", 3);
			PlayerPrefs.SetInt ("SKILL_POINTS", PlayerPrefs.GetInt ("SKILL_POINTS") - 2);
			Skill2EngineerLvl.text = "III";
			PlayerPrefs.SetInt ("REPAIR_AMOUNT", PlayerPrefs.GetInt ("REPAIR_AMOUNT") + 20);
			updateScreen ();


			return;
		}

	
	}
	
	
	public void Skill3EngineerChoose(){
		if (PlayerPrefs.GetFloat ("REPAIR_SKILL") == 1 &&   PlayerPrefs.GetInt ("SKILL_POINTS") >= 4){
			PlayerPrefs.SetFloat("SHIELDDEFLECTOR_SKILL", 1);
			Character.ShieldDeflector = PlayerPrefs.GetFloat("SHIELDDEFLECTOR_SKILL");
			Skill3EngineerActive.SetActive(true);
			Skill3EngineerLocked.SetActive(false);
			Skill4EngineerLocked.SetActive(false);
			PlayerPrefs.SetInt ("SKILL_POINTS", PlayerPrefs.GetInt ("SKILL_POINTS") - 4);
			updateScreen ();
		}
	
	}
	
	public void Skill4EngineerChoose(){
	}
	
	
	
	
	
	
	
	
	
	
	//----------------------------------------------------------DIPLOMACY SKILL TREE-----------------------------------------
	
	public void Skill1DiplomacyChoose(){

		if (PlayerPrefs.GetInt ("SKILL_POINTS") > 0 && PlayerPrefs.GetFloat ("DIPLOMACY_SKILL") == 0) {

			PlayerPrefs.SetFloat ("DIPLOMACY_SKILL", 1);
			Character.Diplomacy = PlayerPrefs.GetFloat ("DIPLOMACY_SKILL");
			S1_Dip_isActive = true;
			Skill1DiplomacyActive.SetActive (true);
			S2_Dip_isActive = true;
			Skill2DiplomacyLocked.SetActive (false);
			PlayerPrefs.SetInt ("SKILL_POINTS", PlayerPrefs.GetInt ("SKILL_POINTS") - 1);
			updateScreen ();
			
		
		}
	}
	
	
	
	
	public void Skill2DiplomacyChoose(){
	}
	
	
	
	public void Skill3DiplomacyChoose(){
	}
	
	
	
	
	public void Skill4DiplomacyChoose(){
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	//----------------------------------------------------------SURVIVALIST SKILL TREE-----------------------------------------
	
	public void Skill1SurvivalistChoose(){
	}
	
	
	
	public void Skill2SurvivalistChoose(){
	}
	
	
	
	public void Skill3SurvivalistChoose(){
	}
	
	
	
	public void Skill4SurvivalistChoose(){
	}
	
	
	
	
	
	
	
	
	//----------------------------------------------------------Talents-----------------------------------------
	
	public void PilotTalent(){
		if (PlayerPrefs.GetInt("TALENT_POINTS") > 0 ){
			PlayerPrefs.SetFloat("EVADE",PlayerPrefs.GetFloat("EVADE") + 2 );
			PlayerPrefs.SetInt("TALENT_POINTS", PlayerPrefs.GetInt("TALENT_POINTS") -1 );
			PlayerPrefs.SetInt("PILOT_LVL", PlayerPrefs.GetInt("PILOT_LVL") + 1);
			updateScreen();
			
		}
		
	}
	
	public void GunnerTalent(){
		if (PlayerPrefs.GetInt("TALENT_POINTS") > 0 ){
			PlayerPrefs.SetFloat("GUNNER",PlayerPrefs.GetFloat("GUNNER") + 1 );
			PlayerPrefs.SetInt("TALENT_POINTS", PlayerPrefs.GetInt("TALENT_POINTS") -1 );
			PlayerPrefs.SetInt("GUNNER_LVL", PlayerPrefs.GetInt("GUNNER_LVL") + 1);
			PlayerPrefs.SetInt("GUNNER_MIN", PlayerPrefs.GetInt("GUNNER_MIN") + 3);
			PlayerPrefs.SetInt("GUNNER_MAX", PlayerPrefs.GetInt("GUNNER_MAX") + 4);

			updateScreen();
			
		}
		
	}
	
	public void ShieldsTalent(){ // MAKE EVERY LEVEL INCREASE SHIELDS BY 50. THEN CREATE A PLAYERPREFS THAT ACCOUNTS FOR THAT AMOUNT CHANGE TO ALWAYS EQUAL SOMETHING AT OR BELOW 1.0
		if (PlayerPrefs.GetInt("TALENT_POINTS") > 0 ){
			PlayerPrefs.SetFloat("SHIELDS",PlayerPrefs.GetFloat("SHIELDS") + 1 );
			PlayerPrefs.SetInt("TALENT_POINTS", PlayerPrefs.GetInt("TALENT_POINTS") -1 );
			PlayerPrefs.SetInt("SHIELDS_LVL", PlayerPrefs.GetInt("SHIELDS_LVL") + 1);
			updateScreen();
			
		}
		
	}
	
	public void DeflectorsTalent(){
		if (PlayerPrefs.GetInt ("TALENT_POINTS") > 0) {
			PlayerPrefs.SetFloat ("DEFLECTORS", PlayerPrefs.GetFloat ("DEFLECTORS") + 1);
			PlayerPrefs.SetInt ("TALENT_POINTS", PlayerPrefs.GetInt ("TALENT_POINTS") - 1);
			PlayerPrefs.SetInt ("DEFLECTORS_LVL", PlayerPrefs.GetInt ("DEFLECTORS_LVL") + 1);
			updateScreen ();
			
		}
	}












		public void DiplomacyTalent(){
			if (PlayerPrefs.GetInt("TALENT_POINTS") > 0 ){
				PlayerPrefs.SetFloat("Diplomacy",PlayerPrefs.GetFloat("Diplomacy") + 1 );
				PlayerPrefs.SetInt("TALENT_POINTS", PlayerPrefs.GetInt("TALENT_POINTS") -1 );
				PlayerPrefs.SetInt("Diplomacy_LVL", PlayerPrefs.GetInt("Diplomacy_LVL") + 1);
				updateScreen();

			}

		}

		public void NegotiatingTalent(){
			if (PlayerPrefs.GetInt("TALENT_POINTS") > 0 ){
				PlayerPrefs.SetFloat("Negotiating",PlayerPrefs.GetFloat("Negotiating") + 1 );
				PlayerPrefs.SetInt("TALENT_POINTS", PlayerPrefs.GetInt("TALENT_POINTS") -1 );
				PlayerPrefs.SetInt("Negotiating_LVL", PlayerPrefs.GetInt("Negotiating_LVL") + 1);
				updateScreen();

			}

		}

		public void ManipulatingTalent(){ // MAKE EVERY LEVEL INCREASE SHIELDS BY 50. THEN CREATE A PLAYERPREFS THAT ACCOUNTS FOR THAT AMOUNT CHANGE TO ALWAYS EQUAL SOMETHING AT OR BELOW 1.0
			if (PlayerPrefs.GetInt("TALENT_POINTS") > 0 ){
				PlayerPrefs.SetFloat("Manipulating",PlayerPrefs.GetFloat("Manipulating") + 1 );
				PlayerPrefs.SetInt("TALENT_POINTS", PlayerPrefs.GetInt("TALENT_POINTS") -1 );
				PlayerPrefs.SetInt("Manipulating_LVL", PlayerPrefs.GetInt("Manipulating_LVL") + 1);
				updateScreen();

			}

		}



	void Update(){
	
		if (PlayerPrefs.GetInt ("LEVEL_UP_CHECK") == 0) {
		
			levelUpPanel.SetActive (true);
		
		}

		if (PlayerPrefs.GetInt ("LEVEL_UP_CHECK") == 1) {
		
			levelUpPanel.SetActive (false);
		
		}
		if (PlayerPrefs.GetInt ("TALENT_POINTS") <= 0) {

			PlayerPrefs.SetInt ("LEVEL_UP_CHECK", 1);
		
		}
	
	}

}
	
	
	
	
	
	
	

