using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on an empty GameObject called "FishGod"
// INTENT: spawn and manage Fish objects
public class FishGod : MonoBehaviour
{

	public GameObject fishPrefab; // assign in Inspector

	// spawn 100 fish in Start()
	void Start () {
		int fishCounter = 0;
		while (fishCounter < 100)
		{
			Vector3 spawnPos = new Vector3(Random.Range(-50f, 50f), 0f, Random.Range(-50f, 50f) );
			Instantiate(fishPrefab, spawnPos, Quaternion.Euler(0f, Random.Range(0, 360), 0) );
			
			fishCounter++; // increment counter
		}
	}
	
}
