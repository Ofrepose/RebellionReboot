using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingToShipAfterBattleScript : MonoBehaviour {


	public Camera mainCamera;

	public Camera secondaryCamera;

	PlayerAttackScriptMultipleEnemies playerController;

	public static bool doneFight = false;

	int alreadyActivated = 0;

	public GameObject playerShip;

	public Transform goingTowardsTarget;

	public float playerSpeed;

	public GameObject canvas;





	void Start(){

		playerController = PlayerAttackScriptMultipleEnemies.FindObjectOfType<PlayerAttackScriptMultipleEnemies> ();



	}


	void Update(){

		if (doneFight && alreadyActivated == 0 ) {

			alreadyActivated = 1;
		
			mainCamera.enabled = false;

			secondaryCamera.enabled = true;

			playerController.playerAnimator.enabled = false;

			BattleControllerTurnBasedMultipleScript.doneFighting = true;

			canvas.SetActive (false);

		
		}

		if (doneFight && alreadyActivated == 1) {

			playerController.shield.SetActive (false);
			playerController.shieldDeflector.SetActive (false);
			playerController.enabled = false;
		
		
			playerShip.transform.LookAt (goingTowardsTarget);

			playerShip.transform.position = Vector3.Lerp (playerShip.transform.position, goingTowardsTarget.position, Time.deltaTime * playerSpeed);
		
		}


	}


}
