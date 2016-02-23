using UnityEngine;
using System.Collections;

public class SateliteCreator : MonoBehaviour {

    public Transform Satelite;
    public GameObject Sun;
    public float dist;
    private Vector3 sunVec;
    RaycastHit hitInfo;
    bool createSat;

    void Start()
    {
        createSat = false;
    }

    public void enableCreateSat()
    {
        createSat = true;
    }

    public void disableCreateSat()
    {
        createSat = false;
    }


    void Update()
    {
        if (createSat)
        {
            if (Input.GetMouseButtonDown(1))
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
                        Instantiate(Satelite, point, Quaternion.identity);
                    }
                    if (hit)
                    {
                        if (hitInfo.transform.gameObject.tag == "Planet")
                        {
                            Instantiate(pSatelite, point, Quaternion.identity);
                        }
                    }
                }
            }
        }
    }

}
