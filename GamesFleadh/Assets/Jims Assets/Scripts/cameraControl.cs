using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;

    public Vector3 goToLocation;
    public Transform target;
    public float speed;

    public float movementSpeed;
    public float zoomOutY;
    public int mode;
    public float minHeight;
    public float maxHeight;
    public float zoomSpeed;
    public float GotoHeight;

    public float mouseX;
    public float mouseY;

    public bool isMoving;
    public bool active;

    public GameObject sun;
    public GameObject Pointer;

    void start()
    {
        mode = 0;
        active = true;

        sensitivityX = 8F;
        sensitivityY = 8F;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (active)
            {
                active = false;
                gameObject.GetComponent<SecondaryCamera>().toggleActive();
                Pointer.GetComponent<pointer>().toggleEmitter();
                isMoving = false;
            }
            else if (!active)
            {
                goTo(new Vector3(transform.position.x, GotoHeight, transform.position.z));
                gameObject.GetComponent<SecondaryCamera>().toggleActive();
                enableMain();
                isMoving = true;
            }
            return;
        }
        if (active)
        {
            moveCamera();
        }
    }
    
    void ChangeHeight(float aVal)
    {
        if (transform.position.y > minHeight && aVal < 0)
        {
            transform.position += aVal * Vector3.up;
        }
        else if (transform.position.y < maxHeight && aVal > 0)
        {
            transform.position += aVal * Vector3.up;
        }
    }

    public float newX;
    public float newY;

    void ChangeHeading(float aVal)
    {
        newY = Wrap360(aVal += transform.localEulerAngles.y);
        transform.localEulerAngles = new Vector3(newX, newY, 0);
    }

    void ChangePitch(float aVal)
    {
        newX = Wrap360(aVal += transform.localEulerAngles.x);
        transform.localEulerAngles = new Vector3(newX, newY, 0);
    }

    float Wrap360(float angle)
    {
        if (angle < -360F)
        {
            angle += 360F;
        }
        if (angle > 360F)
        {
            angle -= 360F;
        }
        return angle;
    }

    public void goTo(Vector3 newLocation)
    {
        goToLocation = newLocation;
        isMoving = true;
        float h;
        if (active)
        {
            h = transform.position.y;
        }
        else
        {
            enableMain();
            h = GotoHeight;
        }
        goToLocation.y = h;
    }

    void moveCamera()
    {
        if (!isMoving)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && transform.position.y > minHeight)
            {
                transform.position -= (transform.position - Pointer.transform.position).normalized * Time.deltaTime * zoomSpeed;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f && transform.position.y < maxHeight)
            {
                transform.position += (transform.position - Pointer.transform.position).normalized * Time.deltaTime * zoomSpeed;
            }

            if (Input.GetKey(KeyCode.W) && transform.position.y < maxHeight)
            {
                transform.position += transform.up * Time.deltaTime * movementSpeed;
            }
            else if (Input.GetKey(KeyCode.S) && transform.position.y > minHeight)
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

        if (isMoving)
        {
            if (transform.position == goToLocation)
            {
                isMoving = false;
            }
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, goToLocation, step);
        }

        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        if (!(Input.GetMouseButton(0) || Input.GetMouseButton(1)))
        {
            return;
        }

        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            ChangeHeight(mouseY);
        }
        else
        {
            if (Input.GetMouseButton(1))
            {
                ChangeHeading(mouseX);
                ChangePitch(-mouseY);
            }
        }
    }

    public void enableMain()
    {
        active = true;
        gameObject.GetComponent<SecondaryCamera>().toggleActive();
        Pointer.GetComponent<pointer>().toggleEmitter();
    }

    public bool checkActive()
    {
        return active;
    }
}
