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
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	

	void Spawn ()
	{	
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		maxEn += 1;
		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}
}