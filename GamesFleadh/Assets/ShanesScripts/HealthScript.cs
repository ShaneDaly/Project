using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
<<<<<<< HEAD

    public float startHealth;
	[SerializeField]
    private float max;
    [SerializeField]
    private float health;
=======
	
	public float max = 500;
	public float health = 500;
>>>>>>> 18bed36e4a9358f2600e52f9da725d49c95c7465
	public float Length;
	public float timer = 10;
	public GameObject other;
	public GameObject healthBar;
	public GameObject scrap;
    [SerializeField]
    private float defence;
    PlanetStats planetStats;

<<<<<<< HEAD
    void Start()
    {
        planetStats = gameObject.GetComponent<PlanetStats>();
        defence = (planetStats.defence / 10.0f) + 1;
=======
	private static int h;

	void Start ()
	{
		//h = GetComponent<Health>();
	}
>>>>>>> 18bed36e4a9358f2600e52f9da725d49c95c7465

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
        max = startHealth;
        health = startHealth;
        defence = (planetStats.defence / 10.0f) + 1;
        max = defence * startHealth;
        health = defence * startHealth;
		if (health <= 0) {
			gameObject.SetActive(false);
			//GetComponent<Health>().num += 1;
>>>>>>> 713328e4d1d173ed98a72932a3578dc440112160
			Instantiate(scrap, transform.position, transform.rotation);
		}
	}
}
