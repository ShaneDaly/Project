using UnityEngine;
using System.Collections;

public class SunShield : MonoBehaviour {

	public int health = 1000;
	public GameObject[] planets;
	public int num;

	void Awake ()
	{
		planets = GameObject.FindGameObjectsWithTag ("Planet");
		num = planets.Length;
	}

	public void ReduceNum()
	{
		num = num - 1;
	}

	void Update ()
	{
		if (num <= 0) {
			Destroy (gameObject);
		}

	}

}
