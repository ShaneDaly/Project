using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float health = 100;
	public float max = 100;
	public int damage;
	public GameObject rocket;
	public GameObject scrap;
	public GameObject healthBar;

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
			//GetComponent<Spawner>().ReduceMax ();
			Instantiate(scrap, transform.position, transform.rotation);
		}
	
	}
}
