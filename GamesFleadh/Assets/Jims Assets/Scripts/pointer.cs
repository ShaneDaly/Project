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

    public bool emitterSecondaryActive;
    public bool planetHit;

    public GameObject emitter;
    public GameObject emitterSeconday;


    public bool orbiterSelected;

    void start()
    {
        isTracking = false;
        prevSet = false;
        gameObject.tag = "pointer";
    }
    void Update () 
    {
        if (planetHit)
        {
            emitter.GetComponent<ParticleSystem>().enableEmission = false;
            emitterSeconday.GetComponent<ParticleSystem>().enableEmission = false;
        }
        else
        {
            if (emitterSecondaryActive)
            {
                emitter.GetComponent<ParticleSystem>().enableEmission = false;
                emitterSeconday.GetComponent<ParticleSystem>().enableEmission = true;
            }
            else
            {
                emitter.GetComponent<ParticleSystem>().enableEmission = true;
                emitterSeconday.GetComponent<ParticleSystem>().enableEmission = false;
            }
        }


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

                    planetHit = false;
                }
                if (hit)
                {
                    if (hitInfo.transform.gameObject.tag == "Planet" || hitInfo.transform.gameObject.tag == "Satellite" || hitInfo.transform.gameObject.tag == "Sun")
                    {
                        planetHit = true;
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
                        Camera.main.GetComponent<cameraControl>().goTo(point);
                        Camera.main.transform.parent = null;
                        isTracking = false;
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (plane.Raycast(ray, out dist))
            {
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                Vector3 point = ray.GetPoint(dist);
                if ((Vector3.Distance(sun.transform.position, point)) < (Vector3.Distance(border, sun.transform.position)))
                {
                    if (!hit)
                    {
                        orbiterSelected = false;
                    }
                    if (hit)
                    {
                        try
                        {
                            foreach (GameObject planets in GameObject.FindGameObjectsWithTag("planet"))
                            {
                                planets.GetComponent<Planet>().unSelect();
                            }
                        }
                        catch (System.Exception e)
                        {
                        }

                        try
                        {
                            foreach (GameObject sats in GameObject.FindGameObjectsWithTag("satellite"))
                            {
                                sats.GetComponent<Planet>().unSelect();
                            }
                        }
                        catch (System.Exception e)
                        {
                        }

                        orbiterSelected = true;
                        prevSet = false;
                        isTracking = true;
                        objectTracking = hitInfo.transform.gameObject;
                        if (hitInfo.transform.gameObject.tag == "planet")
                        {
                            hitInfo.transform.GetComponent<Planet>().setSelected();
                        }
                        if (hitInfo.transform.gameObject.tag == "satellite")
                        {
                            hitInfo.transform.GetComponent<Satelite>().setSelected();
                        }
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

    public void toggleEmitter()
    {
        if (emitterSecondaryActive)
        {
            emitterSecondaryActive = false;
        }
        else
        {
            emitterSecondaryActive = true;
        }
    }

    public bool getOrbiterSelected()
    {
        return orbiterSelected;
    }
}
