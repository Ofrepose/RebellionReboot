using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SystemsButton : MonoBehaviour {
	public GameObject systemInfoScreen;
	public GameObject personelScreen;
	public GameObject SectorInfo;
	
	
	
	public GameObject smallLaser;
	public Image smallLaserImage;
	

	void Start () {
		personelScreen.SetActive(false);
		systemInfoScreen.SetActive(false);
		
		if (PlayerPrefs.GetString("PRIMARY_WEAPON") == "SMALL_LASER"){
			smallLaserImage.enabled = true;
			
		}
	
	}
	
	public void SystemsInfoScreenOpen(){
		systemInfoScreen.SetActive(true);
		Time.timeScale = 0f;
	}
	
	public void SystemsInfoScreenClose(){
		systemInfoScreen.SetActive(false);
		Time.timeScale = 1f;
	}
	
	public void PersonelScreenOpen(){
		personelScreen.SetActive(true);
		Time.timeScale = 0f;
	}
	
	public void PersonelScreenClose(){
		personelScreen.SetActive(false);
		Time.timeScale = 1f;
	}

	public void SectorInfoScreenOpen(){
		SectorInfo.SetActive (true);
		Time.timeScale = 0f;
	}
	public void SectorInfoScreenClose(){
		SectorInfo.SetActive (false);
		Time.timeScale = 1f;
	}

	
	
	
	void Update () {
	
	}
}
