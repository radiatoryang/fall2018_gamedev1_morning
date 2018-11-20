using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on an object with an Animator component
// PURPOSE: let us control a dancing dude with keyboard input
public class AnimatorInput : MonoBehaviour
{

	Animator myAnimator;

	void Start ()
	{	// cache reference to the Animator component
		myAnimator = GetComponent<Animator>();
	}
	
	void Update () {
		// press SPACE to dance; don't press SPACE to don't dance
		if (Input.GetKey(KeyCode.Space))
		{
			myAnimator.SetBool("isDancing", true);
		}
		else
		{
			myAnimator.SetBool("isDancing", false);
		}
	}
	
}
