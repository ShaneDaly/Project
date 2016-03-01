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
<<<<<<< HEAD
			//gameObject.SetActive(false);
			Destroy(gameObject);
=======
            //GetComponent<Spawner>().ReduceMax ();
            gameObject.SetActive(false);
>>>>>>> 713328e4d1d173ed98a72932a3578dc440112160
			Instantiate(scrap, transform.position, transform.rotation);
		}
	
	}



}
