using UnityEngine;
using System.Collections;

public class NextLevelBoundary : MonoBehaviour {
	private LevelManager levelmanager;

	void OnTriggerEnter2D(Collider2D col){
		//destroy(col.gameObject) grabs whatever object enters the collider and destroys it
		//make sure the border box collider and the gameobject have colliders attached to them!!
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
