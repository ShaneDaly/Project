using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float health = 100;
	public float max = 100;
	public GameObject scrap;



	void Update () {

		if (health <= 0) {
<<<<<<< HEAD

			//gameObject.SetActive(false);
			Destroy(gameObject);

            //GetComponent<Spawner>().ReduceMax ();
=======
>>>>>>> c7a750b27c3eb47548b7e219d493c83a347893c1
            gameObject.SetActive(false);
			Instantiate(scrap, transform.position, transform.rotation);
		}
	
	}



}
