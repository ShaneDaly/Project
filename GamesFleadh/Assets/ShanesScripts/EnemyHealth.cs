using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float health = 100;
	public float max = 500;
	public GameObject scrap;
	public GameObject rocket;
	[SerializeField]
	private int countdown;
	Spawner spawner;

	void Start ()
	{
		spawner = gameObject.GetComponent<Spawner> ();
		countdown = spawner.countdown;
	}

	void Update () {

		if (countdown >= 2) 
		{
			health += 100;
		}
		if (health <= 0) 
        {

            gameObject.SetActive(false);
			Instantiate(scrap, transform.position, transform.rotation);
		}
	
	}

}
