using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	public int max = 100;
	public int health = 100;
	public float Length;
	public float timer = 2;
	
	void Start () {
	
	}
	
	void OnGUI () {
		GUI.backgroundColor = Color.yellow;
		GUI.Box(new Rect(15, 15, Length, 30), health + "%");
	}
	
	public void UpdateHealth(int adj) {
		health += adj;	
		
		if(health < 0)
			health = 0;
		
		if(health > max)
			health = max;
		
		if (health <= 0)
			Application.LoadLevel(Application.loadedLevel);
		
		if(max < 1)
			max = 1;
		Length = (Screen.width / 2) * (health / (float)max);
	}
	
	void Update () {
		
		UpdateHealth(0);
		
		if (health <= 30) {
			timer -= Time.deltaTime;
			
			if (timer <= 0)
			{
				timer = 2;
				health -= 1;

			}
		}
	}
}
