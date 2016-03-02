using UnityEngine;
using System.Collections;

public class PlanetAttack : MonoBehaviour {
	
    public GameObject enemy;
    public GameObject rocket;
    public GameObject planet;
    public Transform shotspawn;
    public GameObject[] enemies;
    float closestDist = -2;
	private Vector3 fwd;
    Rocket rocketCode;

    void Start()
    {
        planet = this.gameObject;
    }

	float timer = 0.0f;
	void Update () {

        detectClosestEnemy();
        if (enemy.tag == "Enemy")
        {
            float distance = Vector3.Distance(enemy.transform.position, planet.transform.position);
			fwd = transform.TransformDirection (Vector3.up);
			float dist = Vector3.Distance (enemy.transform.position, transform.position);
			if (dist < 100) 
			{
				timer += Time.deltaTime;
				
				if (timer > 2.0f)
				{
					timer -= 2.0f;
					Instantiate (rocket, shotspawn.position, shotspawn.rotation);
				}
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
