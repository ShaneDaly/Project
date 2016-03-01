﻿using UnityEngine;
using System.Collections;

public class chase : MonoBehaviour {

	public float fireRate;
	private float nextFire;
	public float timer = 6;                  
	public Transform Planet;
	public float Speed= 60;
	private int MaxDist= 2000;
	public int range = 30;
	public enum State {PatrolState,ShootState,InvestState}
	public State state;
	private float curTime;
	public GameObject lasershot;
	public Transform shotspawn;
	GameObject[] planets = null;
	Transform Waypoint;
	float closestDist = -2;
	private CharacterController character;	

	void  Start ()
	{
		character = GetComponent<CharacterController>();
		state = State.InvestState;
		//Waypoint = GameObject.FindWithTag("Waypoint").transform;
	}

	void Awake ()
	{
		Planet = GameObject.FindWithTag("Planet").transform;
	}
	void  Update ()
	{
		TargetDistance ();
		detectClosestEnemy ();

		switch (state)
		{
		case(State.InvestState):
		{
			Investigating ();
			break;
		}
		case(State.ShootState):
		{
			Shooting ();
			break;
		}
		case(State.PatrolState):
		{
			Patrolling ();
			break;
		}
			
		}	
	}	
	
	void Shooting ()
	{
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (lasershot, shotspawn.position, shotspawn.rotation);
		}
	}

	void  Investigating ()
	{
		transform.LookAt(Planet);
		transform.position += transform.forward*Speed*Time.deltaTime;
	}

	void Patrolling ()
	{
		//transform.LookAt(Waypoint);
		transform.position += transform.forward*Speed*Time.deltaTime;
	}
	
	public void TargetDistance()
	{
		if (Vector3.Distance (transform.position, Planet.transform.position) <= MaxDist && (Vector3.Distance (transform.position, Planet.transform.position) >= range)) {
			state = State.InvestState;
		} 
		else if (Vector3.Distance (transform.position, Planet.transform.position) <= range) {
			state = State.ShootState;
		} 
		else 
		{
			state = State.PatrolState;
		}
	}
	public void detectClosestEnemy()
	{
		
		planets = GameObject.FindGameObjectsWithTag ("Planet");
		float newDist;
		foreach (GameObject element in planets) {
			float dist = Vector3.Distance (element.transform.position, transform.position);
			newDist = dist;
			if (closestDist >= 0) {
				if (newDist < closestDist) {
					closestDist = dist;
					Planet = element.transform;
				}
			} else {
				closestDist = dist;
				Planet = element.transform;
			}
			
		}
	}

}
