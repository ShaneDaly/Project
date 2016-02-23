using UnityEngine;
using System.Collections;

public class NewChase : MonoBehaviour {
	public int health = 100;
	public float timer = 6;
	float time = 0f;
	public Transform[] waypoint;             
	private float rotSpeed= 4.0f;      
	float pauseDuration = 5;
	public Transform planet;
	private float MoveSpeed= 50;
	private float RetreatSpeed = 15;
	private float InvestigateSpeed = 35;
	private int MaxDist= 100;
	public int InvestigateDist = 100;
	public enum State {PatrolState,ShootState,InvestState,RetreatState,HealingState}
	public State state;
	private float curTime;
	private int currentWaypoint = 0;
	public GameObject lasershot;
	public GameObject rocket;
	public Transform shotspawn;
    private CharacterController character;
    GameObject[] planets = null;
    float closestDist = -2;

	public Vector3 target;
	public Vector3 direction;
	public Vector3 velocity;

	RaycastHit hit;
	private Vector3 fwd;
	
	void  Start ()
	{
		character = GetComponent<CharacterController>();
		planet = GameObject.FindWithTag("Planet").transform;
		state = State.PatrolState;
	}
	void OnTriggerCollider (Collider rocket)
	{
		health -= 20;
	}
	void  Update ()
	{
        detectClosestEnemy();
		if (health <= 0) {
			this.gameObject.SetActive (false);
		} 
		else if (health <= 20 || ammo <= 0) {
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


	public int ammo = 1000;
	void Shooting ()
	{
        Quaternion finalrotation = Quaternion.LookRotation(planet.transform.position - transform.position, Vector3.up);
		gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 0);
		Instantiate (lasershot, shotspawn.position, finalrotation);
		ammo -= 1;	
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
		transform.LookAt(planet);
		transform.position += (transform.forward * -1)*MoveSpeed*Time.deltaTime;

	}
	void  Patrol ()
	{
		/*gameObject.GetComponent<Renderer> ().material.color = new Color (0,204,0,0);
		if (currentWaypoint < waypoint.Length) {
			target = waypoint [currentWaypoint].position;
			direction = target - transform.position;
			
			if (direction.magnitude < 1) {
				currentWaypoint++;
			} else {
				velocity = direction.normalized * MoveSpeed;
			}
		} 
		
		gameObject.GetComponent<Rigidbody>().velocity = velocity;
		transform.LookAt (target);*/
	}
	void  Investigating ()
	{
        detectClosestEnemy();
		transform.LookAt(planet);
		gameObject.GetComponent<Renderer> ().material.color = new Color (255,255,0,0);
		transform.position += transform.forward*InvestigateSpeed*Time.deltaTime;
	}
	
	public void TargetDistance()
	{
		if (Vector3.Distance (transform.position, planet.transform.position) <= MaxDist && (Vector3.Distance(transform.position, planet.transform.position) >= InvestigateDist) )
		{
			state = State.InvestState;
		} 
		else 
			if (Vector3.Distance (transform.position, planet.transform.position) <= InvestigateDist) 
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

    public void detectClosestEnemy()
    {

        planets = GameObject.FindGameObjectsWithTag("Planet");
        float newDist;
        foreach (GameObject element in planets)
        {
            float dist = Vector3.Distance(element.transform.position, transform.position);
            newDist = dist;
            if (closestDist >= 0)
            {
                if (newDist < closestDist)
                {
                    closestDist = dist;
                    planet = element.transform;
                }
            }
            else
            {
                closestDist = dist;
                planet = element.transform;
            }

        }

    }

}
