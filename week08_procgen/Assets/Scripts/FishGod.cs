using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on an empty GameObject called "FishGod"
// INTENT: spawn and manage Fish objects
public class FishGod : MonoBehaviour
{

	public GameObject fishPrefab; // assign in Inspector

	// keep a list of spawned fish
	public List<GameObject> myFishList = new List<GameObject>();

	// spawn 100 fish in Start()
	void Start ()
	{
		int fishCounter = 0;
		while (fishCounter < 100)
		{
			Vector3 spawnPos = new Vector3(Random.Range(-50f, 50f), 0f, Random.Range(-50f, 50f) );
			GameObject newFish = (GameObject)Instantiate(fishPrefab, spawnPos, Quaternion.Euler(0f, Random.Range(0, 360), 0) );
			myFishList.Add( newFish ); // add new fish to list so we can access it later
			
			fishCounter++; // increment counter
		}
	}

	void Update()
	{
		// press P to tell all fish to return to (0,0,0)
		if (Input.GetKeyDown(KeyCode.P))
		{
			for (int i = 0; i < myFishList.Count; i++)
			{
				myFishList[i].GetComponent<Fish>().destination = Vector3.zero;
			}
		}
		
		// press TAB to randomize all fish sizes?
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			// foreach = like a for() loop but for everything in an array/list
			foreach (GameObject eachFish in myFishList)
			{
				eachFish.transform.localScale = Vector3.one * Random.value;
				// Vector3.one = shortcut for "new Vector3(1,1,1)"
				// Random.value = shortcut for "Random.Range(0f, 1f)"
			}
		}
		
		// some important list functions:
		
		// remove items from the list?
		// myFishList.RemoveAt(5); // removes fish #5 from the list
		
		// reset the list?
		// myFishList.Clear(); // removes ALL items, back to a blank empty list 
	}
	
}
