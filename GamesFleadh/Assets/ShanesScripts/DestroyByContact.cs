using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject other;


	void OnTriggerEnter(Collider other)
	{
		Destroy(other);

	}
	
}