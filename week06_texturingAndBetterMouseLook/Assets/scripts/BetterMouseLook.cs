using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: put this on a Cube with a MainCamera parented to it
public class BetterMouseLook : MonoBehaviour
{

	public float lookSpeed = 300f;

	// BETTER MOUSE LOOK, 11 Oct 2018: store Mouse Y rotation in this variable and clamp it
	float upDownRotation; 
	
	// Update is called once per frame, this is where INPUT and RENDERING happens!!!
	void Update () {
		// mouse look
		
		// mouseDelta = difference, how fast you're moving your mouse
		// if it's "0" that means the mouse isn't moving
		// this is NOT mouse position (mouse position is Input.mousePosition)
		float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime; // mouseX = horizontal mouseDelta
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime; // mouseY = vertical mouseDelta
		
		// slightly better mouse-look:
		// rotate capsule left/right, but rotate camera up/down
		transform.Rotate(0f, mouseX, 0f); // capsule rotation
		
		// BETTER MOUSE LOOK, 11 Oct 2018: add mouseinput to upDownRotation AND clamp upDownRotation
		upDownRotation -= mouseY;
		upDownRotation = Mathf.Clamp(upDownRotation, -80, 80); // clamp vertical look rotation between -80/+80 degrees
		
		// apply rotation
		Camera.main.transform.localEulerAngles = new Vector3(
			upDownRotation,
			0f,
			0f
		);
		
		// BETTER MOUSE LOOK, 11 Oct 2018: lock and hide the mouse cursor
		// important: do this when the player clicks (NOT in Start)
		if (Input.GetMouseButtonDown(0)) // 0 = left-click
		{
			Cursor.lockState = CursorLockMode.Locked; // lock cursor in center of screen
			Cursor.visible = false; // hide the cursor too, just to be safe
		}
		
	}
	
	
}