using UnityEngine;
using System.Collections;

public class HealthScript2 : MonoBehaviour {

	public int health = 100;
	public int max = 100;
	public float timer = 10;
	public float Length;


	void Update () {
		//Length = (Screen.width / 2) * (health / (float)max);

		if (health < 100) {
			timer -= Time.deltaTime;
			if (timer <= 0){
				health += 1;
				if(health == max)
				{
					timer = 10;
				}
			}
		}
	}
}
