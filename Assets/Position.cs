using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	void OnDrawGizmos(){
		//shows the outline of object not yet created by other scripts ie enemy ship clones not yet called
		Gizmos.DrawWireSphere (transform.position, 1);
	
	
	}
}
