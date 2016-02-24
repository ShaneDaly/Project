using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health = 1000;
	public GameObject laser;

	void OnTriggerEnter (Collider laser)
	{
		health -= 1;
	}

	void Update ()
	{
		if (health <= 0) {
			Application.LoadLevel("gameOver");
		}
	}

}
