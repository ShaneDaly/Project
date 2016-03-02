using UnityEngine;
using System.Collections;

public class RocketExplosion : MonoBehaviour {


    public GameObject enemy;
    public GameObject[] enemies;
    public int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {

            EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
            enemyHealth.health -= damage;
        }
    }
}
