using UnityEngine;
using System.Collections;

public class ChainGunScript : MonoBehaviour {

	public GameObject ballisticBullet;
	public ScoutShipEnemyAI parentScript;

	private float timeHelper;
	void Start () {
	
		timeHelper = Time.time;

	}
	

	void Update () {
	


	}

	void FixedUpdate(){

		openFire ();

	}

	void openFire(){

		if (parentScript.openFire&&Time.time-timeHelper>0.1f) {

			Instantiate(ballisticBullet,transform.position,transform.rotation);
			timeHelper = Time.time;

		}

	}
}
