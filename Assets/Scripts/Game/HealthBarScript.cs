using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	public float hpBarScaleX, objHealthPoints;

	private SharedSpecsScript parentScript;
	private Vector3 hpScale;
	private SpriteRenderer thisSpriteRenderer;
	private float thatOne;
	private Color thatColor;

	void Awake(){

		thisSpriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		parentScript = GetComponentInParent<SharedSpecsScript> ();
	}

	void Start () {

		hpScale = transform.localScale;
		thisSpriteRenderer.color = Color.green;
		thatColor = thisSpriteRenderer.color;
	}

	void FixedUpdate(){

		hpScale.x =	parentScript.healthPoints/objHealthPoints*hpBarScaleX;
		transform.localScale = hpScale;
		thatOne = hpScale.x / hpBarScaleX;
		colorify();
	}

	void colorify(){

		if (thatOne > 0.5f) {

			thatColor.r = (1f-thatOne)*2f;

		}

		else if(thatOne < 0.5f){

			thatColor.r = 1f;
			thatColor.g = thatOne*2f;
		}

		thisSpriteRenderer.color = thatColor;	
	}
}
