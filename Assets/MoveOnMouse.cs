using UnityEngine;
using System.Collections;

public class MoveOnMouse : MonoBehaviour {
	[SerializeField] [Range(1,5)]
	public static float speed;



	private Vector3 targetPosition; //where we want to travel to
	public bool isMoving; 			//toggle to check track if we are moving or not
	public static float zPositionNow;
	public static float xPositionNow;

	float orthographicSizeMin = 2f;
	float orthographicSizeMax = 35f;

	Transform target;

	public GameObject smoke;

	public GameObject goToHereIcon;

	GameObject[] these;

	GameObject icon;

	bool placeIcon = true;

	const int RIGHT_MOUSE_BUTTON = 0; 	//a moure visual description of what the left mouse button code is

	void Start () {
		speed = PlayerPrefs.GetFloat("SHIP_SPEED");
		xPositionNow = PlayerPrefs.GetFloat("PLAYER_POSITION_NOW_X");
		zPositionNow = PlayerPrefs.GetFloat("PLAYER_POSITION_NOW_Z");
	
		float thisX = PlayerPrefs.GetFloat("PLAYER_POSITION_NOW_X");
		float thisZ = PlayerPrefs.GetFloat("PLAYER_POSITION_NOW_Z");
		float thisY = PlayerPrefs.GetFloat("PLAYER_POSITION_NOW_Y");

		if (PlayerPrefs.GetInt ("PLAYER_HEALTH") <= 20) {
			smoke.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("PLAYER_HEALTH") > 20) {
			smoke.SetActive (false);
		}
	
	
		//targetPosition = new Vector3 (thisX, 0f, thisZ);
		targetPosition =  new Vector3(xPositionNow, 0f, zPositionNow); //set the target position to where we are at the start
		isMoving = false; 	// set out move toggle to false
	}
	
	void Update () {
		//Invoke ("WhereAreWe", 1);
		WhereAreWe();

		if (Input.GetAxis("Mouse ScrollWheel") > 0) {//forward
			Camera.main.orthographicSize++;
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0){ //forward
			Camera.main.orthographicSize--;
		}
		Camera.main.orthographicSize = Mathf.Clamp (Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax);


		//if the player clicked on the screen, find out where
		if (Input.GetMouseButtonDown(RIGHT_MOUSE_BUTTON)){
			placeIcon = false;
			SetTargetPosition ();
		}
		if (isMoving) {
			MovePlayer ();
		}
	}






	void SetTargetPosition(){
		Plane plane = new Plane (Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float point = 0f;

		if (plane.Raycast (ray, out point)) {
			targetPosition = ray.GetPoint (point);
		}

		isMoving = true;


		//GOTOICON --------------------------------------------------------------

		//INSTAED OF REINSTANTIATING THE ICON DECIDED TO JUST MOVE IT ON TARGETPOSITION CALL
		if (GameObject.FindGameObjectWithTag ("GoToIcon") == null) {
		
			icon = Instantiate (goToHereIcon, targetPosition, Quaternion.identity) as GameObject;
			icon.transform.rotation = Quaternion.AngleAxis (90f,Vector3.right); 
		
		
		}


		if (GameObject.FindGameObjectWithTag("GoToIcon") != null){

			icon.transform.position = targetPosition;

		}
		/*if (GameObject.FindGameObjectWithTag ("GoToIcon") != null && !placeIcon ) {

			these = GameObject.FindGameObjectsWithTag ("GoToIcon");

		
			for (int i = 0; i < these.Length; i++) {
			
				Destroy (these [i]);
				placeIcon = true;

				Debug.Log ("Should Instantiate");
				break;

			
			
			}

		
		}

		if (GameObject.FindGameObjectWithTag ("GoToIcon") == null || placeIcon) {

			Debug.Log ("In second");

			GameObject icon = Instantiate (goToHereIcon, targetPosition, Quaternion.identity) as GameObject;
			icon.transform.rotation = Quaternion.AngleAxis (90f,Vector3.right); 




		}

	
		Placing ();*/

	
	

		//--------------------------------------------------------------------
	
	}



	
	public void WhereAreWe(){
		target = GameObject.FindWithTag("Player").transform;
		//Debug.Log ("Transform position inside whereAreWe " + transform.position.x + ", " + transform.position.y + ", " + transform.position.z);
		//PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_X",target.transform.position.x);
		//PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_Z",target.transform.position.z);
		//PlayerPrefs.SetFloat("PLAYER_POSITION_NOW_Y",target.transform.position.y);
	}

	void MovePlayer(){
		transform.LookAt (targetPosition);
		transform.position = Vector3.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);

		//if we are at the target positino, then stop moving
		if(transform.position == targetPosition){
			isMoving = false;
		}
	}
}
