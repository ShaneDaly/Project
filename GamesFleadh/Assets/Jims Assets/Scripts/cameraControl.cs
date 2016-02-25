using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour
{
    public float sensitivityX = 8F;
    public float sensitivityY = 8F;
    public float mHdg = 0F;
    public float mPitch = 90F;

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

    public bool isMoving;
    public bool active;

    public GameObject sun;
    public GameObject Pointer;

    void start()
    {
        mode = 0;
        active = true;
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

    void MoveForwards(float aVal)
    {
        Vector3 fwd = transform.forward;
        fwd.y = 0;
        fwd.Normalize();
        transform.position += aVal * fwd;
    }

    void Strafe(float aVal)
    {
        transform.position += aVal * transform.right;
    }
    void ChangeHeight(float aVal)
    {
        transform.position += aVal * Vector3.up;
    }
    void ChangeHeading(float aVal)
    {
        mHdg += aVal;
        WrapAngle(ref mHdg);
        transform.localEulerAngles = new Vector3(mPitch, mHdg, 0);
    }
    void ChangePitch(float aVal)
    {
        mPitch += aVal;
        WrapAngle(ref mPitch);
        transform.localEulerAngles = new Vector3(mPitch, mHdg, 0);
    }
    public static void WrapAngle(ref float angle)
    {
        if (angle < -360F)
        {
            angle += 360F;
        }
        if (angle > 360F)
        {
            angle -= 360F;
        }
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

        float deltaX = Input.GetAxis("Mouse X") * sensitivityX;
        float deltaY = Input.GetAxis("Mouse Y") * sensitivityY;

        if (!(Input.GetMouseButton(0) || Input.GetMouseButton(1)))
        {
            return;
        }

        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            Strafe(deltaX);
            ChangeHeight(deltaY);
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                MoveForwards(deltaY);
                ChangeHeading(deltaX);
            }
            else if (Input.GetMouseButton(1))
            {
                ChangeHeading(deltaX);
                ChangePitch(-deltaY);
            }
        }
    }

    public void enableMain()
    {
        active = true;
        mPitch = 90F;
        mHdg = transform.eulerAngles.y;
        gameObject.GetComponent<SecondaryCamera>().toggleActive();
        Pointer.GetComponent<pointer>().toggleEmitter();
    }

    public bool checkActive()
    {
        return active;
    }
}
