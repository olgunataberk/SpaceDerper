using UnityEngine;
using System.Collections;

public class AnimationFinishTimerScript : MonoBehaviour {


	public float aniLength,aniSpeed;
	private float timeHelper;

	void Start () {
	
		timeHelper = Time.time;

	}
	

	void Update () {
	
		if (Time.time - timeHelper >= aniLength / aniSpeed) {

			Destroy(gameObject);

				}

	}
}
