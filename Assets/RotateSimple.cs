using UnityEngine;
using System.Collections;

public class RotateSimple : MonoBehaviour {
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
	
	
	
	
	
	void Start () {
	
	}
	
	void Update () {
		if (x){
			
			Quaternion target = Quaternion.Euler(num,yR,zR);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			if (transform.rotation == target) {

				num = num + .1f;
			
			}

			//num = num + .1f;
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
