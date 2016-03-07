using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {

	public float speed;
	public float timer = 2;
    public GameObject target;

	void Start () {
	}

	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.activeSelf == true && other.gameObject.tag == "Planet")
        {
            Destroy(gameObject);
        }
	}

	void Update () {
        transform.LookAt(target.transform);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Destroy(gameObject);
		}
	}
}
