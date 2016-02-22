using UnityEngine;
using System.Collections;

public class pointer : MonoBehaviour 
{
    private RaycastHit hitInfo;
    public GameObject mCamera;

	void Update () 
    {
        Plane plane = new Plane(Vector3.up, 0);

        float dist;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out dist))
        {
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            Vector3 point = ray.GetPoint(dist);
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

        if (Input.GetMouseButtonDown(0))
        {
            if (plane.Raycast(ray, out dist))
            { 
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                Vector3 point = ray.GetPoint(dist);
                if (!hit)
                {
                    mCamera.transform.position = new Vector3(point.x, 268, point.z);
                }
                if (hit)
                {
                }
            }
        }
	}
}
