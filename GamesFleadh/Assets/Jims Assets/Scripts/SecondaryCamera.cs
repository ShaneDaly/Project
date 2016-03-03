using UnityEngine;
using System.Collections;

public class SecondaryCamera : MonoBehaviour
{
    [SerializeField]
    private bool active;

    [SerializeField]
    private bool inPosition;
    [SerializeField]
    private bool inRotation;

    public float minHeight;
    public float maxHeight;
    public float movementSpeed;
    public float goToHeight;
    public float speed;
    public float rotationSpeed;
    public float zoomSpeed;

    public Vector3 targetLoc;

    void Start ()
    {
        active = false;

	}
	
	void Update ()
    {
        targetLoc = new Vector3(transform.position.x, goToHeight, transform.position.z);
        if (active)
        {

            if (!inPosition || !inRotation)
            {
                if (transform.position == targetLoc)
                {
                    inPosition = true;
                }

                if (!inPosition)
                {
                    float step = speed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, targetLoc, step);
                }

                if (!inRotation)
                {
                    Vector3 targetDir = new Vector3(0,-90,0) ;
                    float step = rotationSpeed * Time.deltaTime;
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
                    Debug.DrawRay(transform.position, newDir, Color.red);
                    transform.rotation = Quaternion.LookRotation(newDir);
                    Debug.Log(transform.eulerAngles.x);
                    if (transform.eulerAngles.x == 90)
                    {
                        inRotation = true;
                    }
                }

            }
            else
            {
                moveControls();
            }
        }
	}

    void moveControls()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && transform.position.y > minHeight)
        {
            transform.position += transform.forward * Time.deltaTime * zoomSpeed;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && transform.position.y < maxHeight)
        {
            transform.position -= transform.forward * Time.deltaTime * zoomSpeed;
        }

        if (Input.GetKey(KeyCode.W) && transform.position.y > minHeight)
        {
            transform.position += transform.up * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.up * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * movementSpeed;
        }
    }

    public void toggleActive()
    {
        if (active)
        {
            active = false;
            inPosition = false;
            inRotation = false;
        }
        else if (!active)
        {
            active = true;
        }
    }
}
