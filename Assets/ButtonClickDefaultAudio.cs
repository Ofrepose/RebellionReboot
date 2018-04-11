using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickDefaultAudio : MonoBehaviour {


	private AudioSource defaultSelect;
	private AudioSource skillUp;
	private AudioSource openMenu;
	private AudioSource GalaxySelect;
	private AudioSource fireSelect;




	void Start(){

		var aSource = GetComponents<AudioSource> ();

		defaultSelect = aSource [0];

		skillUp = aSource [1];

		openMenu = aSource [2];

		GalaxySelect = aSource [3];

		fireSelect = aSource [4];



	}



	public void PlayDefaultSelectAudio(){

		defaultSelect.Play ();

	}

	public void PlaySkillUpAudio(){

		skillUp.Play();

	}


	public void PlayOpenMenuAudio(){

		openMenu.Play ();

	}

	public void PlayeGalaxySelect(){

		GalaxySelect.Play ();

	}

	public void PlayFireSelectAudio(){

		fireSelect.Play ();

	}
}
