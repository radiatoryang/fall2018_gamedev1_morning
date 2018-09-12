using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put this script on a Cube to make it move with WASD
public class Simple3DTest : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// if we hold down W, move cube forward
		if (Input.GetKey(KeyCode.W))
		{
			// moves cube 0.1 units on Z axis, every frame
			// transform.position += new Vector3(0f, 0f, 0.1f);
			// commented ^ out because that's for GLOBAL space, ignores rotation
			
			// move cube 0.1 units on local Z axis, accounting for rotation...
			transform.Translate(0f, 0f, 0.1f);
		}
		
		// if we hold down A, rotate left
		if (Input.GetKey(KeyCode.A))
		{
			// rotate 15 degrees counter-clockwise on Y axis
			transform.eulerAngles += new Vector3(0f, -15f, 0f);
			// DO NOT use transform.rotation
			// transform.rotation is a QUATERNION
		}
		
		// if hold down D, rotate right
		if (Input.GetKey(KeyCode.D))
		{
			// rotate 5 degrees clockwise on Y axis
			transform.Rotate(0f, 5f, 0f);
		}
	}
}
