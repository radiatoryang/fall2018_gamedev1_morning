using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on an object to make it rotate
// INTENT: spin a thing
public class SpinningThing : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// rotate on X axis at 90 degrees per second
		transform.Rotate( 90f * Time.deltaTime, 0f, 0f);
	}
}
