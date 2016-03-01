using UnityEngine;
using System.Collections;

public class SatelliteAttack : MonoBehaviour {

    public GameObject enemy;
    public GameObject rocket;
    public GameObject satellite;
    public float timer;
    public Transform shotspawn;
    public GameObject[] enemies;
    float closestDist = -2;
    SatelliteRocket rocketCode;

    void Start()
    {
        satellite = this.gameObject;
    }


	void Update () {

        detectClosestEnemy();
        if (enemy.tag == "Enemy")
        {

            float distance = Vector3.Distance(enemy.transform.position, satellite.transform.position);
            timer -= Time.deltaTime;
            if (distance <= 200 && timer <= 0)
            {
                
                rocketCode = rocket.GetComponent<SatelliteRocket>();
                rocketCode.homeSatellite = satellite;
                Instantiate(rocket, satellite.transform.position, satellite.transform.rotation);
                timer = 3;
            }
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
