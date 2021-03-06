﻿using UnityEngine;
using System.Collections;


public class SatelliteHealth : MonoBehaviour 
{

    public float startHealth;
    float orgHealth;
    float orgMax;
    [SerializeField]
    private float max;
    [SerializeField]
    private float health;
    public float Length;
    public float timer = 10;
    public GameObject healthBar;
    public GameObject other;
    public GameObject scrap;
    [SerializeField]
    private float defence;
    float startDefence;
    SatelliteStats satelliteStats;
    Satelite code;

    void Start()
    {
        satelliteStats = gameObject.GetComponent<SatelliteStats>();
        defence = (satelliteStats.defence / 10.0f) + 1;
        max = defence * startHealth;
        health = defence * startHealth;
        startDefence = defence;
        code = gameObject.GetComponent<Satelite>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            decreaseHealth();
            float calc_Health = health / max;
            SetHealthBar(calc_Health);
        }
    }

    void decreaseHealth ()
	{
		health -= 1;
	}

	public void SetHealthBar (float myHealth)
	{
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
	
	


	void Update () 
    {
        defence = (satelliteStats.defence / 10.0f) + 1;
        if (defence != startDefence)
        {
            max = defence * max;
            health = defence * health;
            startDefence = defence;
        }

        if (health <= 0) 
        {
            code.destroyPlanet();
            gameObject.tag = "Untagged";
            Instantiate(scrap, transform.position, transform.rotation);
		}
	}

}
