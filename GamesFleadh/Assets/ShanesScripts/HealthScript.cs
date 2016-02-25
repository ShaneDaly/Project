using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	public float max = 10000;
	public float health = 10000;
	public float Length;
	public float timer = 10;
	public GameObject other;
	public GameObject healthBar;
	public GameObject scrap;


	void OnTriggerEnter(Collider other)
	{
		decreaseHealth ();
		float calc_Health = health / max;
		SetHealthBar (calc_Health);
	}

	void decreaseHealth ()
	{
		health -= 1;
	}

	public void SetHealthBar (float myHealth)
	{
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}


	void Update () {
		
		//UpdateHealth(0);
		
		if (health < max) {
			timer -= Time.deltaTime;
			
			if (timer <= 0) {
				health += 1;
				if(health == max)
				{
					timer = 30;
				}

			}
		} 
		if (health <= 0) {
			Destroy (gameObject);
			//GetComponent<SunShield>().ReduceNum();
			Instantiate(scrap, transform.position, transform.rotation);
		}
	}
}
