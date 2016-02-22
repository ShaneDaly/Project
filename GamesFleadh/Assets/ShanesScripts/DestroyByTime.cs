using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	public float timer = 3;

	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Destroy (gameObject);
		}
	}
}
