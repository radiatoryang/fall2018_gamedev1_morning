using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put this script on a trigger
public class TriggerTest : MonoBehaviour {

	// for OnTriggerEnter to work, at least one of the objects
	// must have a Rigidbody
	void OnTriggerEnter(Collider activator)
	{
		// when something enters this trigger, destroy / delete it
		// Destroy( activator ); // will only delete the Collider
		Destroy( activator.gameObject ); // will destroy whole thing
		// Destroy( this.gameObject ); // destroy this trigger?
		
	}
	
	
}
