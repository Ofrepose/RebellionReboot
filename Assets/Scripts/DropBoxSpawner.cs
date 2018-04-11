using UnityEngine;
using System.Collections;

public class DropBoxSpawner : MonoBehaviour {
	public GameObject dropbox;
	public float dropsPerSeconds=0.0005f;
	

	// Use this for initialization
	void Start () {
		
			
		}
	
	
	
	
	void DropBoxPopulate(){
		Vector3 startPosition1 = new Vector3(5,7.62f,0);
		
		float randomizedPositioning = Time.deltaTime *10f;
		if (Random.value > randomizedPositioning){
			foreach (Transform child in transform){
				GameObject dropboxdrop = Instantiate(dropbox, startPosition1, Quaternion.identity) as GameObject;
				dropboxdrop.transform.parent = child;
				Debug.Log("Drop box one has been created");
			}
		}
		float randomizedPositioning2 = Time.deltaTime *10f;
		Vector3 StartPosition2= new Vector3(-3.08f,7.65f,0);
		if (Random.value < randomizedPositioning2){
			foreach (Transform child in transform){
				GameObject dropboxdrop = Instantiate(dropbox, StartPosition2, Quaternion.identity) as GameObject;
				dropboxdrop.transform.parent = child;
				Debug.Log("Drop box one has been created");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		float probability = Time.deltaTime * dropsPerSeconds;
		if (Random.value < probability){
			DropBoxPopulate();
		}
	
	}
	

}
