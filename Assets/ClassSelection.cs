using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ClassSelection : MonoBehaviour {

	public GameObject engineerHover;
	public GameObject diplomatHover;
	public GameObject survivalistHover;
	
	public GameObject engineerMouseOver;
	public GameObject diplomatMouseOver;
	public GameObject survivalistMouseOver;
	
	
	
	private bool _mouseOver = false;

	void Start () {
		engineerHover.SetActive(false);
		diplomatHover.SetActive(false);
		survivalistHover.SetActive(false);
		
		
	}

	public void ShowEngineerDesc(){
		engineerHover.SetActive(true);
		diplomatHover.SetActive(false);
		survivalistHover.SetActive(false);
	}
	public void DoneEngineer(){
		engineerHover.SetActive(false);
	}
	
	
	
	public void ShowDiplomatDesc(){
		diplomatHover.SetActive(true);
		engineerHover.SetActive(false);
		survivalistHover.SetActive(false);
	}
	public void DoneDiplomat(){
		diplomatHover.SetActive(false);
	}
	
	
	
	public void ShowSurvivDesc(){
		survivalistHover.SetActive(true);
		engineerHover.SetActive(false);
		diplomatHover.SetActive(false);
	}
	public void DoneSurviv(){
		survivalistHover.SetActive(false);
	}
	
}
