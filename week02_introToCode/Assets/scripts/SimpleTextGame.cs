using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this is a text game where the player
// can hold down the SPACEBAR to win
public class SimpleTextGame : MonoBehaviour
{
	public Text myTextDisplay;
	float myScore = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// input code: hold down space to get points
		if (Input.GetKey(KeyCode.Space))
		{
			// Time.deltaTime is the duration of the frame in seconds
			// 60 FPS, dT = 1/60... 0.01666f, small values
			myScore += Time.deltaTime;
			myTextDisplay.text = "get exactly 10.0f to win!";
			myTextDisplay.text += "\ncurrent score: " + myScore.ToString();
			Debug.Log( "current score: " + myScore.ToString() );
		}
		
		// cheat code: press C to get exactly 10?
		if (Input.GetKeyDown(KeyCode.C))
		{
			myScore = 10f;
			myTextDisplay.text = "you got exactly 10! YOU CHEATED THO";
		}
	}
}
