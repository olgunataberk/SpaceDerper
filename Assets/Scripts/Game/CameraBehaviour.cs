using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	public float smoothness,viewRange;

	private float timeLeft;
	private bool moveCam,movelastLoc,cameraLocked;
	private Transform playerTransform;
	private Vector3 targetLocation,lastLocation,playerLocation,mousePosition;
	private float maxZoom, minZoom,zoom;

	void Awake(){

		playerTransform = GameObject.Find ("PlayerShip").transform;
		
	}

	void Start () {

		zoom = GetComponent<Camera>().orthographicSize;
		minZoom = 10f;
		maxZoom = 3f;

	}

	void Update () {

		if(Input.GetAxis("Mouse ScrollWheel")<0){
				
				zoom+=1f;
				if(zoom>minZoom){

						zoom=minZoom;

					}
				this.GetComponent<Camera>().orthographicSize=zoom;
		   
		}

		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {

				zoom-=1f;
				if(zoom<maxZoom){
				
					zoom=maxZoom;
				
					}
				this.GetComponent<Camera>().orthographicSize=zoom;

		}

		if (Input.GetKeyDown (KeyCode.Space)) {

			cameraLocked=!cameraLocked;

		}

	}

	void FixedUpdate(){

		viewRange = zoom * 8f / 5f;
		mousePosition = Input.mousePosition;
		targetLocation = GetComponent<Camera>().ScreenToWorldPoint(mousePosition);
		if (playerTransform != null) {
				playerLocation = playerTransform.position;
				playerLocation.z = transform.position.z;
				moveCamera ();
		}

	}

	void moveCamera(){

		if (!cameraLocked) {

						if (Vector2.Distance (playerTransform.position, targetLocation) < viewRange) {
								moveCam = true;
								movelastLoc = false;
					
			
						}
						if (Vector2.Distance (playerTransform.position, targetLocation) > viewRange && moveCam) {
								lastLocation = targetLocation;
								moveCam = false;
								movelastLoc = true;
								timeLeft = Time.time;
			
						}

						if (moveCam) {

								transform.position = Vector3.Lerp (transform.position, targetLocation, Time.deltaTime * smoothness);

						}
						if (movelastLoc && Time.time - timeLeft < 2f) {

								transform.position = Vector3.Lerp (transform.position, lastLocation, Time.deltaTime * smoothness);
			
						} else if (movelastLoc && Time.time - timeLeft > 2f) {

								transform.position = Vector3.Lerp (transform.position, playerLocation, Time.deltaTime * smoothness);
						}


				} else {

						transform.position = playerLocation;

				}

	}

}
