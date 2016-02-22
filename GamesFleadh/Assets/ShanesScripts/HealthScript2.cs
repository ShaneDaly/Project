using UnityEngine;
using System.Collections;

public class HealthScript2 : MonoBehaviour {

	public int health = 100;
	public int max = 100;
	public float timer = 30;
	public float Length;

	void Start () {
	
	}

	void OnGUI () {
		GUI.backgroundColor = Color.yellow;
		GUI.Box(new Rect(15, 15, Length, 30), health + "%");
	}

	void Update () {
		Length = (Screen.width / 2) * (health / (float)max);

		if (health < 100) {
			timer -= Time.deltaTime;
			if (timer <= 0){
				health += 1;
				if(health == max)
				{
					timer = 30;
				}
			}
		}
	}
}
