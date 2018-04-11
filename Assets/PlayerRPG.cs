using UnityEngine;
using System.Collections;

public class PlayerRPG : MonoBehaviour {

	public GameObject projectile;
	public GameObject DoubleLaser;
	public GameObject Missile;
	public float projectileSpeed = 10;
	private AudioSource Laser;
	public WeaponsStates currentWeapons;
	public GameObject currentWeapon;
	
	
	
	
	
	
	
	
	public enum WeaponsStates{
		
		SingleLaser,
		DoubleLaser,
		Missile
	
	
	}
	
	public void changeToMissile(){
		currentWeapons= WeaponsStates.Missile;
		
		
			
			
	}

	// Use this for initialization
	void Start () {
		currentWeapons = WeaponsStates.SingleLaser;
		var aSource = GetComponents<AudioSource>();
		Laser = aSource[1];
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		switch(currentWeapons){
		case (WeaponsStates.SingleLaser):
			//setup battleFunction
			break;
		case (WeaponsStates.DoubleLaser):
					
			break;
		case (WeaponsStates.Missile):
			
			
			
			break;
		}
		
		Debug.Log("Player your current weapon is " + currentWeapons);
		
	
	}
	
	void Fire(){
		if (WeaponsStates.SingleLaser==currentWeapons){
			Vector3 firePosition = transform.position + new Vector3 (0,1,0);
			GameObject beam = Instantiate(projectile, firePosition, Quaternion.identity) as GameObject;
		
			beam.GetComponent<Rigidbody2D>().velocity = new Vector3 (0,projectileSpeed,0);
			Laser.Play();
		}
		else if (WeaponsStates.DoubleLaser==currentWeapons){
			Vector3 firePosition = transform.position + new Vector3 (0,1,0);
			GameObject beam = Instantiate(DoubleLaser, firePosition, Quaternion.identity) as GameObject;
			
			beam.GetComponent<Rigidbody2D>().velocity = new Vector3 (0,projectileSpeed,0);
			Laser.Play();		
		}
		else if (WeaponsStates.Missile == currentWeapons){
			Vector3 firePosition = transform.position + new Vector3 (0,1,0);
			GameObject beam = Instantiate(currentWeapon, firePosition, Quaternion.identity) as GameObject;
			
			beam.GetComponent<Rigidbody2D>().velocity = new Vector3 (0,projectileSpeed,0);
			Laser.Play();
		}
		
		
	}
	
	public void BtnLaser(){
		Fire ();
		
	}
	
	public void BtnShield(){
		
		
	}
	
	public void BtnFlee(){
		
		
	}
}
