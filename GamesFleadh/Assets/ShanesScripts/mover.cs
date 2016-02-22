using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {

	public float speed;
	public float timer = 2;
	public GameObject other;

	void Start () {
		GetComponent<Rigidbody> ().velocity = transform.forward * speed;

	}

	void OnTriggerEnter(Collider other)
	{
		Destroy (gameObject);
	}

	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Destroy(gameObject);
		}
	}
}
