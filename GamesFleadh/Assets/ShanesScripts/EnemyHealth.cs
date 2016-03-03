using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public float health = 100;
	//public int stage = 1;
	//int stageRec;
	//public int stageup;
	public float increase = 100;
	public float max = 500;
	public GameObject scrap;
	public GameObject rocket;

	void Start ()
	{
		//int stageRec = stage;
		//stageup = 1;
	}

	void Update () 
	{
		//if (stage != stageRec) {
		//	health += increase;
		//	stageRec = stage;
		//}

		if (health > max) 
		{
			health = max;
		}

		if (health <= 0) 
        {
            gameObject.SetActive(false);
			Instantiate(scrap, transform.position, transform.rotation);
		}
	
	}

}
