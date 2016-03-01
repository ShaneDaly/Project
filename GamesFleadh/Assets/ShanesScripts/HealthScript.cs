using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class HealthScript : MonoBehaviour {
	
	public float max = 500;
	public float health = 500;
	public int num;
=======
public class HealthScript : MonoBehaviour 
{

    public float startHealth;
	[SerializeField]
    private float max;
    [SerializeField]
    private float health;
>>>>>>> c7a750b27c3eb47548b7e219d493c83a347893c1
	public float Length;
	public float timer = 10;
	public GameObject other;
	public GameObject healthBar;
	public GameObject scrap;
    [SerializeField]
    private float defence;
    PlanetStats planetStats;

<<<<<<< HEAD
	Health Health;

	void Start ()
	{
		Health = gameObject.GetComponent<Health>();
	}

=======
    void Start()
    {
        planetStats = gameObject.GetComponent<PlanetStats>();
        defence = (planetStats.defence / 10.0f) + 1;
    }
>>>>>>> c7a750b27c3eb47548b7e219d493c83a347893c1
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
	
<<<<<<< HEAD
	
	void Update () 
    {
		if (health <= 0) {
			gameObject.GetComponent<Health>().num += 1;
			gameObject.SetActive(false);
=======


	void Update () 
    {
        max = startHealth;
        health = startHealth;
        defence = (planetStats.defence / 10.0f) + 1;
        max = defence * startHealth;
        health = defence * startHealth;
		if (health <= 0) 
        {
			gameObject.SetActive(false);
			//GetComponent<Health>().num += 1;
>>>>>>> c7a750b27c3eb47548b7e219d493c83a347893c1
			Instantiate(scrap, transform.position, transform.rotation);
		}
	}

}
