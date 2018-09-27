using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: put this on a Cube with a Rigidbody
// intent: this will let the player control a Car, kind of
public class CarControl : MonoBehaviour
{

	Rigidbody rBody;
	Vector2 inputVector;

	// remember: Unity will use public value in the INSPECTOR, not code
	public float moveSpeed = 10f;
	public float turnSpeed = 90f;

	// Use this for initialization
	void Start ()
	{
		// cache reference to Rigidbody
		rBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// Input.GetAxis return a number between -1f and 1f... 0f if nothing is happening
		// horizontal = A/D on keyboard, Left=-1 / Right=+1
		float horizontal = Input.GetAxis("Horizontal");
		// vertical = W/S on keyboard, Up=+1 / Down=-1
		float vertical = Input.GetAxis("Vertical");
		
		// put input into a vector for physics forces in FixedUpdate
		inputVector = new Vector2( horizontal, vertical);
	}

	// runs every physics frame (to change it, see Edit > Project Settings > Time)
	void FixedUpdate()
	{
		// forward / backward thrust
		rBody.AddForce( transform.forward * inputVector.y * moveSpeed);
		
		// left / right turning
		rBody.AddTorque( 0f, inputVector.x * turnSpeed, 0f);
	}
	
}
