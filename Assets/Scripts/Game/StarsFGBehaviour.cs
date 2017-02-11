using UnityEngine;
using System.Collections;

public class StarsFGBehaviour : MonoBehaviour {

	public float slowness,timeSpeed;

	private GameObject cameraobj;
	private Vector3 targetLoc;
	private float zAtBeginning;

	void Awake(){

		cameraobj = GameObject.Find ("Main Camera");

	}


	void Start () {
	
		zAtBeginning=transform.position.z;

	}
	

	void Update () {
	


	}

	void FixedUpdate(){

		targetLoc = cameraobj.transform.position;
		targetLoc.z = zAtBeginning;
		transform.position = Vector3.Lerp (transform.position, targetLoc / slowness, Time.deltaTime * timeSpeed);

	}
}
