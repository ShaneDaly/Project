using UnityEngine;
using System.Collections;

public class chase : MonoBehaviour {
	
	public int ammo;
	public float fireRate;
	private float nextFire;
	public float timer = 6;             
	private float rotSpeed= 4.0f;      
	float pauseDuration = 5;
	public Transform Planet;
	public float MoveSpeed= 20;
	public float RetreatSpeed = 20;
	public float InvestigateSpeed = 35;
	private int MaxDist= 2000;
	public int range = 30;
	public enum State {ShootState,InvestState,RetreatState}
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
		}	
	}
	
	void Shooting ()
	{
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (lasershot, shotspawn.position, shotspawn.rotation);
		}
	}
	

	public Transform CommandShip;
	void Retreat()
	{
		CommandShip = GameObject.FindWithTag("Ship").transform;
		transform.LookAt(CommandShip);
		//transform.position += (transform.forward * -1)*MoveSpeed*Time.deltaTime;
		transform.position += transform.forward*RetreatSpeed*Time.deltaTime;
		timer -= Time.deltaTime;
		if (timer <= 0) {
			//ammo = ammo + 1;
			timer = 6;
		}
	}

	void  Investigating ()
	{
		transform.LookAt(Planet);
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
			state = State.RetreatState;
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
