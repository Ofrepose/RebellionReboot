using UnityEngine;
using System.Collections;

public class testing : MonoBehaviour {


	void Update(){
		transform.Translate (Vector3.forward * Time.deltaTime * 1);
	}
}