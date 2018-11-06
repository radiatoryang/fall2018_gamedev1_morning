using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on objects to make them clickable
// INTENT: enlarge the object when clicked
public class Clickable : MonoBehaviour {

	// a Unity shortcut function that automatically raycasts from mouse cursor for you
	// kind of like a button?
	void OnMouseDown()
	{
		// enlarge object slightly
		transform.localScale *= 1.05f; // to 105% of current size
		
		// give 1 point each time you click
		MyManager.instance.myScore += 1;
		// this uses a STATIC reference! no GetComponent or public var required
	}
	
}
