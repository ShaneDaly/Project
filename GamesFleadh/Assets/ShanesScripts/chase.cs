using UnityEngine;
using System.Collections;

public class chase : MonoBehaviour {


	public int ammo;
	public float timer = 6;             
	private float rotSpeed= 4.0f;      
	float pauseDuration = 5;
	public Transform Planet;
	public float MoveSpeed= 20;
	private float RetreatSpeed = 15;
	public float InvestigateSpeed = 35;
	private int MaxDist= 2000;
	public int range = 30;
	public enum State {PatrolState,ShootState,InvestState,RetreatState,HealingState}
	public State state;
	private float curTime;
	public GameObject lasershot;
	public Transform shotspawn;
	GameObject[] planets = null;
	float closestDist = -2;
	private CharacterController character;	

	void  Start ()
	{
		character = GetComponent<CharacterController>();
		Planet = GameObject.FindWithTag("Planet").transform;
		state = State.InvestState;
	}

	void Awake ()
	{
		Planet = GameObject.FindWithTag("Planet").transform;
	}
	void  Update ()
	{
		TargetDistance ();
		detectClosestEnemy ();
		if (ammo <= 20) {
			state = State.RetreatState;
		} else {
			TargetDistance ();
		}

		switch (state)
		{
		case(State.InvestState):
		{
			Investigating ();
			break;
		}
		case(State.PatrolState):
		{
			Patrol ();
			break;
		}
		case(State.ShootState):
		{
			Shooting ();
			break;
		}
		case(State.RetreatState):
		{
			Retreat();
			break;
		}
		case(State.HealingState):
		{
			Healing();
			break;
		}
		}	
	}
	
	void Shooting ()
	{
		gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 0);
		Instantiate (lasershot, shotspawn.position, shotspawn.rotation);
	}
	
	void Healing()
	{
		gameObject.GetComponent<Renderer> ().material.color = new Color (255,192,203,0);
		transform.position += (transform.forward * -1)*RetreatSpeed*Time.deltaTime;
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			timer = 6;
			state = State.PatrolState;
		}

	}
	void Retreat()
	{
		gameObject.GetComponent<Renderer> ().material.color = new Color (0,0,0,0);
		transform.LookAt(Planet);
		transform.position += (transform.forward * -1)*MoveSpeed*Time.deltaTime;
	}
	void  Patrol ()
	{	  
	}
	void  Investigating ()
	{
		transform.LookAt(Planet);
		gameObject.GetComponent<Renderer> ().material.color = new Color (255,255,0,0);
		transform.position += transform.forward*InvestigateSpeed*Time.deltaTime;
	}
	
	public void TargetDistance()
	{
		if (Vector3.Distance (transform.position, Planet.transform.position) <= MaxDist && (Vector3.Distance(transform.position, Planet.transform.position) >= range) )
		{
			state = State.InvestState;
		} 
		else if (Vector3.Distance (transform.position, Planet.transform.position) <= range) 
		{
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
	public void ApplyDamage(int damage)
	{
		//health = health - damage;
	}

	public void destroySelf()
	{
		Destroy (gameObject);
	}
	
}
