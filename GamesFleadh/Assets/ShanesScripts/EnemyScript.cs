using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public GameObject[] waypoint;
	public int health = 10;
	public float ammo = 200;
	public int maxammo = 200;
	private float MoveSpeed= 10;
	public GameObject lasershot;
	public Transform shotspawn;
	public Transform Planet;

	public enum State {PatrolState, ShootingState, RetreatState};
	public State state;

	void  Start ()
	{
		state = State.PatrolState;
	}

	void Patrol ()
	{

	}

	void Shooting ()
	{
		if (ammo >= 1) {
			Instantiate (lasershot, shotspawn.position, shotspawn.rotation);
			ammo -= 1;
		}
	}

	void Retreat () 
	{

	}

	void Update ()
	{
		switch (state) 
		{
			case(State.ShootingState):
			{
				Shooting ();
				break;
			}
			case(State.RetreatState):
			{
				Retreat ();
				break;
			}
		}
	}
}
