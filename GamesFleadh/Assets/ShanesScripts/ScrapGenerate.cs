using UnityEngine;
using System.Collections;

public class ScrapGenerate : MonoBehaviour {

	public GameObject scrap;
	public GameObject[] scraps;
	//public int range = Random.value (1, 3);

	void Update()
	{
		if(Input.GetKey("space"))
		{
			Destroy(gameObject);
			Instantiate(scrap, transform.position, transform.rotation);
		}
	}
}