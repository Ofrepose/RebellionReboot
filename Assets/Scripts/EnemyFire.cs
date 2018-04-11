using UnityEngine;
using System.Collections;

public class EnemyFire : MonoBehaviour {
	public GameObject enemyProjectile;
	public float projectileSpeed = -10f;
	public float shotsPerSeconds = 0.5f;
	private AudioSource	enemyshot;
	public float enemyattackpoints = 100;


	// Use this for initialization
	void Start () {
		var aSource = GetComponents<AudioSource>();
		enemyshot = aSource[1];
	
	}
	
	void enemyturn(){
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability){
			enemyFire();
		}
	
	}
	
	void enemyFire(){
		
		//offsets the firing position so the laser shoot from the front of the ship
		Vector3 startPostion = transform.position + new Vector3 (0, -1.5f, 0);
		GameObject laserRed= Instantiate(enemyProjectile, startPostion, Quaternion.identity) as GameObject;
		
		laserRed.GetComponent<Rigidbody2D>().velocity = new Vector3 (0,projectileSpeed,0);
		enemyattackpoints = enemyattackpoints - 50;
		//Destroy(GameObject);
		//Laser.Play();	
		
	}
	
	// Update is called once per frame
	void Update () {
		//randomizes the time of fire
		
		
	}
}
