using UnityEngine;
using System.Collections;

public class HealthBoxCollider : MonoBehaviour {
	public GameObject healthBox;
	public PlayerController playercontroller;
	public int healthgain = 20;
	private HealthUINew healthui;
	public AudioClip RepairAudio;
	
	void Start(){
		healthui = GameObject.Find("HealthText").GetComponent<HealthUINew>();
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		PlayerController friendly = collider.gameObject.GetComponent<PlayerController>();
		if (friendly){
			if(healthui.health<100){
				healthui.Health(healthgain);
				AudioSource.PlayClipAtPoint(RepairAudio, transform.position);
				Destroy(this.gameObject);
			}
			
		
		}
	
	}
	
	
}
