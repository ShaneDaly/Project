using UnityEngine;
using System.Collections;

public class ScrapGenerate : MonoBehaviour {

	public GameObject scrap;
	public GameObject[] scraps;

	void Update()
	{
		if(Input.GetKey("space"))
		{
			Destroy(gameObject);
			Instantiate(scrap, transform.position, transform.rotation);
		}
	}
}