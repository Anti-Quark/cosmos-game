using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gravity : MonoBehaviour {
	static float G = 1000; // adjust with trial & error

	Rigidbody[] planets;
	private Rigidbody myRigidbody;

	//for testing. Set the z value to give the planet an initial speed along it's z-axis
	public Vector3 initialForwardSpeed; 

	void  Start (){
		planets = FindObjectsOfType (typeof(Rigidbody)) as Rigidbody[];
		Debug.Log (planets);
		myRigidbody = GetComponent<Rigidbody>();
		myRigidbody.velocity = transform.TransformDirection(initialForwardSpeed);
	}
	void  Update (){
		Vector3 pos = myRigidbody.position;
		float force = 0;
		Vector3 dir = new Vector3 (0, 0, 0);
		foreach(var planet in planets)
		{
			if (planet == myRigidbody)
				return;
			dir = planet.position - pos;
			force = G * (myRigidbody.mass / planet.mass) / Vector3.Distance(pos, planet.position); //Newton's law of universal gravitation
			//Debug.Log (planet.mass);
			//Debug.Log (Vector3.Distance (pos, planet.position));
			//Debug.Log (force); 
			Debug.Log(dir.ToString());
			myRigidbody.AddForce (dir * force);
		}
	}
}
