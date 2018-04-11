using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonRotationAnimation : MonoBehaviour {
	public float smooth = 5f;
	public float num = 1f;
	public float xR=0;
	public float yR=0;
	public float zR=0;
	public bool x;
	public bool y;
	public bool z;
	bool OnClickPushed = false;
	bool fightPanelOpen = false;
	bool onclickpushedtwice=true;
	
	
	
	public GameObject fightPanel;
	public GameObject defaultPanelButton;

	void Start () {
		fightPanel.SetActive(false);
		defaultPanelButton.SetActive(true);
	
	}
	
	void Update () {
		if (x){
			Quaternion target = Quaternion.Euler(num,yR,zR);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			num = num + .1f;
		}
		
		if (y){
			Quaternion target = Quaternion.Euler(xR,num,zR);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			num = num + .1f;
		}
		
		
		if (z){
			Quaternion target = Quaternion.Euler(xR,yR, num);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			num = num + .1f;
		}
		if(OnClickPushed){
			
			Quaternion target = Quaternion.Euler(xR,yR, num);
			defaultPanelButton.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			num = num + 10f;
			print (num);
			if (num >= 330f){
				OnClickPushed = false;
				defaultPanelButton.transform.rotation = Quaternion.Euler(0,0,0);
				Invoke ("PanelOpenAnimation", 0f);
				//PanelOpenAnimation();
			}
			
			
		}
		
		if (fightPanelOpen){
			fightPanel.SetActive(true);
			Quaternion target = Quaternion.Euler(num,yR, zR);
			fightPanel.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			num = num - 5f;
			
			if(num <= 5f){
				fightPanel.transform.rotation = Quaternion.Euler(0,0,0);
				fightPanelOpen = false;
			}
		}
		if (onclickpushedtwice){
			//float numb = 90f;
			Quaternion target = Quaternion.Euler(num,yR, zR);
			fightPanel.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			num = 5f + num;
			//numb = numb - num;
			
			if(num >= 90f){
				fightPanel.transform.rotation = Quaternion.Euler(0,0,0);
				fightPanel.SetActive(false);
				fightPanelOpen = false;
			}
			
		}
		
		
		//print (num);


	}
	
	public void OnClickQuickRotate(){
		num = 0f;
		OnClickPushed = true;
		onclickpushedtwice = !onclickpushedtwice;
	}
	
	public void PanelOpenAnimation(){
		num = 90f;
		
		fightPanelOpen= true;
		
		
		
	}
}
