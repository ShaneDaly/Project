using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rocket : MonoBehaviour {

    public GameObject enemy;
    public GameObject[] enemies;
    public GameObject other;
    public int Speed; 
	public float timer = 5;
    float closestDist = -2;

	void Start ()
	{
		enemy=GameObject.FindGameObjectWithTag("Enemy");
	}

    void OnTriggerEnter(Collider enemy)
    {
        Destroy(gameObject);
		GetComponent<NewChase>().destroySelf ();
    }

    void Update () 
    {
        detectClosestEnemy();
        if (enemy != null)
        {

            
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(gameObject);
            }
            transform.LookAt(enemy.transform);
            transform.position += transform.forward * Speed * Time.deltaTime;
        }
    }

    public void detectClosestEnemy()
    {

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float newDist;
        foreach (GameObject element in enemies)
        {
            float dist = Vector3.Distance(element.transform.position, transform.position);
            newDist = dist;
            if (closestDist >= 0)
            {
                if (newDist < closestDist)
                {
                    closestDist = dist;
                    enemy = element;
                }
            }
            else
            {
                closestDist = dist;
                enemy = element;
            }

        }

    }

}
