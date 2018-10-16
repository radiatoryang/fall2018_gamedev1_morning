using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: put this script on an AudioSource
// intent: demo how to control sound playback in various ways
public class SoundPlaybackDemo : MonoBehaviour
{

	AudioSource myAudio;

	void Start ()
	{ // cache reference to AudioSource at start of play mode
		myAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		// simplest example: just play a sound when I press space
		if (Input.GetKeyDown(KeyCode.Space))
		{
			myAudio.Play();
		}
		
		// another example: hold W to play a sound?
		if (Input.GetKey(KeyCode.W))
		{
			// bad example: will constantly restart the sound all the time
//			Debug.Log("playing the sound!");
//			myAudio.Play();
			
			// fixed example: play the sound ONLY if not already playing
			if (myAudio.isPlaying == false)
			{
				myAudio.Play();
			}
		}
		else
		{ // stop playing as soon as we release [W]?
		//	myAudio.Stop(); // NOTE: comment this out if you need PlayOneShot below
		}
		
		// example: click repeatedly to play many uninterruptable sounds
		if (Input.GetMouseButtonDown(0))
		{ // PlayOneShot: play a sound that can't be interrupted or controlled
			myAudio.PlayOneShot( myAudio.clip );
		}
		
	}
}
