using UnityEngine;
using System.Collections;

public class MenuKontrol : MonoBehaviour {

	public GameObject mainCamera;
	public Sprite yeniCikisTexture,yeniPrimaryBarTexture;
	private Sprite eskiCikisTexture,eskiPrimaryBarTexture;

	void Awake(){



	}

	void Start () {
	
		Cursor.visible = false;

	}
	

	void Update () {
	


	}

	void FixedUpdate(){

		cursorMovement();

	}

	void cursorMovement(){

		Vector3 tempPos = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
		tempPos.z = 0;
		transform.position = tempPos;

	}

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.name == "CikisBar") {

			eskiCikisTexture = coll.gameObject.GetComponent<Renderer>().GetComponent<SpriteRenderer>().sprite;
			coll.gameObject.GetComponent<Renderer>().GetComponent<SpriteRenderer>().sprite = yeniCikisTexture;
			
		}

		if (coll.gameObject.name == "OynaBar") {
			
			eskiPrimaryBarTexture = coll.gameObject.GetComponent<Renderer>().GetComponent<SpriteRenderer>().sprite;
			coll.gameObject.GetComponent<Renderer>().GetComponent<SpriteRenderer>().sprite = yeniPrimaryBarTexture;
			
		}

		if (coll.gameObject.name == "AyarlarBar") {
			
			eskiPrimaryBarTexture = coll.gameObject.GetComponent<Renderer>().GetComponent<SpriteRenderer>().sprite;
			coll.gameObject.GetComponent<Renderer>().GetComponent<SpriteRenderer>().sprite = yeniPrimaryBarTexture;
			
		}

		if (coll.gameObject.name == "CreditsBar") {
			
			eskiPrimaryBarTexture = coll.gameObject.GetComponent<Renderer>().GetComponent<SpriteRenderer>().sprite;
			coll.gameObject.GetComponent<Renderer>().GetComponent<SpriteRenderer>().sprite = yeniPrimaryBarTexture;
			
		}


	}

	void OnTriggerStay2D(Collider2D coll){

				if (coll.gameObject.name == "OynaBar") {

						if (Input.GetMouseButtonDown (0)) {

								Application.LoadLevel (1);
			
						}
		
				}
				
				if (coll.gameObject.name == "CikisBar") {
					
					if(Input.GetMouseButtonDown(0)){
						
								Application.Quit();
						
					}
					
				}

		}

	void OnTriggerExit2D(Collider2D coll){

		if (coll.gameObject.name == "CikisBar") {

			coll.gameObject.GetComponent<Renderer>().GetComponent<SpriteRenderer>().sprite = eskiCikisTexture;
			
		}

		if (coll.gameObject.name == "OynaBar") {

			coll.gameObject.GetComponent<Renderer>().GetComponent<SpriteRenderer>().sprite = eskiPrimaryBarTexture;
			
		}
		
		if (coll.gameObject.name == "AyarlarBar") {

			coll.gameObject.GetComponent<Renderer>().GetComponent<SpriteRenderer>().sprite = eskiPrimaryBarTexture;
			
		}
		
		if (coll.gameObject.name == "CreditsBar") {

			coll.gameObject.GetComponent<Renderer>().GetComponent<SpriteRenderer>().sprite = eskiPrimaryBarTexture;
			
		}

	}

}
