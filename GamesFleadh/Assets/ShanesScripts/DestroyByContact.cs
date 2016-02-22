using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject other;
	public int health = 100;

	void OnTriggerEnter(Collider other)
	{
		Destroy(other);
		if (health >= 1) {
			health -= 1;
			if (health <= 0){
				Destroy (gameObject);
			}
		}
	}
	
}