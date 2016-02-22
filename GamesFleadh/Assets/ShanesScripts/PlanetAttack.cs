using UnityEngine;
using System.Collections;

public class PlanetAttack : MonoBehaviour {

    public GameObject enemy;
    public GameObject rocket;
    public Transform planet;
    public float timer;
    public Transform shotspawn;
    public GameObject[] enemies;
    float closestDist = -2;

	void Update () {

        detectClosestEnemy();
        if (enemy.tag == "Enemy")
        {

            float distance = Vector3.Distance(enemy.transform.position, planet.transform.position);
            timer -= Time.deltaTime;
            if (distance <= 200 && timer <= 0)
            {
                Instantiate(rocket, shotspawn.position, shotspawn.rotation);
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
