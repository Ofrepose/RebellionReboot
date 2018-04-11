using UnityEngine;
using System.Collections;

public class HealthBoxSpawner : MonoBehaviour {
	public GameObject healthBox;
	public float dropsPerSeconds = 0.05f;

	// Use this for initialization
	void Start () {
	
	}
	
	void HealthBoxPopulate(){
		Vector3 startPosition1 = new Vector3(10,7.62f,0);
		float randomPosition = Time.deltaTime * 10f;
		if (Random.value > randomPosition){
			foreach (Transform child in transform){
				GameObject healthboxdrop = Instantiate( healthBox, startPosition1, Quaternion.identity) as GameObject;
				healthboxdrop.transform.parent = child;		
			}	
		}
		float randomPosition2 = Time.deltaTime * 10f;
		Vector3 startPosition2 = new Vector3(-3.25f,7.62f,0);
		if (Random.value < randomPosition2){
			foreach (Transform child in transform){
				GameObject healthboxdrop = Instantiate( healthBox, startPosition2, Quaternion.identity) as GameObject;
				healthboxdrop.transform.parent = child;
			}
		}
	
	}
	
	
	// Update is called once per frame
	void Update () {
		float probability = Time.deltaTime * dropsPerSeconds;
		if (Random.value < probability){
			HealthBoxPopulate();
		}
	
	}
}
