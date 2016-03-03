using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
     
	public GameObject enemy;   
	public float timer = 20;
	public int countdown = 0;
	public float spawnTime = 4f;   
	public Transform[] spawnPoints;         
	
	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Update ()
	{
		timer -= Time.deltaTime;
		if (timer <= 0) 
		{
			spawnTime -= 1;
			countdown += 1;
			timer = 5;
			//timer = 20 + (5 * countdown);
		}
	}
	

	void Spawn ()
	{	
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}
}