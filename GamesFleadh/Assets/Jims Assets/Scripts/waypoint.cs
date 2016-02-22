using UnityEngine;
using System.Collections;

public class waypoint : MonoBehaviour 
{
    public GameObject connectedPoint;
    public int arrivalDistance = 10;
    private int arraySize;


    void Start()
    {
        float dist = transform.position.z - Camera.main.transform.position.z;
        Vector3 pos = Input.mousePosition;
        pos.z = dist;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.y = 37.54f;
        Debug.Log(pos);
        transform.position = pos;
    }

    public GameObject calcPos(Vector3 position)
    {
        if (Vector3.Distance(transform.position, position) < arrivalDistance)
        {
            if (arraySize >= 1)
            {
                return connectedPoint;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return gameObject;
        }
    }

    public void setNext(GameObject nextWaypointPtr)
    {
        connectedPoint = nextWaypointPtr;
    }

    void OnDrawGizmos()
    {
        if (connectedPoint != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, connectedPoint.transform.position);
        }
    }
}
