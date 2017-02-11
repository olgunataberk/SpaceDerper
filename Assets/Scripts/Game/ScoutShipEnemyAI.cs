using UnityEngine;
using System.Collections;

public class ScoutShipEnemyAI : MonoBehaviour {

	public float engageRange,turnSpeed,gunRange,forwardForce;
	public bool openFire;
	public GameObject explosionAnimation,boundPlanetLimits;

	private PlanetLimitsScript boundPlanetLimitScript;
	private bool interactWithEnemy;
	private GameObject[] alliedShips;
	private float timeHelper;
	private GameObject nearestEnemy;
	private Quaternion lookRotation,finalLookRotation;
	private Vector3 heading;

	void Awake(){

		boundPlanetLimitScript = boundPlanetLimits.GetComponent<PlanetLimitsScript> ();

	}

	void Start () {
	
		findAlliedShips();
		timeHelper = Time.time;

	}
	

	void Update () {
	


	}

	void FixedUpdate(){

		if (Time.time - timeHelper > 1f) {

			findAlliedShips();
			findıfEnemiesAreNear();
			timeHelper=Time.time;

		}

		movementınCombat ();

	}

	void movementınCombat(){

		if (interactWithEnemy) {


						lookRotation = Quaternion.LookRotation (nearestEnemy.transform.position - this.transform.position, Vector3.back);
						finalLookRotation = new Quaternion (0, 0, lookRotation.z, lookRotation.w);
						transform.rotation = Quaternion.Lerp (transform.rotation, finalLookRotation, Time.deltaTime * turnSpeed);
						heading = transform.rotation * Vector3.up;

						if (Vector2.Distance(transform.position,nearestEnemy.transform.position)<gunRange) {

								openFire = true;

						} else {

								GetComponent<Rigidbody2D>().AddForce (heading * forwardForce, ForceMode2D.Force);
								openFire = false;

						}

				} else {

			openFire = false;
				}


	}

	void findAlliedShips(){

		alliedShips = GameObject.FindGameObjectsWithTag ("Allied");

	}

	void findıfEnemiesAreNear(){

				
			if (alliedShips.Length < 1) {

				interactWithEnemy=false;

				}

			if (boundPlanetLimitScript.isıntruded&&alliedShips.Length > 0) {
						
						nearestEnemy = boundPlanetLimitScript.intruder;
						interactWithEnemy = true;
						
			} else {

						for (int i = 0; i<alliedShips.Length; i++) {

								if (Vector2.Distance(transform.position,alliedShips[i].transform.position)<engageRange) {

										nearestEnemy = alliedShips [i]; 
										interactWithEnemy = true;
										break;

								} else {

										interactWithEnemy = false;

								}

						}
				}
				
		}
}
