using UnityEngine;
using System.Collections;

public class EnemyFightMovement : MonoBehaviour {
	float xMin;
	float xMax = 30f;
	//float yMin = 0f;
	//float yMax = 2f;
	float zMin = -3f;
	float zMax = 3f;
	//float rzmin = -4f;
	//float rzmax = 4f;
	float direction = 1;
	float directionVertical = 1;
	public float enemySpeed= 10f;
	public float smooth = 3f;
	LevelManager levelmanager;


	// Use this for initialization
	void Start () {
		levelmanager = LevelManager.FindObjectOfType<LevelManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!BattleControllerTurnBased.enemyFlee) {
			
			Hover ();
		
		}

		if (BattleControllerTurnBased.enemyFlee) {
			
			Flee ();

		}

	


	
	}


	void Hover(){
		if (transform.position.z >= zMax){
			//anime.SetTrigger("TurnToLeft");
			//Quaternion target = Quaternion.Euler(0,0, -4f);
			//transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			//Quaternion target = Quaternion.Euler(9.65f,86f, rzmax);
			Quaternion target = Quaternion.Euler(0,0, 0);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			directionVertical = directionVertical * -1;
		}

		if (transform.position.z <= zMin){
			//Quaternion target = Quaternion.Euler(9.65f,86f, rzmin);
			Quaternion target = Quaternion.Euler(0,0,0);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			directionVertical = directionVertical * -1;
		}

	




		if(directionVertical == -1){
			//Quaternion target = Quaternion.Euler(0,0, 4f);
			//transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			transform.position += Vector3.forward * enemySpeed * Time.deltaTime * directionVertical;

		}

		if (directionVertical == 1 ){
			//Quaternion target = Quaternion.Euler(0,0, 0);
			//transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			transform.position += Vector3.forward * enemySpeed * Time.deltaTime * directionVertical;
		}
		//transform.position += Vector3.forward * enemySpeed * Time.deltaTime * directionVertical;
	}

	public void Flee(){
	
		if (transform.position.x <= xMax){
			//Quaternion target = Quaternion.Euler(9.65f,86f, rzmin);
			Quaternion target = Quaternion.Euler(15,0,0);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * .0001f);
			directionVertical = directionVertical * -1;
		}

		if(directionVertical == -1){
			//Quaternion target = Quaternion.Euler(0,0, 4f);
			//transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			transform.position += Vector3.right * 3 * Time.deltaTime * direction;

			transform.position += Vector3.up * 1 * Time.deltaTime * direction;

		}

		Invoke ("AfterFlee", 20f);
		
	
	
	
	}

	void AfterFlee(){
	
		EnemyFireAndDamage.justWon = true;
		RTSBattleController.shieldCharged = true;
		RTSBattleController.shieldWait = 0;
		RTSBattleController.repairCharged =true;
		RTSBattleController.repairWait = 0;

		PlayerPrefs.SetInt("NGC1300NUMBER_OF_ENEMIES", PlayerPrefs.GetInt("NGC1300NUMBER_OF_ENEMIES") - 1 );
		NGC1300.numberOfEnemies = NGC1300.numberOfEnemies - 1;
		if (PlayerPrefs.GetString ("WHOS_ATTACKING") == "QuantumDefault") {
			PlayerPrefs.SetInt ("GNZ11NUMBER_OF_ENEMIES", PlayerPrefs.GetInt("GNZ11NUMBER_OF_ENEMIES") - 1 );
			GNz11.numberOfEnemies = GNz11.numberOfEnemies - 1;
		}


		levelmanager.LoadLevel(Character.where);


	
	
	
	}
}
