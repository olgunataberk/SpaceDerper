using UnityEngine;
using System.Collections;

public class IndicatorScript : MonoBehaviour {

	private GameObject parentShip,cameraRef;
	private Vector3 shipPosition,newındicatorPosition;

	void Awake(){

		cameraRef = GameObject.Find ("Main Camera");
		parentShip = transform.parent.gameObject;

	}

	void Start () {
	


	}
	

	void Update () {
	


	}

	void FixedUpdate(){

		shipPosition = cameraRef.GetComponent<Camera>().WorldToScreenPoint(parentShip.transform.position);
		indicate ();
		newındicatorPosition = cameraRef.GetComponent<Camera>().ScreenToWorldPoint(newındicatorPosition);
		newındicatorPosition.z = transform.position.z;
		transform.position = newındicatorPosition;


	}

	void indicate(){

		if (shipPosition.x <= 0) {

			if(shipPosition.y <= 0){

				gameObject.GetComponent<SpriteRenderer>().enabled=true;
				newındicatorPosition = new Vector3(0+10,0+10,parentShip.transform.position.z);

			}

			if(shipPosition.y >= Screen.height){

				gameObject.GetComponent<SpriteRenderer>().enabled=true;
				newındicatorPosition = new Vector3(0+10,Screen.height-10,parentShip.transform.position.z);

			}

			if(shipPosition.y >= 0 && shipPosition.y <= Screen.height){

				gameObject.GetComponent<SpriteRenderer>().enabled=true;
				newındicatorPosition = new Vector3(0+10,shipPosition.y,parentShip.transform.position.z);

			}

		}

		if (shipPosition.x >= Screen.width) {

			if(shipPosition.y <= 0){

				gameObject.GetComponent<SpriteRenderer>().enabled=true;
				newındicatorPosition = new Vector3(Screen.width-10,0+10,parentShip.transform.position.z);
				
			}
			
			if(shipPosition.y >= Screen.height){

				gameObject.GetComponent<SpriteRenderer>().enabled=true;
				newındicatorPosition = new Vector3(Screen.width-10,Screen.height-10,parentShip.transform.position.z);
				
			}

			if(shipPosition.y >= 0 && shipPosition.y <= Screen.height){

				gameObject.GetComponent<SpriteRenderer>().enabled=true;
				newındicatorPosition = new Vector3(Screen.width-10,shipPosition.y,parentShip.transform.position.z);
				
			}

		}

		if (shipPosition.x >= 0 && shipPosition.x <= Screen.width) {

			if(shipPosition.y <= 0){

				gameObject.GetComponent<SpriteRenderer>().enabled=true;
				newındicatorPosition = new Vector3(shipPosition.x,0+10,parentShip.transform.position.z);
				
			}
			
			if(shipPosition.y >= Screen.height){

				gameObject.GetComponent<SpriteRenderer>().enabled=true;
				newındicatorPosition = new Vector3(shipPosition.x,Screen.height-10,parentShip.transform.position.z);
				
			}

			if(shipPosition.y >= 0 && shipPosition.y <= Screen.height){

				gameObject.GetComponent<SpriteRenderer>().enabled=false;
			}

		}



	}
}
