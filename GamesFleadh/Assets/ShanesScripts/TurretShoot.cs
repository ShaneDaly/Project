using UnityEngine;
using System.Collections;

public class TurretShoot : MonoBehaviour {

	public GameObject shot;

	public GameObject enemy;
	RaycastHit hit;
	private Vector3 fwd;
	public int ammo = 100;
	float timer=0f;

	void Update () 
	{
		if (timer > 0) 
		{
			timer-=Time.deltaTime;
		}
		Vector3 fk = new Vector3 (0, 0, 0);
		fwd = transform.TransformDirection (Vector3.up);
		enemy=GameObject.FindGameObjectWithTag("Enemy");
			float dist = Vector3.Distance (enemy.transform.position, transform.position);
			if (dist < 100) 
			{
				if (Physics.Raycast (transform.position, fwd,out hit, 5000.0f)&&hit.collider.tag=="Enemy"&timer<0.5f)
				{
					if (ammo >= 1)
					{
						//gameObject.GetComponent<Renderer> ().material.color = new Color (255, 0, 0, 0);
						timer=2f;
						ammo -=1;
						GameObject rocket = (GameObject)Instantiate(shot,hit.point-fk, Quaternion.LookRotation(hit.normal));
						Destroy(rocket.gameObject, 2);
					}
					
				}
		}

	}
}
