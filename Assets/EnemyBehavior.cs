using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public float EnemyHealth =100f;
	public Projectile projectile;
	public MissileProjectile missile;
	private AudioSource hitbymissile;
	
	
	private AudioSource shipDestrooy;	
	public LaserDouble doublelaser;
	public int scoreValue = 150;
	public int LaserScoreValue = 15;
	public int MissileScoreValue = 35;
	private ScoreKeeper scoreKeeper;
	//a better way to add audio clips to different actions and death
	public AudioClip deathSound;
	
	
	void Start(){
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper>();
		var aSource = GetComponents<AudioSource>();
		hitbymissile = aSource[0];		
		shipDestrooy = aSource[2];
		
		
		
		
	}
	
	 void OnTriggerEnter2D(Collider2D collider){
		
		
		Projectile laser = collider.gameObject.GetComponent<Projectile>();
		projectile = Projectile.FindObjectOfType<Projectile>(); 
		
		MissileProjectile missile = collider.gameObject.GetComponent<MissileProjectile>();
		missile = MissileProjectile.FindObjectOfType<MissileProjectile>();
		
		LaserDouble laserx2 = collider.gameObject.GetComponent<LaserDouble>();
		doublelaser = LaserDouble.FindObjectOfType<LaserDouble>();
		
		if (laser){
			Debug.Log ("hit by a laser");
			
			Destroy (collider.gameObject);
			scoreKeeper.Score(scoreValue);
			EnemyHealth = EnemyHealth - projectile.basicLaserDamage;
			Debug.Log (EnemyHealth);			
			if (EnemyHealth <= 0 ) {	
				Die();
				
			}			
		}
		if (missile){
			Debug.Log("Hit by a missile");
			Destroy (collider.gameObject);
			scoreKeeper.Score(MissileScoreValue);
			EnemyHealth = EnemyHealth - missile.missileDamage;
			hitbymissile.Play ();			
			Debug.Log(EnemyHealth);
			if (EnemyHealth <=0){
				Die();				
			}
		}
		if (laserx2){
			Debug.Log("Hit by double laser");
			Destroy (collider.gameObject);
			scoreKeeper.Score(LaserScoreValue);
			EnemyHealth = EnemyHealth - doublelaser.DoubleLaserDamage;
			Debug.Log(EnemyHealth);
			if (EnemyHealth <= 0 ) {
				Die();
			}
			
		}
		
	
		
	
	}
	void Die(){
		AudioSource.PlayClipAtPoint(deathSound,transform.position);
		Destroy(gameObject);
		scoreKeeper.Score(scoreValue);
		
	}
	
	
	void Update(){
		
			
			//shipDestroyCount = 0;
		}
		

		
	
		
	
	
	
	
	
}
