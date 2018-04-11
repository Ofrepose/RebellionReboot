using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	float xMin;
	float xMax;
	float yMin;
	float yMax;
	float direction = 1;
	float directionVertical = 1;
	public float enemySpeed;
	public float spawnDelay = 0.5f;
	public float scoreIhope;
	EnemyBehavior getthatscore;
	private BossSpawner bossspawner;
	private ScoreKeeper scorekeeper;
	public AudioSource bossSpawnSound;
	
	

	// Use this for initialization
	void Start () {
		bossspawner = GameObject.FindObjectOfType<BossSpawner>();
		getthatscore = EnemyBehavior.FindObjectOfType<EnemyBehavior>();
		scorekeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper>();
		var aSource = GetComponents<AudioSource>();
		bossSpawnSound = aSource[0];
	
	
		SpawnUntilFull();
		//bossspawner.BossDead();
			
		
		//captures the edges of the screen using the camera 
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint( new Vector3(1,0,distance));
		Vector3 upmost = Camera.main.ViewportToWorldPoint(new Vector3(0,1,distance));
		Vector3 downmost = Camera.main.ViewportToWorldPoint( new Vector3(0,0,distance));
		
		xMin = leftmost.x + 5.3f;
		xMax = rightmost.x - 5.3f;
		yMin = downmost.y + 5f;
		yMax = upmost.y - 2.3f;
	
	}
	
	public void SpawnEnemies(){
		//creates the gameobject to awaken when called instantiate(objectname which was called at top, position for it to be spawned, quanternion is the rotation just use identity to null that call);
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			
			//creates the actual gameobject within the gameobject parent folder in the script so you can use the gameobject within the game. creates clone
			enemy.transform.parent = child;		
	
		}
	}
	
	void SpawnUntilFull(){
		//spawns one enemy at a time
		Transform freePosition = NextFreePosition();
		if (freePosition){
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent= freePosition;
		}
		//invoke function here causes a delay
		if(NextFreePosition()){
			Invoke("SpawnUntilFull", spawnDelay);
		}
	}
	
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3 (width, height, 0));
	
	}
	
	Transform NextFreePosition(){
		//finds the available position in the spawer position and instiantiates the object 
		foreach (Transform childPositionGameObject in transform){
			if (childPositionGameObject.childCount ==0){
				return childPositionGameObject;
			}
			
		}return null;
	
	}
	
	
	bool AllMembersDead(){
		//checks to see if all spawned enemies are dead.
		foreach (Transform childPositionGameObject in transform){
			if (childPositionGameObject.childCount > 0){
				return false;
			}
			
		}
		SpawnUntilFull();
		return true;
		
		
	
	}
	
	bool AllMembersDeadCheckOnly(){
		//checks to see if all spawned enemies are dead.
		foreach (Transform childPositionGameObject in transform){
			if (childPositionGameObject.childCount > 0){
				return false;
			}
			
		}
		;
		return true;
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		int scorepossibly = 15000;
		int scorepossiblybossdead = 30000;
		int scorepossibly2boss = 35000;
	
	
		moveFormation();
		Debug.Log("Your score is " + scorekeeper.score);
		
		if (scorekeeper.score < scorepossibly){
			AllMembersDead();
		}
		if (scorekeeper.score > scorepossibly2boss && AllMembersDead()){
			//bossspawner.SpawnBossUntilFull();
			//second boss spawner here
		}
		if (scorekeeper.score > scorepossibly && scorekeeper.score > scorepossiblybossdead){
			AllMembersDead();
		}
		if (scorekeeper.score > scorepossibly && AllMembersDeadCheckOnly()){
			bossSpawnSound.Play ();
			bossspawner.SpawnBossUntilFull();
		}
	
	
	}
	
	

	void moveFormation(){
		// moves the formation of enemy clones left and right and up and down
		if (transform.position.x <= xMin){
			direction = direction * -1;			
		}
		if (transform.position.x >= xMax ){
			direction = direction * -1;
			
		}
		if (transform.position.y >= yMax){
			directionVertical = directionVertical * -1;
		}
		if (transform.position.y <= yMin){
			directionVertical = directionVertical * -1;
		}
		
		transform.position += Vector3.left * enemySpeed * Time.deltaTime * direction;
		transform.position += Vector3.up * enemySpeed * Time.deltaTime * directionVertical;
		
		float newY = Mathf.Clamp (transform.position.y, yMin, yMax);
		
		float newX = Mathf.Clamp (transform.position.x, xMin, xMax);
		transform.position = new Vector3 (newX, newY, transform.position.z);
		//transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
		
		//vertical movement
		
		
	
	}
}
