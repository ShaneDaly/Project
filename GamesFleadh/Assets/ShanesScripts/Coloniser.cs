using UnityEngine;
using System.Collections;

public class Coloniser : MonoBehaviour {

	public enum State {PatrolState,AttackState}
	public State state;
	public Transform Planet;
	public float MoveSpeed= 30;
	public GameObject[] planets = null;
	private CharacterController character;

	void Start () {
		//Planet = GameObject.FindWithTag("Planet").transform;
		state = State.AttackState;	
	}

	void Awake ()
	{
		Planet = GameObject.FindWithTag("Planet").transform;
	}

	void Update (){


		switch (state) 
		{
			case(State.PatrolState):
			{
				Patroling ();
				break;
			}
			case(State.AttackState):
			{
				Attacking ();
				break;
			}
		}
	}

	void OnTriggerEnter(Collider Planet)
	{
		Destroy (gameObject);
		//Planet.GetComponent<PlanetStats> ().colonised = true;
	}

	void Patroling () 
	{

	}

	void  Attacking ()
	{
		gameObject.GetComponent<Renderer> ().material.color = new Color (255,0,0,0);
		transform.LookAt(Planet);
		transform.position += transform.forward*MoveSpeed*Time.deltaTime;
	}
}
