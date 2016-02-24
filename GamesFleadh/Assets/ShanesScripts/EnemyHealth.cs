using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health = 100;
	public int damage;
	public GameObject rocket;
	public GameObject scrap;

	void Awake ()
	{
		rocket = GameObject.FindGameObjectWithTag("Rocket") ;
	}

	void OnTriggerEnter (Collider rocket){
		health -= 10;
	}

	void Update () {

		if (health <= 0) {
			Destroy (gameObject);
			GetComponent<Spawner>().max -= 1;
			Instantiate(scrap, transform.position, transform.rotation);
		}
	
	}
}
