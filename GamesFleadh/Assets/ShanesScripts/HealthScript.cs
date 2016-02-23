using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	public int max = 10000;
	public int health = 10000;
	public float Length;
	public float timer = 2;
	public GameObject other;
	public GameObject scrap;

	void OnTriggerEnter(Collider other)
	{
		health -= 1;
	}

	public void UpdateHealth(int adj) {
		health += adj;	
		
		if(health < 0)
			health = 0;
		
		if(health > max)
			health = max;

		if(max < 1)
			max = 1;
		Length = (Screen.width / 2) * (health / (float)max);
	}
	
	void Update () {
		
		UpdateHealth(0);
		
		if (health <= 300) {
			timer -= Time.deltaTime;
			
			if (timer <= 0) {
				timer = 2;
				health -= 20;

			}
		} 
		if (health <= 0) {
			if (timer <= 0){
				timer = 2;
			}
			Destroy (gameObject);
			Instantiate(scrap, transform.position, transform.rotation);
		}
	}
}
