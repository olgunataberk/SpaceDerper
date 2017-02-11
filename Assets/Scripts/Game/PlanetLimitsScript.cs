using UnityEngine;
using System.Collections;

public class PlanetLimitsScript : MonoBehaviour {

	public GameObject intruder;
	public bool isıntruded;

	void Start () {
	


	}
	

	void Update () {
	


	}

	void FixedUpdate(){



	}

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.name == "PlayerShip") {
						
						intruder = coll.gameObject;
						isıntruded = true;

				}

	}	
	void OnTriggerExit2D(Collider2D coll){

		if(coll.gameObject.name == "PlayerShip") {

			intruder = null;
			Destroy(intruder);
			isıntruded = false;
			
		}

	}

}
