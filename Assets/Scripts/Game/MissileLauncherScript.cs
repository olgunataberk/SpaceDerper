using UnityEngine;
using System.Collections;

public class MissileLauncherScript : MonoBehaviour {

	public GameObject missileıtself;
	public float missileCoolDown;

	private bool canFire;
    private float timeınterval;

	void Start () {
	
		canFire = false;
		timeınterval = -missileCoolDown;

	}
	

	void FixedUpdate(){

		fire ();
	}

	void Update () {
	


	}

	void fire(){

		if (Input.GetMouseButtonDown (1)&&Time.time-timeınterval >= missileCoolDown) {

			Instantiate(missileıtself,transform.position,transform.rotation);
			timeınterval=Time.time;

			}

	}

}
