using UnityEngine;
using System.Collections;

public class pointer : MonoBehaviour 
{
    private RaycastHit hitInfo;
    public GameObject mCamera;
    public GameObject sun;
    public Vector3 border;
    private float distance;

    public bool isTracking;
    public GameObject objectTracking;

    public Vector3 objectTrackingPrev;
    public Vector3 difference;

    public bool prevSet;
    public bool mainActive;

    void start()
    {
        isTracking = false;
        prevSet = false;
    }
    void Update () 
    {
        Plane plane = new Plane(Vector3.up, 0);
        float dist;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out dist))
        {
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            Vector3 point = ray.GetPoint(dist);

            if ((Vector3.Distance(sun.transform.position, point)) < (Vector3.Distance(border, sun.transform.position)))
            {
                if (!hit)
                {
                    transform.position = new Vector3(point.x, -50, point.z);
                }
                if (hit)
                {
                    if (hitInfo.transform.gameObject.tag == "Planet")
                    {

                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(2))
        {
            if (plane.Raycast(ray, out dist))
            { 
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                Vector3 point = ray.GetPoint(dist);
                if ((Vector3.Distance(sun.transform.position, point)) < (Vector3.Distance(border, sun.transform.position)))
                {
                    if (!hit)
                    {
                        Camera.main.GetComponent<cameraControl>().goTo(point);
                        Camera.main.transform.parent = null;
                        isTracking = false;
                    }
                    if (hit)
                    {
                        prevSet = false;
                        isTracking = true;
                        objectTracking = hitInfo.transform.gameObject;
                    }
                }
            }
        }

        if (isTracking)
        {
            if (!prevSet)
            {
                objectTrackingPrev = objectTracking.transform.position;
                prevSet = true;
            }
            difference = objectTracking.transform.position - objectTrackingPrev;
            objectTrackingPrev = objectTracking.transform.position;
            mCamera.transform.position = (mCamera.transform.position + difference);
        }
    }
    private void OnDrawGizmos()
    {
        distance = Vector3.Distance(border, sun.transform.position);
        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(sun.transform.position, Vector3.up, distance);
    }
}
