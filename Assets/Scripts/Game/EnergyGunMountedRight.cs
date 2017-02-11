using UnityEngine;
using System.Collections;

public class EnergyGunMountedRight : MonoBehaviour {

	public GameObject energyBeam,cameraMain,mountedShip;
	public float coolDown,rotateSpeed;
	
	private bool fire;
	private Vector3 targetLocation,ptype1,ptype2,maxLeftRotation,maxRightRotation;
	private float timeınterval,beginningZ;
	private Quaternion rotationFinal,rotationTemp;
	
	void Start () {
		
		timeınterval = Time.time;
		beginningZ = transform.position.z;
		maxLeftRotation = new Vector3 (0, 0, 8f);				
		maxRightRotation = new Vector3 (0, 0, 346f);		
		rotationTemp = transform.rotation;
	}
	
	void Update () {
		
		if (Input.GetMouseButton (0)) {
			fire = true;
			
		} else {
			fire = false;
		}
		
		
	}
	
	void FixedUpdate(){
		
		Fire ();
		rotateTurret ();
		updateMaxRotations ();
	}
	
	void Fire(){
		
		if (fire && Time.time - timeınterval >= coolDown) {
			
			Instantiate(energyBeam,transform.position,transform.rotation);
			timeınterval = Time.time;
		}
		
	}
	
	void rotateTurret(){
		
		targetLocation = cameraMain.GetComponent<Camera>().ScreenToWorldPoint (Input.mousePosition);
		targetLocation.z = beginningZ;
		Quaternion rotation = Quaternion.LookRotation
			(targetLocation - transform.position, Vector3.back);
		ptype1 = mountedShip.transform.rotation.eulerAngles;
		ptype2 = rotationFinal.eulerAngles;
		
		if (returnFixedAngle (ptype2.z, ptype1.z,false) > 8f && returnFixedAngle (ptype2.z, ptype1.z,false) < 180f) {
			
			rotationTemp.eulerAngles = maxLeftRotation;
			transform.rotation = Quaternion.Lerp (transform.rotation, rotationTemp, rotateSpeed * Time.deltaTime);	
		}
		if (returnFixedAngle (ptype2.z, ptype1.z,false) < 346f && returnFixedAngle (ptype2.z, ptype1.z,false) > 180f) {
			
			rotationTemp.eulerAngles = maxRightRotation;
			transform.rotation = Quaternion.Lerp (transform.rotation, rotationTemp, rotateSpeed * Time.deltaTime);
			
		}
		if (returnFixedAngle (ptype2.z, ptype1.z,false) < 8f || returnFixedAngle (ptype2.z, ptype1.z,false) > 346f) {
			
			
			transform.rotation = Quaternion.Lerp (transform.rotation, rotationFinal, rotateSpeed * Time.deltaTime);	
			
			
		}
		
		rotationFinal = new Quaternion(0, 0, rotation.z, rotation.w);
	}
	
	private float returnFixedAngle(float f1,float f2,bool addOrdecrease){
		
		if (!addOrdecrease) {
			if (f1 - f2 <= 0) {
				
				return(360f + (f1 - f2));
				
			} else if (f1 - f2 > 0) {
				
				return(f1 - f2);
				
			} else {
				
				return(0);
				
			}
		}
		if (addOrdecrease) {
			
			if (f1 + f2 < 360) {
				
				return(f1 + f2);
				
			} else if (f1 + f2 > 360) {
				
				return((f1 + f2)-360f);
				
			} else {
				
				return(0);
				
			}
			
		} else {
			
			return(0);
		}
	}
	void updateMaxRotations(){
		
		maxLeftRotation.z = returnFixedAngle (mountedShip.transform.rotation.eulerAngles.z, 14f,true);
		maxRightRotation.z = returnFixedAngle (mountedShip.transform.rotation.eulerAngles.z, 8f, false);

		
	}
}
