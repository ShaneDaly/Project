using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float health = 100;
	public float max = 100;

	public GameObject rocket;
	public GameObject scrap;

	void Awake ()
	{
		rocket = GameObject.FindGameObjectWithTag("Rocket") ;
	}

	void OnTriggerEnter (Collider rocket)
	{
		health -= 10;
	}

	void Update () {

		if (health <= 0) {
			//gameObject.SetActive(false);
			Destroy(gameObject);
			Instantiate(scrap, transform.position, transform.rotation);
		}
	
	}
}
