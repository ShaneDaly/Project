using UnityEngine;
using System.Collections;

public class OrbitScript : MonoBehaviour 
{
	public float RotationSpeed = 100f;
	public float OrbitSpeed = 0f;
	public float DesiredMoonDistance;
	public GameObject target;

	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Sun");
		//DesiredMoonDistance = Vector3.Distance(target.transform.position, transform.position);
	}

	void Update ()
    {
		transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
		transform.RotateAround(target.transform.position, Vector3.up, OrbitSpeed * Time.deltaTime);
        /**
		//fix possible changes in distance
		float currentMoonDistance = Vector3.Distance(target.transform.position, transform.position);
		Vector3 towardsTarget = transform.position - target.transform.position;
		transform.position += (DesiredMoonDistance - currentMoonDistance) * towardsTarget.normalized;**/
	}
}