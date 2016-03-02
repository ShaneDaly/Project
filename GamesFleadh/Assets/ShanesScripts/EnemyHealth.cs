using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float health = 100;
	public float max = 100;
	public GameObject scrap;
	public GameObject rocket;


	void Update () {

		if (health <= 0) 
        {

            gameObject.SetActive(false);
			Instantiate(scrap, transform.position, transform.rotation);
		}
	
	}

}
