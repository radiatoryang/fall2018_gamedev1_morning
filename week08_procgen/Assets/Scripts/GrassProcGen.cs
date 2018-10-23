using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// USAGE: put this script on an empty GameObject called "GrassManager"
// INTENT: generate a field of grass using instantiation
public class GrassProcGen : MonoBehaviour
{

	public GameObject grassPrefab; // assign in Inspector!
	
	void Start () {
		// generate 500 blades of grass
		int grassCounter = 0;
		while (grassCounter < 500)
		{
			// as long as grassCounter < 500, repeat this code:
			Vector3 spawnPos = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f) );
			Instantiate(grassPrefab, spawnPos, Quaternion.Euler(0f, Random.Range(0, 360), 0) );
			
			grassCounter++; // increment counter
		}
	}

	void Update()
	{	// restart button
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(0);
		}
	}
	
}
