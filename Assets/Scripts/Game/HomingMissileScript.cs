using UnityEngine;
using System.Collections;

public class HomingMissileScript : MonoBehaviour {

	public float turnRate,missileSpeed;
	public GameObject explosionAniMissile;

	private SharedSpecsScript targetScript;
	private Quaternion wtwRotation,yiwRotation;
	private GameObject target;
	private Camera mainCamRef;
	private int enemiesLength;
	private float initialDistance,deathTimer;
	private Vector2 mouseCoords;
	private bool targetNone;
	private Vector3 velVec,targetVel;/* FOR SMARTER HOMıNG MıSSıLES */

	void Awake(){

		mainCamRef = GameObject.Find ("Main Camera").GetComponent<Camera> ();

	}

	void Start () {

		deathTimer = Time.time;
		mouseCoords = mainCamRef.ScreenToWorldPoint (Input.mousePosition);
		initialDistance = 10000;
		enemiesLength = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		if (enemiesLength == 0) {

			target = new GameObject();
			target.transform.position = mouseCoords;
			targetNone=true;

				}
		for (int k=0; k<enemiesLength; k++) {

			if(Vector2.Distance(mouseCoords,GameObject.FindGameObjectsWithTag ("Enemy")[k]
			                    .transform.position)<initialDistance){

				target = GameObject.FindGameObjectsWithTag ("Enemy")[k];
				initialDistance = Vector2.Distance(mouseCoords,GameObject.FindGameObjectsWithTag ("Enemy")[k]
				                                   .transform.position);

			}


		}

	}
	

	void FixedUpdate () {

		if (Time.time - deathTimer > 15f) {

			Instantiate(explosionAniMissile,transform.position,transform.rotation);
			Destroy(gameObject);

				}

		wtwRotation = Quaternion.LookRotation (target.transform.position - transform.position, Vector3.back);
		yiwRotation = new Quaternion (0, 0, wtwRotation.z, wtwRotation.w);
		transform.rotation = Quaternion.Lerp(transform.rotation,yiwRotation,Time.deltaTime*turnRate);
		GetComponent<Rigidbody2D>().velocity = transform.up * missileSpeed;
		if (targetNone) {

			if(Vector2.Distance(target.transform.position,transform.position)<0.5f){

				Instantiate(explosionAniMissile,transform.position,transform.rotation);
				Destroy(gameObject);
				Destroy(target);

			}

				}

	}

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "Enemy") {

			Instantiate(explosionAniMissile,transform.position,transform.rotation);
			targetScript = coll.gameObject.GetComponent<SharedSpecsScript>();
			targetScript.healthPoints-=Random.Range(80f,120f);
			Destroy(gameObject);

		}

	}

}
