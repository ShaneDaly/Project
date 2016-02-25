using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
     
	public GameObject enemy;                
	public float spawnTime = 3f;   
	public int maxEn;
	public Transform[] spawnPoints;         
	
	
	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	public void ReduceMax ()
	{
		maxEn = maxEn - 1;
	}
	
	void Spawn ()
	{	
		if (maxEn <= 5) {
			// Find a random index between zero and one less than the number of spawn points.
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			maxEn += 1;
			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);

		}
	}
}