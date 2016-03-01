﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rocket : MonoBehaviour {

    public GameObject enemy;
    public GameObject[] enemies;
    public int Speed; 
	public float timer = 5;
    float closestDist = -2;
    public GameObject homePlanet;
    PlanetStats homePlanetStats;
    public int damage;

    void Start()
    {

        homePlanetStats = homePlanet.GetComponent<PlanetStats>();
        damage = homePlanetStats.offence;
    }

    void OnTriggerEnter(Collider enemies)
    {
<<<<<<< HEAD
        Destroy(gameObject);
=======
        gameObject.SetActive(false);
<<<<<<< HEAD
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        enemyHealth.health -= damage;
=======
>>>>>>> 713328e4d1d173ed98a72932a3578dc440112160
>>>>>>> 18bed36e4a9358f2600e52f9da725d49c95c7465
    }

    void Update () 
    {
        detectClosestEnemy();
        if (enemy != null)
        {            
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                gameObject.SetActive(false);
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
