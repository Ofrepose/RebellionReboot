using UnityEngine;
using System.Collections;

public class QuantumMovement : MonoBehaviour {
	public GameObject enemyShip;
	public GameObject playerShip;
	Transform target;
	public float width = 10f;
	public float height = 5f;
	float xMin;
	float xMax;
	float yMin;
	float yMax;
	float zMin = -55f;
	float zMax = 55f;
	float direction = 1;
	float directionVertical = 1;
	public float enemySpeed= 10f;
	
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
	
	
	void Start () {
		
		
		
		
		
	}
	
	void Update () {
		if (Character.QuantumCorpReputation >= 0){
			MoveFormation2();
		}
		if (Character.QuantumCorpReputation < 0){
			target = GameObject.FindWithTag("Player").transform;
			transform.LookAt(target);
			chaseX = target.transform.position.x;
			chaseZ = target.transform.position.z;
			chaseY = target.transform.position.y;
			Persue();
		}
		
		
	}
	
	
	
	
	void MoveFormation2(){
		
		
		
		//turns downward after going far right
		/*if (transform.position.z < 35f){
			Debug.Log("1st");
			print (transform.position.z);
			transform.position += Vector3.forward * enemySpeed * Time.deltaTime * directionVertical;
			
			
		}*/
		
		if (transform.position.z >= zMax){
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
		}
		
		
		
		
		if(directionVertical == -1){
			Quaternion target = Quaternion.Euler(0,180f, 0);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			transform.position += Vector3.forward * enemySpeed * Time.deltaTime * directionVertical;
			
		}
		
		if (directionVertical == 1 ){
			Quaternion target = Quaternion.Euler(0,0, 0);
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
	
	
	
}
