using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
     
	public GameObject enemy;   
	public float timer; 
	public float timer2;
    float timer3;
	public float spawnTime = 4f;   
	public Transform[] spawnPoints;   
	EnemyHealth ship;
	
	void Start ()
	{
		timer = 5;
		timer2 = 10;
        timer3 = timer;
        //InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

	void Update ()
	{
		if (timer3 < 1)
        {
            timer3 = 1;
        }
		ship = enemy.GetComponent<EnemyHealth> ();
		timer -= Time.deltaTime;
		if (timer <= 0) 
		{
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			timer = timer3;
            timer3 -= 0.05f;
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