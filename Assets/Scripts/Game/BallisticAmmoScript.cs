using UnityEngine;
using System.Collections;

public class BallisticAmmoScript : MonoBehaviour {
	
	public float initiativeForce,lifeTime;
	public GameObject explosionAni;
	
	private float beginningTime;
	private SharedSpecsScript targetShipScript;

	void Start () {
		
		GetComponent<Rigidbody2D>().AddForce (transform.rotation * Vector2.up * initiativeForce, ForceMode2D.Force);
		beginningTime = Time.time;
		
	}
	
	
	void Update () {
		
		
		
	}
	
	void FixedUpdate(){
		
		if (Time.time - beginningTime >= lifeTime) {
			
			Destroy(gameObject);
			
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D coll){
	

		if (coll.gameObject.tag == "Allied") {

				targetShipScript = coll.gameObject.GetComponentInParent<SharedSpecsScript> ();
				targetShipScript.healthPoints -= Random.Range (1f, 3f);
				Instantiate (explosionAni, transform.position, transform.rotation);
				Destroy (gameObject);

		}
				
	}
}