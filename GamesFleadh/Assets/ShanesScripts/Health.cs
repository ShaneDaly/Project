using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health = 1000;
	public GameObject[] planets;
	public GameObject laser;
	public float time = 5;
	public string newScene;
	public int size;
	public int num;
	
	void Awake ()
	{
		planets = GameObject.FindGameObjectsWithTag ("Planet");
		size = planets.Length;
	}
	

	void OnTriggerEnter (Collider laser)
	{

	}

	void Update ()
	{
		if (num == size) {
			gameObject.tag = "Planet";
		}

		if (health <= 0) {
			time -= Time.deltaTime;
			if(time <=0){
				Application.LoadLevel(newScene);
				LevelManager.setLastLevel(Application.loadedLevelName);
			}
		}
	}
}
