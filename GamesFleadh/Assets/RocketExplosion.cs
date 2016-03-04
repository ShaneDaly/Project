using UnityEngine;
using System.Collections;

public class RocketExplosion : MonoBehaviour {


    public GameObject enemy;
    public GameObject[] enemies;
    public int damage;
    float timer = 1;
    

	// Use this for initialization
	void Start () 
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, gameObject.GetComponent<SphereCollider>().radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.activeSelf && hitColliders[i].gameObject.tag == "Enemy")
            {
                EnemyHealth enemyHealth = hitColliders[i].GetComponent<EnemyHealth>();
                enemyHealth.health -= damage;
            }

            i++;
        }
	
	}

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
	
}
