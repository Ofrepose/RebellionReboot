using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DropBoxAmmo : MonoBehaviour {
	public GameObject AmmoDropBox;
	public GameObject enemy;
	
	public PlayerController playercontroller;
	public int ammoRefresh = 5;
	public int totalMissileAmmo;
	private MissileAmmoTracker missileammotracker;
	public AudioClip ReloadMissile;
	
	void Start(){
		missileammotracker = GameObject.Find("MissileText").GetComponent<MissileAmmoTracker>();
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		PlayerController friendly = collider.gameObject.GetComponent<PlayerController>();
		if (friendly){
			missileammotracker.TotalMissileAmmo(ammoRefresh);
			AudioSource.PlayClipAtPoint(ReloadMissile, transform.position);
			Destroy(this.gameObject);
		
		}
		
	
		
		
		
		
			
		
		}
		
	
		
		}
		
		
		
	
	
	
	
		
	
	
	











