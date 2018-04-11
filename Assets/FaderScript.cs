using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaderScript : MonoBehaviour {

	public Image fader;
	public bool fadeIn = false;
	public bool fadeOut = false;
	float max = 255f;
	float min = 0f;
	Color c;

	void Start(){

		fader = GetComponent<Image> ();

		c = fader.color;

		c.a = 0;

		fader.color = c;

		/*if (fadeOut) {
		

			Debug.Log ("Fadeout is true");
			c = fader.color;

			c.a = 0;

			fader.color = c;
		
		}

		if (fadeIn) {
			c = fader.color;

			c.a = 254;

			fader.color = c;
		
		}*/

	}


	void Update(){
		if (fadeOut) {
			Debug.Log ("Inside fade out");
			if (fader.color.a < max) {
			
				c.a += 1 * Time.deltaTime ;

				fader.color = c;
			
			}
		
		}

		if (fadeIn) {
		
			if (fader.color.a > min) {

				Debug.Log ("inside fadein");
			
				c.a -= 1 * Time.deltaTime;

				fader.color = c;
			
			}
		
		}


	}

	public void FADEOUT(){

		fadeOut = true;
	
	}

	public void FADEIN(){

		fadeIn = true;

	}


}
