using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on a Cube?
// INTENT: (grounded check) to know if it is resting on ground or not?
public class RaycastGrounded : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// STEP 1: define a Ray
		Ray myRay = new Ray(transform.position, Vector3.down);
		
		// STEP 2: define the distance of the raycast
		float myRaycastMaxDist = 0.6f; // a bit longer than half of the height
		
		// STEP 3: (optional) visualize the raycast
		Debug.DrawRay( myRay.origin, myRay.direction * myRaycastMaxDist, Color.yellow );
		
		// STEP 4: let's finally cast some raycasts!!!
		// raycasts return TRUE or FALSE, so ideal for if() statements
		if (Physics.Raycast(myRay, myRaycastMaxDist))
		{
			// if true (if the raycast hit a collider), then...
			Debug.Log("grounded is TRUE!");
			transform.Rotate(0f, 5f, 0f); // debug: spin if on the ground?
		}
		else
		{
			// if false (if the raycast DID NOT hit the floor?), then...
			// ... do nothing?
		}
	}
	
}
