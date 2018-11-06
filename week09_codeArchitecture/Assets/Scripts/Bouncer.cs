using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on a thing to hover up and down
// INTENT: make thing hover up and down / bounce
public class Bouncer : MonoBehaviour
{
	Vector3 startPos;

	void Start ()
	{	// remember where we started before we bounce
		startPos = transform.position;
	}
	
	void Update ()
	{	// move position up/down from startPos, based on sine wave
		transform.position = startPos + Vector3.up * Mathf.Sin(Time.time);
	}
}
