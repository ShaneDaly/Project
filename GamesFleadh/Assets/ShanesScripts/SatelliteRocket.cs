﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SatelliteRocket : MonoBehaviour {

    public GameObject enemy;
    public GameObject[] enemies;
    public int Speed; 
	public float timer = 5;
    float closestDist = -2;
    public GameObject homeSatellite;
    SatelliteStats homeSatelliteStats;
    public int damage;
    public GameObject rocketExpolsion;
    RocketExplosion rocketExpolsionStats;

    void Start()
    {

        homeSatelliteStats = homeSatellite.GetComponent<SatelliteStats>();
        damage = homeSatelliteStats.offence;
    }

    void OnTriggerEnter(Collider enemyCol)
    {

        if (enemyCol.gameObject.tag != "Laser")
        {

            rocketExpolsionStats = rocketExpolsion.GetComponent<RocketExplosion>();
            rocketExpolsionStats.damage = damage;
            Instantiate(rocketExpolsion, transform.position, rocketExpolsion.transform.rotation);
            gameObject.SetActive(false);
        }
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
