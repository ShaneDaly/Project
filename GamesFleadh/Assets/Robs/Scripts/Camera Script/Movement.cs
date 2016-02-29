using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	float speed = 1000;
	float maxX, minX, maxZ, minZ;
	Vector3 center;
	float camX, camZ;



	// Use this for initialization
	void Start () 
	{
		maxX = 3500;
		minX = -3500;
		maxZ = 900;
		minZ = -900;
		center = new Vector3(0, 390, 0);



	}
	
	// Update is called once per frame
	void Update()
	{
		camX = transform.position.x;
		camZ = transform.position.z;


		if (Input.GetKey (KeyCode.D) == true && transform.position.x < maxX) 
		{
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		}

		if (Input.GetKey (KeyCode.A) == true && transform.position.x > minX) 
		{
			transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));
		}

		if (Input.GetKey (KeyCode.S) == true && transform.position.z > minZ)
		{
			transform.Translate (new Vector3 (0, -speed * Time.deltaTime, 0));
		}

		if (Input.GetKey (KeyCode.W) == true && transform.position.z < maxZ) 
		{
			transform.Translate (new Vector3 (0, speed * Time.deltaTime, 0));
		}

		//centering the camera
		if (Input.GetKey (KeyCode.C) == true && transform.position != center) 
		{
			if (transform.position.x > 0 && transform.position.z > 0) 
			{
				Debug.Log ("Center the camera from upper right quadrant ");
				transform.Translate (-camX, -camZ, 0);
			}

			if (transform.position.x > 0 && transform.position.z < 0) 
			{
				Debug.Log ("Center the camera from lower right quadrant ");
				transform.Translate (-camX, -camZ, 0);
			}

			if (transform.position.x < 0 && transform.position.z > 0) 
			{
				Debug.Log ("Center the camera from upper left quadrant ");
				transform.Translate (-camX, -camZ, 0);
			}

			if (transform.position.x < 0 && transform.position.z < 0) 
			{
				Debug.Log ("Center the camera from lower left quadrant ");
				transform.Translate (-camX, -camZ, 0);
			}
		}



	}
}
