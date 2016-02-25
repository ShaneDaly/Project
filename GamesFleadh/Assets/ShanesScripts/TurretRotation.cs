using UnityEngine;
using System.Collections;



public class TurretRotation : MonoBehaviour 
{
	public int xO=0;
	public int yO=0;
	public int zO=0;
	public Transform target;
	float range = 50.0f;
	public float stopDistance = 0.11f;
	public float dist;
	public float astDist;
	
	GameObject[] Target;
	
	void Awake()
	{
		Target = GameObject.FindGameObjectsWithTag("Enemy") ;    
	}
	
	
	void Update () 
	{

		foreach (GameObject GO in Target) 
		{
			target = GameObject.FindGameObjectWithTag("Enemy").transform;
			dist = Vector3.Distance(GO.transform.position, transform.position);
			Vector3 relativePos =  (target.position-transform.position);
			
			Debug.DrawLine(GO.transform.position, transform.position);

			transform.rotation =   Quaternion.LookRotation (relativePos,Vector3.forward);
			
		}
		
		
	}
	
	
}