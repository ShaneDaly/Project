using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {

	PlanetStats Stats;

	void Start () {
		Stats = GetComponent<PlanetStats> ();
	}

	void Update () {
<<<<<<< HEAD
		if (Input.GetMouseButtonDown (0)) 
        {
			Destroy (gameObject);
=======
		if (Input.GetMouseButtonDown (0)) {

>>>>>>> 66bdad823fee23ca85dcffdf2dec5d4067467d83

		}
	}
}
