using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public GameObject enemy;                
	public float spawnTime = 3f;            
	public Transform[] spawnPoints;    
	public int enemies;
	public int max = 10;
	
	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	
	void Spawn ()
	{

		if (enemies < max) {	

			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		

			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			enemies += 1;
		}
	}
}