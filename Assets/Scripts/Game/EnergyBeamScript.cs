using UnityEngine;
using System.Collections;

public class EnergyBeamScript : MonoBehaviour {
	
	public float initiativeForce,lifeTime;
	public GameObject explosionAni;

	private Color initialColor;
	private float beginningTime,alphaValue;
	private SharedSpecsScript scoutShipScript;

	void Start () {

		initialColor = gameObject.GetComponent<SpriteRenderer> ().color;
		GetComponent<Rigidbody2D>().AddForce (transform.rotation * Vector2.up * initiativeForce, ForceMode2D.Force);
		beginningTime = Time.time;
		alphaValue = initialColor.a;

	}
	

	void Update () {

		

	}

	void FixedUpdate(){

		if (Time.time - beginningTime >= lifeTime*3f/4f) {
			
			alphaValue -= 0.05f;
			
		}

		gameObject.GetComponent<SpriteRenderer> ().color = new Color (initialColor.r, initialColor.g, 
		                                                              initialColor.b, alphaValue);
	
		if (Time.time - beginningTime >= lifeTime) {

			Destroy(gameObject);

				}

	}

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "Enemy") {

			Instantiate (explosionAni, transform.position, transform.rotation);
			scoutShipScript = coll.gameObject.GetComponent<SharedSpecsScript> ();
			scoutShipScript.healthPoints -= Random.Range (10f, 20f);
			Destroy (gameObject);

			}

	}
}
