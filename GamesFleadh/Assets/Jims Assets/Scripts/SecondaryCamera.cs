using UnityEngine;
using System.Collections;

public class SecondaryCamera : MonoBehaviour
{
    [SerializeField] private bool active;

    private bool inPosition;
    private bool inRotation;

    public float minHeight;
    public float maxHeight;
    public float movementSpeed;
    public float goToHeight;
    public float speed;

    Vector3 targetLoc;

    void Start ()
    {
        active = false;
	}
	
	void Update ()
    {
        if (active)
        {

            if (!inPosition || !inRotation)
            {
                if (transform.position == targetLoc)
                {
                    inPosition = false;
                }

                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetLoc, step);
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
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && transform.position.y > maxHeight)
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.W) && transform.position.y > minHeight)
        {
            transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.forward * Time.deltaTime * movementSpeed;
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

            targetLoc = new Vector3(transform.position.x, goToHeight, transform.position.z);
        }
        if (!active)
        {
            active = false;
        }
    }
}
