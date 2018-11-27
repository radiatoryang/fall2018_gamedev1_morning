using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on a sphere? or whatever
// INTENT: make the sphere tween towards the cube, in a variety of ways
public class TweenDemo : MonoBehaviour
{
	// assign in Inspector
	public Transform sphere, cube;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// recreate simple tweening equation from Juice It Or Lose It
		// x += (target - x) * 0.1
		// every frame, move 10% of the remaining distance
		sphere.position += (cube.position - sphere.position) * 0.1f;
	}
}
