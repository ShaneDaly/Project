using UnityEngine;
using System.Collections;


public class SatelliteHealth : MonoBehaviour 
{

    public float startHealth;
	[SerializeField]
    private float max;
    [SerializeField]
    private float health;
	public float Length;
	public float timer = 10;
	public GameObject other;
	public GameObject healthBar;
	public GameObject scrap;
    [SerializeField]
    private float defence;
    SatelliteStats satelliteStats;

	Health Health;

    void Start()
    {
        satelliteStats = gameObject.GetComponent<SatelliteStats>();
        defence = (satelliteStats.defence / 10.0f) + 1;
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
	
	


	void Update () 
    {
        max = startHealth;
        health = startHealth;
        defence = (satelliteStats.defence / 10.0f) + 1;
        max = defence * startHealth;
        health = defence * startHealth;
		if (health <= 0) 
        {
			gameObject.SetActive(false);
			GetComponent<Health>().num += 1;
			Instantiate(scrap, transform.position, transform.rotation);
		}
	}

}
