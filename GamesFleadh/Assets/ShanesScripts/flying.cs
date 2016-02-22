using UnityEngine;
using System.Collections;

public class flying : MonoBehaviour {

	public int ammo = 500;
	public int maxammo = 500;
	
	public GameObject lasershot;
	public Transform shotspawn;
	
	public float fireRate;
	private float nextFire;
	public float Length;

	public float rotateSpeed = 100;
	public float speed = 100;
	public float thrust = 500;
	public float max = 500;
	public float timer = 15;

	void OnGUI () {
		GUI.backgroundColor = Color.blue;
		GUI.Box(new Rect(15, 45, Length, 30), thrust + "");
	}

	void Update () {
		Length = (Screen.width / 2) * (thrust / (float)max);
		float transAmount = speed * Time.deltaTime;
		float rotateAmount = rotateSpeed * Time.deltaTime;

		if (Input.GetKey("space") && ammo >= 1 && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			ammo -= 1;
			Instantiate (lasershot, shotspawn.position, shotspawn.rotation);
		}

		if (Input.GetKey("a")) {
			transform.Rotate(0, -rotateAmount, 0);
		}
		if (Input.GetKey("d")) {
			transform.Rotate(0, rotateAmount, 0);
		}
		
		if (Input.GetKey ("w")) {
			transform.Translate(0, 0, transAmount);
		}
		
		if (Input.GetKey ("q") && thrust >= 1) {
			transform.Translate(0, 0, (transAmount * 2));
			thrust -= 1;	
		}

		if(thrust < 500)
		{
			timer -= Time.deltaTime;
			if (timer <= 0){
				thrust += 1;
				if(thrust == 500)
				{
					timer = 15;
				}
			}
		
		}
	}
}