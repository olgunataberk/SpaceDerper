using UnityEngine;
using System.Collections;

public class PlayerShipControls : MonoBehaviour {

	public float speedLimit, forward_force, backwards_force, turn_rate;
	public GameObject explosionAni;

	private Vector2 heading;
	private bool goForward,goBack,turnLeft,turnRight;


	void Awake(){



	}

	void Start () {
	


	}
	

	void Update () {
	
		movement_cont ();

	}

	void FixedUpdate(){

		movement ();
	}

	void movement_cont(){

		if (Input.GetKeyDown (KeyCode.W)) {
			goForward = true;
		} else if(Input.GetKeyUp (KeyCode.W)) {
			goForward=false;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			goBack = true;
		} else if(Input.GetKeyUp (KeyCode.S)) {
			goBack=false;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			turnLeft = true;
		} else if(Input.GetKeyUp (KeyCode.A)) {
			turnLeft=false;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			turnRight = true;
		} else if(Input.GetKeyUp (KeyCode.D)) {
			turnRight=false;
		}

	}

	void movement(){

		heading = this.transform.rotation * Vector2.up;

		if (GetComponent<Rigidbody2D>().velocity.x <speedLimit && GetComponent<Rigidbody2D>().velocity.y < speedLimit) {
			
			if (goForward) {
				GetComponent<Rigidbody2D>().AddForce (heading * forward_force, ForceMode2D.Force);
			}
			if (goBack) {
				GetComponent<Rigidbody2D>().AddForce (heading * backwards_force * -1f, ForceMode2D.Force);
			}
		}
		if (turnLeft) {
			transform.rotation=Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,
			                                    transform.rotation.eulerAngles.z+turn_rate);
		}
		if (turnRight) {
			transform.rotation=Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,
			                                    transform.rotation.eulerAngles.z-turn_rate);
		}


	}

}
