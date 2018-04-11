using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public GameObject enemyShip;
	public GameObject playerShip;
	Transform target;
	public float width = 10f;
	public float height = 5f;
	float xMin;
	float xMax;
	float yMin;
	float yMax;
	float zMin ;
	float zMax ;
	float direction = 1;
	float directionVertical = 1;
	public float enemySpeed= 10f;
	public float playerSpeed = 10f;
	
	public float smooth = 0.5f;
	public float tiltAngle = 90.0f;
	public float tiltAngleUp = -90.0f;
	public float wingAngleRight = -23.45f; 
	public float wingAngleLeft = 23.45f;
	bool up;
	bool down;
	bool left;
	bool right;
	
	float chaseX;
	float chaseZ;
	float chaseY;
	
	float highestX;
	float lowestX;
	float highestY = 15f;
	float lowestY;
	float highestZ;
	float lowestZ;
	
	
	float rotateLeftLimit = 100f;
	float rotateRightLimit;
	
	
	float num = 1f;
	
	bool isFlip;
	bool reachedTop;
	
	
	void Start () {
		reachedTop = false;
		isFlip = true;
		
		
		
		
		
	}
	
	void Update () {
	 if (!isFlip){
			CameraFollow.enemyBehind = false;
			MoveFormation2(); 
	 }
	 if (isFlip){
	 	PlayerFlip();
	 }
	
		
	}
	
	
	
	
	void MoveFormation2(){
	
		//turns downward after going far right
		/*if (transform.position.z < 35f){
			Debug.Log("1st");
			print (transform.position.z);
			transform.position += Vector3.forward * enemySpeed * Time.deltaTime * directionVertical;
			
			
		}*/
		
		/*if (transform.position.z >= zMax){
			//anime.SetTrigger("TurnToLeft");
			Quaternion target = Quaternion.Euler(0,180f, 0);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			directionVertical = directionVertical * -1;
			//print (directionVertical);
		}
		
		if (transform.position.z <= zMin){
			Quaternion target = Quaternion.Euler(0,0, 0);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			directionVertical = directionVertical * -1;
		}*/
		
		
		
		
		if(directionVertical == -1){
			Quaternion target = Quaternion.Euler(0,-90f, 0);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			transform.position += Vector3.forward * enemySpeed * Time.deltaTime * directionVertical;
			
		}
		
		if (directionVertical == 1 ){
			Quaternion target = Quaternion.Euler(0,0f, 0);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			transform.position += Vector3.forward * enemySpeed * Time.deltaTime * directionVertical;
		}
		transform.position += Vector3.forward * enemySpeed * Time.deltaTime * directionVertical;
		
		
		
		//turning down
		/*if (transform.position.z >= 35f && transform.rotation.y <= .69f){
			//float tiltAroundY = Input.GetAxis("y") * tiltAngle;
			Quaternion target = Quaternion.Euler(0,tiltAngle, wingAngleRight);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			transform.position += Vector3.right * enemySpeed * Time.deltaTime * direction;
			Debug.Log("2nd");
			//print (transform.rotation.y);
			
		
		
		}
			
		if (transform.rotation.y > .69f){
			Debug.Log("should straighten");
			Quaternion target = Quaternion.Euler(0,tiltAngle, 0);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			transform.position += Vector3.right * enemySpeed * Time.deltaTime * direction;
			down = true;
		}*/
		
		//if (transform.position.x >= 3.21f){
		//spin move
		//SpinMove();
		//}
		
		
		//transform.position += Vector3.right * enemySpeed * Time.deltaTime * direction;
		//transform.position -= Vector3.forward * 0 * Time.deltaTime * 0;
	}
	
	
	void SpinMove(){
		Quaternion target = Quaternion.Euler(-168.09f,90f, 30f);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
		
	}
	
	
	//--------------------------------------------------------------------------------BAD REP----------------------------------------------------------
	
	
	public void Persue(){
		
		//print (playerShip.transform.position);
		
		//float chaseX = playerShip.transform.position.x;
		//float chaseZ = playerShip.transform.position.z;
		//float chaseY = playerShip.transform.position.y;
		if (transform.position.x < chaseX){
			transform.position += Vector3.right * enemySpeed * Time.deltaTime;
			Debug.Log("Chasex is " + chaseX);
		}
		if (transform.position.x > chaseX){
			transform.position += Vector3.left * enemySpeed * Time.deltaTime;
		}
		
		if (transform.position.z < chaseZ){
			transform.position += Vector3.forward * enemySpeed * Time.deltaTime;
		}
		if(transform.position.z > chaseZ){
			transform.position += Vector3.back * enemySpeed * Time.deltaTime;
		}
		if (transform.position.y < chaseY){
			transform.position += Vector3.up * enemySpeed * Time.deltaTime;
		}
		if (transform.position.y > chaseY){
			transform.position += Vector3.down * enemySpeed * Time.deltaTime;
		}
	}
	
	public void PlayerFlip(){
		if( transform.position.y < highestY && !reachedTop){
			//Vector3 goingUp = new Vector3 ( num, transform.position.y, transform.position.z);
			//num = num + 1f;
			transform.position += Vector3.up * playerSpeed * Time.deltaTime * directionVertical;
			transform.position += Vector3.forward * 9f * Time.deltaTime * directionVertical;
			if (transform.rotation.z <= rotateLeftLimit){
				Quaternion target = Quaternion.Euler (transform.rotation.x, transform.rotation.y, num);
				transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime);
				num = num + 1f;
				
			}
			if (transform.position.y >= highestY) {
				reachedTop = true;
			}	
		}
		if (reachedTop) {
			
			Quaternion target = Quaternion.Euler (0,0,0);
			transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * smooth);
			transform.position += Vector3.down * playerSpeed * Time.deltaTime * direction;
			transform.position += Vector3.forward * enemySpeed * Time.deltaTime * directionVertical;
			if (transform.position.y <0f) {
				isFlip = false;
		}
		}
		
		
	}
	
	
	
}
