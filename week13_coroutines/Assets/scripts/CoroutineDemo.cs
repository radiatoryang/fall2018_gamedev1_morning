using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this script on a third sphere or something?
// INTENT: show how to tween with a coroutine
public class CoroutineDemo : MonoBehaviour
{
	// assign in Inspector
	public Transform sphere, cube;
	
	// declare a tweening curve
	public AnimationCurve myTweenCurve;

	void Start () {
		// DO NOT DO THIS:
		// MyFirstCoroutine(); // this won't work
		
		// YOU HAVE TO DO IT LIKE THIS:
		StartCoroutine( MyFirstCoroutine() );
	}
	
	// a coroutine is a function where we control how fast it runs / how long it runs
	// a coroutine always returns IEnumerator
	IEnumerator MyFirstCoroutine()
	{
		Debug.Log("Started the coroutine!");
		yield return 0; // pause for 1 frame, then continue...
		Debug.Log("OK, I waited 1 frame, continuing...");
		yield return 1; // this also means "wait 1 frame"
		yield return null; // this also means "wait 1 frame"
		Debug.Log("OK, I waited for 2 more frames, now continuing...");
		
		// if you want to wait for seconds, use WaitForSeconds
		yield return new WaitForSeconds(1f); // pause for 1 sec
		Debug.Log("finished waiting 1 more second...");

		// wait for duration of the coroutine
		yield return StartCoroutine( TweenCoroutine() );
		Debug.Log("finished waiting for Tween coroutine to end");
		
		// end of coroutine, it terminates by itself
	}

	// you can have more than 1 coroutine running at a time
	IEnumerator TweenCoroutine()
	{
		float t = 0f; // t is "time"
		// remember where sphere started
		Vector3 startPos = sphere.position;
		Vector3 endPos = cube.position;
		// use while() loop to increment time var
		while (t < 1f)
		{
			// sphere.position = Vector3.Lerp(startPos, endPos, t);
			
			// Lerp will clamp t between 0-1, so use LerpUnclamped
			sphere.position = Vector3.LerpUnclamped(
				startPos, 
				endPos, 
				myTweenCurve.Evaluate(t)
			);
			t += Time.deltaTime / 2f; // lerp over 2 sec
			yield return 0; // wait a frame
		}
	}
	
}
