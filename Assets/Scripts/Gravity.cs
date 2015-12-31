using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gravity : MonoBehaviour {
	static Vector3 G = new Vector3(0.01f,0.01f,0.01f); // adjust with try & error

	Rigidbody[] planets;
	private Rigidbody myRigidbody;

	//for testing. Set the z value to give the planet an initial speed along it's z-axis
	public Vector3 initialForwardSpeed; 

	void  Start (){
		planets = FindObjectsOfType (typeof(Rigidbody)) as Rigidbody[];
		myRigidbody = GetComponent<Rigidbody>();
		myRigidbody.velocity = transform.TransformDirection(initialForwardSpeed);
	}
	void  Update (){
		Vector3 pos = myRigidbody.position;
		Vector3 acc = Vector3.zero;
		foreach(var planet in planets)
		{
			if (planet == myRigidbody)
				continue;
			Vector3 direction = (planet.position - pos);
			acc += G / (direction.normalized.magnitude / planet.mass) / direction.sqrMagnitude;
			Debug.Log(acc.ToString)
		}
		myRigidbody.velocity += acc; 
	}
}
