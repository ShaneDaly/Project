using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour
{

	public Transform target;
	public float MoveSpeed = 4;
	public float MaxDistance = 10;
	public float MinDistance = 5;

	void Start () 
	{
		
	}

	void Update () 
	{
		transform.LookAt (target);
		
		if (Vector3.Distance (transform.position, target.position) >= MinDistance) {
			
			transform.position += transform.forward * MoveSpeed * Time.deltaTime;
			
			
			
			if (Vector3.Distance (transform.position, target.position) <= MaxDistance) {
				//Here Call any function U want Like Shoot at here or something
			} 
			
		}
	}
}