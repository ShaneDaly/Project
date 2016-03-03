using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
     
	public GameObject enemy;   
	public float timer; 
	public float timer2;
	public float spawnTime = 4f;   
	public Transform[] spawnPoints;   
	EnemyHealth ship;
	
	void Start ()
	{
		timer = 3;
		timer2 = 10;
		//InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Update ()
	{
		
		ship = enemy.GetComponent<EnemyHealth> ();
		timer -= Time.deltaTime;
		if (timer <= 0) 
		{
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			timer = 3;
		}
		
		timer2 -= Time.deltaTime;
		if (timer2 <= 0) 
		{
			ship.health += ship.increase;
			timer2 = 10;
		}
	}
	

	void Spawn ()
	{	
	}
}