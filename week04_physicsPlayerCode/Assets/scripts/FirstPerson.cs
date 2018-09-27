using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: put this on a capsule with a Rigidbody
// this should handle mouselook as well as WASD movement
public class FirstPerson : MonoBehaviour
{

	public float lookSpeed = 300f;
	public float moveSpeed = 10f;
	Vector3 inputVector; // pass keyboard data from Update() to FixedUpdate()
	
	// Update is called once per frame, this is where INPUT and RENDERING happens!!!
	void Update () {
		// mouse look
		
		// mouseDelta = difference, how fast you're moving your mouse
		// if it's "0" that means the mouse isn't moving
		// this is NOT mouse position (mouse position is Input.mousePosition)
		float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime; // mouseX = horizontal mouseDelta
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime; // mouseY = vertical mouseDelta
		
		// negative mouseX = moving your mouse to the left, etc.
		// negative mouseY = moving your mouse downwards, etc.
		
		// "pitch yaw roll", X Y Z
		// rotating on X axis, up/down, is "pitch"
		// rotating on Y axis, left/right, is "yaw"
		// rotating on Z axis is "roll"
		
		// simplest possible mouse-look: just rotate camera naively
		// Camera.main.transform.Rotate(-mouseY, mouseX, 0f);
		
		// slightly better mouse-look:
		// rotate capsule left/right, but rotate camera up/down
		transform.Rotate(0f, mouseX, 0f); // capsule rotation
		Camera.main.transform.localEulerAngles += new Vector3(-mouseY, 0f, 0f); // camera rotation
		// Camera.main.transform.Rotate(-mouseY, 0f, 0f); // this is the same thing as the line above
		
		// 1 big problem with this: camera keeps rolling anyway
		
		// solution: after applying rotations, un-roll the camera
		// this is what we want to do, but can't: Camera.main.transform.localEulerAngles.z = 0f;
		Camera.main.transform.localEulerAngles -= new Vector3(
			0f,
			0f,
			Camera.main.transform.localEulerAngles.z
		);
		
		
		// first-person player movement

		float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down on keyboard, -1 for down, +1 for up
		float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right on keyboard, -1 is left, +1 right
		
		// simplest possible method: move transform based on keyboard values
		// vertical (forward) movement:
		// transform.position += transform.forward * vertical * moveSpeed * Time.deltaTime;
		// horizontal (strafe) movement:
		// transform.position += transform.right * horizontal * moveSpeed * Time.deltaTime;
		// multiply by Time.deltaTime to make it "framerate INDEPENDENT", more consistent across machines

		// this "simplest method" is bad because we are moving transform directly
		// when you move transform directly, you're basically teleporting it, no collision detection
		
		// a better method: move using Rigidbody forces in FixedUpdate(), which won't have same problems
		inputVector = transform.forward * vertical * moveSpeed; // forward / backward direction
		inputVector += transform.right * horizontal * moveSpeed; // left / right direction
		
	}

	// FixedUpdate runs all the time, every physics frame (physics runs at a different framerate than everything else)
	void FixedUpdate() // all physics code should go in FixedUpdate!!!
	{
		// apply our forces to move the object around
		GetComponent<Rigidbody>().velocity = inputVector + Physics.gravity * 0.1f; // no need for Time.deltaTime, already fixed framerate

		// one problem: gravity doesn't work anymore
		
	}
	
	
}
