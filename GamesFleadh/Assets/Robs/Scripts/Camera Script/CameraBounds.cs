using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour
{
    private Vector3 velocity;

    public float speed = 1000;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject cam;

    public bool bounds;

    public Vector3 minCameraPosX;
    public Vector3 maxCameraPosX;
    public Vector3 minCameraPosY;
    public Vector3 maxCameraPosY;
	
	void Start ()
    {
        cam = GameObject.Find("MainCamera");
	}
	
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }

        float posX = Mathf.SmoothDamp(transform.position.x, cam.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, cam.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.y);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPosX.x, maxCameraPosX.x),
                Mathf.Clamp(transform.position.y, minCameraPosY.y, maxCameraPosY.y));
        }

    }
}
