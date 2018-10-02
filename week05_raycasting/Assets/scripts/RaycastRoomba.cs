using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: put this on a little cylinder in a test maze
// intent: a little roomba drone that can navigate a simple maze
// by using raycasts to sense walls, and then turn to avoid wall
public class RaycastRoomba : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// STEP 1: define a Ray...
		// *not* Vector3.forward, that's the WORLD'S forward
		// transform.forward = this object's current forward
		Ray eyeRay = new Ray( transform.position, transform.forward);
		
		// STEP 2: figure out a max distance?
		float maxRaycastDist = 1f;
		
		// STEP 3: (optional) visualize the raycast
		Debug.DrawRay( eyeRay.origin, eyeRay.direction * maxRaycastDist, Color.cyan);
		
		// STEP 4: shoot the raycast
		if (Physics.Raycast(eyeRay, maxRaycastDist))
		{
			// if it returns true, there's a wall, so we should turn randomly
			int randomNumber = Random.Range(0, 100);
			// if less than 50, turn left; otherwise, turn right
			if (randomNumber < 50)
			{
				transform.Rotate(0f, -90f, 0f);
			}
			else
			{
				transform.Rotate(0f, 90f, 0f);
			}
		}
		else
		{
			// go forward if raycast is FALSE (if there is no wall in front of us)
			transform.Translate(0f, 0f, Time.deltaTime);
		}
	}
}
