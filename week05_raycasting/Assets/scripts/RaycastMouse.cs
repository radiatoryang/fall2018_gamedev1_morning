using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: put this on your Main Camera (also, make sure it's tagged MainCamera)
// intent: let us move / paint spheres on a wall with mouse cursor
public class RaycastMouse : MonoBehaviour
{

	public Transform mySphere; // assign in Inspector
	
	// Update is called once per frame
	void Update () {
		// STEP 1: define a Ray
		// to generate a Ray based on mouse cursor, use ScreenPointToRay
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		// STEP 2: define maximum distance; after this dist, the raycast gives up
		float maxDistance = 1000f;
		
		// STEP 2B: define a RaycastHit to remember where it hit
		RaycastHit mouseRayHit = new RaycastHit(); // inits a blank variable, no data yet

		// STEP 3: (optional) visualize debug line in Scene view
		Debug.DrawRay( mouseRay.origin, mouseRay.direction * maxDistance, Color.yellow);
		
		// STEP 4: cast the ray!!!
		if (Physics.Raycast(mouseRay, out mouseRayHit, maxDistance))
		{
			// if true, that means it hit something
			// so move sphere to where the raycast hit the thing
			mySphere.position = mouseRayHit.point; // RaycastHit.point = world pos where it hit
			
			// to check the tag (if you wanted to)
			if (mouseRayHit.collider.tag == "Whatever Tag")
			{
				Debug.Log("the raycast hit object was tagged!");
			}
			
			// we can also access the object we hit with the raycast
			mouseRayHit.transform.Rotate(0f, 0f, 1f);
			
			// INSTANTIATE:
			// cloning an object at runtime
			// mouseRayHit.point = spawn location for new clone
			// Quaternion.Euler() = generates a Quaternion from an Euler Angle
			if ( Input.GetMouseButton(0) )
			{
				Instantiate(mySphere, mouseRayHit.point, Quaternion.Euler(0f, 0f, 0f));
			}
		}
	}
	
}
