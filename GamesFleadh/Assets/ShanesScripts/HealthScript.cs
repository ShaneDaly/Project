using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	public float max = 500;
	public float health = 500;
	public float Length;
	public float timer = 10;
	public GameObject other;
	public GameObject healthBar;
	public GameObject scrap;

	private static int h;

	void Start ()
	{
		//h = GetComponent<Health>();
	}

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

<<<<<<< HEAD
		if (health <= 0) 
		{
			gameObject.SetActive(false);
			//Destroy (gameObject);
			//GetComponent<chase>().detectClosestEnemy();
=======
	void Update () 
    {
		if (health <= 0) {
			gameObject.SetActive(false);
			//GetComponent<Health>().num += 1;
>>>>>>> 713328e4d1d173ed98a72932a3578dc440112160
			Instantiate(scrap, transform.position, transform.rotation);
		}
	}
}
