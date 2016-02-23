using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {

    public float sensitivityX = 8F;
    public float sensitivityY = 8F;
    float mHdg = 0F;
    float mPitch = 90F;

    public Transform target;
    public float speed;

    public bool isMoving;
    public Vector3 goToLocation;

    public float movementSpeed;

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") >0f)
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") <0f)
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }

        if(Input.GetKey(KeyCode.W)) {
             transform.position += transform.forward * Time.deltaTime * movementSpeed;
         }
         else if(Input.GetKey(KeyCode.S)) {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
         }
         else if(Input.GetKey(KeyCode.A)) {
            transform.position -= transform.right * Time.deltaTime * movementSpeed;
         }
         else if(Input.GetKey(KeyCode.D)) {
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
        goToLocation.y = transform.position.y;
    }
}
