using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health = 1000;
	public GameObject[] planets;
	public GameObject laser;
	public float time = 5;
	public string newScene;
	public int size;
	public int num = 0;
	Health h;
	
	void Awake ()
	{
		planets = GameObject.FindGameObjectsWithTag ("Planet");
		h = gameObject.GetComponent<Health> ();
		size = planets.Length;
	}
	

	void OnTriggerEnter (Collider laser)
	{
		health -= 1;
	}

	void Update ()
	{


		if (health <= 0) {
			time -= Time.deltaTime;
			if(time <=0){
				Application.LoadLevel(newScene);
				LevelManager.setLastLevel(Application.loadedLevelName);
			}
		}
	}
}