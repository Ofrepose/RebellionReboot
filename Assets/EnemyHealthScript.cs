using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour {

	SingleFightScriptPlace singleFight;

	public TextMesh enemyHealthText;

	public float enemyHealthHere;

	EnemyFireAndDamage enemyHealthSingleFight;

	TwoEnemiesAttackingScript enemyHealthMultipleFight;

	public GameObject textObject;



	void Start () {

		singleFight = SingleFightScriptPlace.FindObjectOfType<SingleFightScriptPlace> ();



		if (singleFight != null) {
		
			enemyHealthSingleFight = EnemyFireAndDamage.FindObjectOfType<EnemyFireAndDamage> ();

			enemyHealthHere = enemyHealthSingleFight.EnemyHealth;
		
		}

		if (singleFight == null) {
		
			enemyHealthMultipleFight = TwoEnemiesAttackingScript.FindObjectOfType<TwoEnemiesAttackingScript> ();

			enemyHealthHere = enemyHealthMultipleFight.EnemyHealth;
		
		}
		
	}


	public void ReceiveDamage(int amount){

		int thisAmount = amount * -1;

		//GetComponent<TextMesh> ().text = thisAmount.ToString ();

		enemyHealthText.text = thisAmount.ToString ();

		Vector3 herePos = this.transform.position;



		GameObject texxt = Instantiate (textObject, herePos, Quaternion.identity) as GameObject;

		texxt.transform.rotation = Quaternion.Euler (0, 270, 0);



		//enemyHealthText.text = thisAmount.ToString ();



	}

}
