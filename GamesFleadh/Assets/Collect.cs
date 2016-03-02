using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {

	PlanetStats Stats;

	void Start () {
		Stats = GetComponent<PlanetStats> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) 
        {

		}
	}
}
