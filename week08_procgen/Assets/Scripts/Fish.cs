using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on a cube called "FishCube"
// INTENT: simple Fish AI, swim towards destination
public class Fish : MonoBehaviour
{
	public Vector3 destination;
	public float swimSpeed = 5f;
	
	void Update ()
	{
		// move fish's position towards destination at [swimSpeed] rate
		transform.position = Vector3.MoveTowards(
			transform.position,
			destination,
			swimSpeed * Time.deltaTime
		);
		
		// optional debug visualization: show where fish is swimming
		Debug.DrawLine(transform.position, destination, Color.yellow);
		
		// pick a random destination if we reach our current destination
		if ( (transform.position - destination).magnitude < 2f)
		{
			destination = new Vector3(
				Random.Range(-10f, 10f),
				Random.Range(-10f, 10f),
				Random.Range(-10f, 10f)
			);
		}
		
		// look at its destination
		transform.LookAt( destination );
		
	}
	
}
