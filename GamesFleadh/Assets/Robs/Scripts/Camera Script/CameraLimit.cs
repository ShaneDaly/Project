using UnityEngine;
using System.Collections;

public class CameraLimit : MonoBehaviour
{
    GameObject cam;
    float maxX = 100;

	// Use this for initialization
	void Start ()
    {
        cam = GameObject.Find("MainCamera");
        Vector3 newPosition;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(cam.transform.position.x > maxX)
        {
            
            Debug.Log("x exceeds camera bounds");
        }
	
	}
}
