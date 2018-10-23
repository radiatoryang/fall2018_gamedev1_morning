using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on an empty GameObject called "TenPrint"
// INTENT: generate a 10PRINT-like pattern via instantiation
public class TenPrintDemo : MonoBehaviour
{
	// assign in Inspector!
	public Transform[] slashPrefabs;

	// Use this for initialization
	void Start () {
		
		// FOR LOOPS: basically a While() loop
		// int v=0 : init a counter var?
		// v<10 : if() statement to check?
		// v++ : increment the counter
		for (int v=0; v < 10; v++) // v = "vertical"
		{
			for (int h=0; h < 10; h++) // h = "horizontal"
			{
				Vector3 spawnPos = new Vector3(0f, v*5f, h*5f);

				// generate a random number from zero to [# of array elements]
				int randomIndex = Random.Range(0, slashPrefabs.Length);

				// instantiate a random object at [spawnPos] and preserve prefab's rotation
				Transform newClone = (Transform)Instantiate(
					slashPrefabs[randomIndex],
					spawnPos,
					slashPrefabs[randomIndex].rotation
				);
				
				// access the clone, do extra stuff with it
				newClone.localScale *= Random.Range(0.5f, 3f); // e.g., random scale
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
