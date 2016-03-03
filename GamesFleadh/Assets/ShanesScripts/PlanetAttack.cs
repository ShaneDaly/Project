using UnityEngine;
using System.Collections;

public class PlanetAttack : MonoBehaviour {
	
    public GameObject enemy = null;
    public GameObject rocket;
    public GameObject planet;
    public Transform shotspawn;
    public GameObject[] enemies;
    float closestDist = -2;
	private Vector3 fwd;
    Rocket rocketCode;
    public float range = 100;

    void Start()
    {
        planet = this.gameObject;
    }

	float timer = 0.0f;
	void Update () 
    {
        detectClosestEnemy();
        if (enemy != null && enemy.activeSelf == true)
        {
            float distance = Vector3.Distance(enemy.transform.position, planet.transform.position);
			fwd = transform.TransformDirection (Vector3.up);
			float dist = Vector3.Distance (enemy.transform.position, transform.position);
			if (dist < range) 
			{
				timer += Time.deltaTime;
				
				if (timer > 2.0f)
				{
                    rocketCode = rocket.GetComponent<Rocket>();
                    rocketCode.homePlanet = planet;
					timer -= 2.0f;
                    Instantiate(rocket, transform.position, transform.rotation);
				}
			}
        }
	}

    public void detectClosestEnemy()
    {

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float newDist;
        if(enemies.Length > 0)
        {
            foreach (GameObject element in enemies)
            {
                float dist = Vector3.Distance(element.transform.position, transform.position);
                newDist = dist;
                if (closestDist >= 0)
                {
                    if (newDist <= closestDist)
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

}
