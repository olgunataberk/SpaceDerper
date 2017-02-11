using UnityEngine;
using System.Collections;

public class SharedSpecsScript : MonoBehaviour {

	public float healthPoints;
	public GameObject deathAnimation;

	void Start () {
	


	}
	

	void Update () {
	
	}

	void FixedUpdate(){

		death ();

	}

	void death(){

		if (healthPoints <= 0) {

			Instantiate(deathAnimation,transform.position,transform.rotation);
			Destroy(gameObject);

				}

	}
}
