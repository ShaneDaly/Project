using UnityEngine;
using System.Collections;

public class chase : MonoBehaviour {
	public int health = 100;
	public float timer = 6;             
	private float rotSpeed= 4.0f;      
	float pauseDuration = 5;
	public Transform Planet;
	public float MoveSpeed= 20;
	private float RetreatSpeed = 15;
	public float InvestigateSpeed = 35;
	private int MaxDist= 90;
	public int range = 40;
	public enum State {PatrolState,ShootState,InvestState,RetreatState,HealingState}
	public State state;
	private float curTime;
	private int currentWaypoint = 0;
	public GameObject lasershot;
	public Transform shotspawn;
	private CharacterController character;

	public Transform[] waypoint;	
	public Transform Waypoint;
	public Vector3 target;
	public Vector3 direction;
	public Vector3 velocity;
	public bool patrol;
	
	void  Start ()
	{
		character = GetComponent<CharacterController>();
		Planet = GameObject.FindWithTag("Planet").transform;
		state = State.PatrolState;
	}

	void Awake ()
	{
		Waypoint = GameObject.FindWithTag("Waypoint").transform;
	}

	void  Update ()
	{
		if (health <= 0) {
			this.gameObject.SetActive (false);
		} 
		else if (health <= 20) {
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

		/*if (health < 100) {
			timer -= Time.deltaTime;
			if (timer <= 0){
				health += 1;
				if(health == max)
				{
					timer = 6;
				}
			}
		}*/

	}
	void Retreat()
	{
		gameObject.GetComponent<Renderer> ().material.color = new Color (0,0,0,0);
		transform.LookAt(Planet);
		transform.position += (transform.forward * -1)*MoveSpeed*Time.deltaTime;
	}
	void  Patrol ()
	{
		gameObject.GetComponent<Renderer> ().material.color = new Color (0,204,0,0);
		if (currentWaypoint < waypoint.Length) {
			target = waypoint [currentWaypoint].position;
			direction = target - transform.position;

			if (direction.magnitude < 1) {
				currentWaypoint++;
			} else {
				velocity = direction.normalized * MoveSpeed;
			}
		} 
		else 
		{
			if(patrol){
				currentWaypoint = 0;
			}
			else{
				velocity = Vector3.zero;
			}
		}

		gameObject.GetComponent<Rigidbody>().velocity = velocity;
		transform.LookAt (target);
		  
	}
	void  Investigating ()
	{
		transform.LookAt(Planet);
		gameObject.GetComponent<Renderer> ().material.color = new Color (255,255,0,0);
		transform.position += transform.forward*InvestigateSpeed*Time.deltaTime;
	}
	
	
	/*void  Chasing ()
	{
		gameObject.GetComponent<Renderer> ().material.color = new Color (255,0,0,0);
		transform.LookAt(Planet);
		transform.position += transform.forward*MoveSpeed*Time.deltaTime;
	}*/
	
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
	public void ApplyDamage(int damage)
	{
		health = health - damage;
	}

	public void destroySelf()
	{
		Destroy (gameObject);
	}
	
}
