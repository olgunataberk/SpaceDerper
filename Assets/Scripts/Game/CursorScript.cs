using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {

	private Camera mainCamRef;

	void Awake() {

		mainCamRef = GameObject.Find ("Main Camera").GetComponent<Camera> ();

	}

	void Start () {
	
	}
	

	void Update () {
	
	}

	void FixedUpdate() {

		Vector3 tempVect;
		tempVect = mainCamRef.ScreenToViewportPoint(Input.mousePosition);
		tempVect.z = 0f;
		transform.position = tempVect;
	}
}
