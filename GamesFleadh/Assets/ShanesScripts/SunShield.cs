using UnityEngine;
using System.Collections;

public class SunShield : MonoBehaviour {

	public int health = 1000;
	public GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");

	void Update ()
	{
		if (planets.Length <= 0) {
			Destroy (gameObject);
		}

	}

}
