﻿using UnityEngine;
using System.Collections;

public class ReverseOrbit : MonoBehaviour 
{
	public float RotationSpeed = -100f;
	public float OrbitSpeed = 50f;
	public float DesiredMoonDistance;
	public Transform target;
	
	void Start () 
	{
		DesiredMoonDistance = Vector3.Distance(target.position, transform.position);
	}
	
	void Update () 
	{
		transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
		transform.RotateAround(target.position, Vector3.up, OrbitSpeed * Time.deltaTime);
		
		//fix possible changes in distance
		float currentMoonDistance = Vector3.Distance(target.position, transform.position);
		Vector3 towardsTarget = transform.position - target.position;
		transform.position += (DesiredMoonDistance - currentMoonDistance) * towardsTarget.normalized;
	}
}