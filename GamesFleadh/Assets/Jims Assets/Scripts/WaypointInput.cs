using UnityEngine;
using System.Collections;

public class WaypointInput : MonoBehaviour 
{
    public GameObject waypoint;
    public GameObject nWaypoint;
    public GameObject prevPtr;
    private bool nullWaypoints;

    void Start()
    {
        nullWaypoints = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nWaypoint = new GameObject();
            nWaypoint.AddComponent<waypoint>();
            if (prevPtr != null)
            {
                prevPtr.GetComponent<waypoint>().setNext(nWaypoint);
            }
            prevPtr = nWaypoint;
            if (nullWaypoints == true)
            {
                waypoint = nWaypoint;
                nullWaypoints = false;
            }
        }
        
    }

    public Vector3 getWaypoint(Vector3 CurrentPos)
    {
        waypoint = waypoint.GetComponent<waypoint>().calcPos(CurrentPos);
        if (waypoint != null)
        {
            return waypoint.transform.position;
        }
        else 
        {
            return new Vector3(0,0,0);
        }
    }
}
