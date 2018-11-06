using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on an empty GameObject called "Manager"
// INTENT: game manager that tracks global score
public class MyManager : MonoBehaviour {
	
	// manager objects usually are "singletons"
	// "singleton" = only one instance exists at a time
	
	// very simple singleton: make a static reference to this gameObject
	public static MyManager instance;
	// "static" means "global", means anything in the codebase can access it

	// tracks my score in the game
	public int myScore = 0;

	void Start ()
	{	// populate the singleton reference
		instance = this;
	}
	
	void Update () {
		// very simple win condition:
		// if you get 31 points, you win the game
		if (myScore >= 31)
		{
			Debug.Log("YOU WIN!!!!");
		}
	}
}
