using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health = 1000;
	public GameObject[] planets;
	public GameObject laser;
	public float timer = 5;
	public string newScene;
	public int size;
	public static int num;
	
	void Awake ()
	{
		planets = GameObject.FindGameObjectsWithTag ("Planet");
		size = planets.Length;
	}
	

	void OnTriggerEnter (Collider laser)
	{
		if (num == size){
			gameObject.tag = "Planet";
			health -= 1;
		}
	}

	void Update ()
	{
		if (health <= 0) {
			timer -= Time.deltaTime;
			if(timer <=0){
				Application.LoadLevel(newScene);
				LevelManager.setLastLevel(Application.loadedLevelName);
			}
		}
	}
}
