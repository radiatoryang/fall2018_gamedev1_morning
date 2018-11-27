using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on a sphere or something?
// INTENT: to show what unsmoothed / untweened / un-juicy movement looks like
public class NoTweenDemo : MonoBehaviour
{

	public Transform sphere, cube;
	
	// Update is called once per frame
	void Update ()
	{
		// move sphere towards cube without any acceleration / deceleration
		sphere.position = Vector3.MoveTowards(
			sphere.position,
			cube.position,
			0.1f
		);
	}
}
