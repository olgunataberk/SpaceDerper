using UnityEngine;
using System.Collections;

public class FormBackground : MonoBehaviour {

	public GameObject starB,starıF;
	public SpriteRenderer background;

	private GameObject starsbg,starsfg;
	private Vector3 starSize,mapSize;
	private float minXcoor,maxXcoor,minYcoor,maxYcoor,currentXcoor,currentYcoor;

	void Awake(){

		starsbg = GameObject.Find ("Stars_BG");
		starsfg = GameObject.Find ("Stars_FG");
	}

	void Start () {

		setThings ();
		placeStars ();
	}



	void Update () {

	}

	void FixedUpdate(){



	}



	void setThings(){

		starSize=starB.GetComponent<Renderer>().bounds.size;
		mapSize = background.bounds.size;
		minXcoor = mapSize.x / 2*-1f;
		maxXcoor = mapSize.x / 2;
		minYcoor = mapSize.y / 2*-1f;
		maxYcoor = mapSize.y / 2;
		currentXcoor = minXcoor;
		currentYcoor = minYcoor;
	}

	void placeStars(){

	 	while (currentXcoor<maxXcoor+starSize.x) {

			if(currentYcoor>=maxYcoor){
				currentYcoor=minYcoor;
			}

			while(currentYcoor<maxYcoor){

				currentYcoor+=starSize.y;
				GameObject StarBx,StarıFx;
				StarBx = Instantiate(starB,new Vector3(currentXcoor,currentYcoor,starB.transform.position.z),starB.transform.rotation) as GameObject;
				StarBx.transform.parent=starsbg.transform;
				StarıFx = Instantiate(starıF,new Vector3(currentXcoor,currentYcoor,starıF.transform.position.z),starıF.transform.rotation) as GameObject;
				StarıFx.transform.parent=starsfg.transform;
			}
			currentXcoor+=starSize.x;
		}

	}
}
