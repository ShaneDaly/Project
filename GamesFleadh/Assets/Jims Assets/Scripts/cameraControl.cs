/** Author: James Gallagher
 * 
 * 
**/


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

    public float newX;
    public float newY;

    float posy;

    public GameObject sun;
    public GameObject Pointer;

    public GameObject[] trailers;

    void start()
    {
        
        mode = 0;
        active = true;

        sensitivityX = 8F;
        sensitivityY = 8F;
    }

    void Update()
    {

        if (active)
        {
            isMoving = false;
            moveCamera();
            posy = 90;
            Vector3 thing = new Vector3(transform.position.x, posy, transform.position.z);
            transform.position = (thing);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (active)
            {

                active = false;
                gameObject.GetComponent<SecondaryCamera>().toggleActive();
                Pointer.GetComponent<pointer>().enableMainSecondary();
                isMoving = false;

                trailers = GameObject.FindGameObjectsWithTag("Trailer");
                if (trailers != null)
                {
                    foreach (GameObject trailer in trailers)
                    {
                        trailer.GetComponent<trailCreator>().enableTrail();
                    }
                }
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
    }
    

    void ChangeX(float nNum)
    {
        newY = Wrap360(nNum += transform.localEulerAngles.y);
        transform.localEulerAngles = new Vector3(newX, newY, 0);
    }

    void ChangeY(float nNum)
    {
        newX = Wrap360(nNum += transform.localEulerAngles.x);
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
        newX = transform.eulerAngles.x;
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
            

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * movementSpeed;
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
        
        else
        {
            if (Input.GetMouseButton(1))
            {
                ChangeX(mouseX);
                ChangeY(-mouseY);
            }
        }
    }

    public void enableMain()
    {
        active = true;
        gameObject.GetComponent<SecondaryCamera>().toggleActive();
        Pointer.GetComponent<pointer>().enableMainEmitter();


        trailers = GameObject.FindGameObjectsWithTag("Trailer");
        if (trailers != null)
        {
            foreach (GameObject trailer in trailers)
            {
                trailer.GetComponent<trailCreator>().disableTrail();
            }
        }
    }

    public bool checkActive()
    {
        return active;
    }
}
