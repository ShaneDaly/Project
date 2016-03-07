/** Author: James Gallagher
 * 
 * 
**/


using UnityEngine;
using System.Collections;

public class Satelite : MonoBehaviour 
{
    public GameObject sun;

    public Vector3 sunVec;
    public float rotationSpeed;

    // 10km = 1 Scale
    public float size;
    public float sizeKm;
    
    private float g;
    private float m;
    private float gm;
    private float gmOverRadius;
    private float orbitV;
    
    private float circumference;
    private float rps;
    public float rotateSpeed;
    public float desiredRotateSpeed;
    
    private float height;

    public bool allowOrbitDebug;
    public bool selected;

    public Vector3 direction;
    public Vector3 prevPos;
    //public GameObject emitter;

    [SerializeField]
    private bool isAcc;

    public GameObject trailer;

    // Use this for initialization
    void Start()
    {
        isAcc = true;

        sun = GameObject.FindGameObjectWithTag("Sun");

        GameObject ptrailer = (GameObject)Instantiate(trailer, transform.position, new Quaternion(0, 0, 0, 0)); ;
    }

    // Update is called once per frame
    void Update()
    {
        if (sun)
        {
            calcOrbit();
        }

        if (!isAcc)
        {
            //emitter.GetComponent<ParticleSystem>().enableEmission = false;
        }
        transform.position.Set(transform.position.x, height, transform.position.z);
        getDirection();
    }


    // Sets the Sun to orbit
    public void setSun(GameObject nSun)
    {
        sun = nSun;
    }

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    //calculates the plamets orbit speed
    public void calcOrbit()
    {
        size = Vector3.Distance(transform.position, sun.transform.position);

        sunVec = sun.transform.position;

        sizeKm = size * 100000;
        g = (6.6f) * (Mathf.Pow(6, 0.18f));
        m = (1.9f) * (Mathf.Pow(6, 30));
        gm = g * m;
        gmOverRadius = gm / 150;

        orbitV = Mathf.Sqrt(gmOverRadius);
        orbitV = orbitV / 1000000;
        //Debug.Log(orbitV);

        circumference = sizeKm * 3.14f;
        rps = orbitV / circumference;
        desiredRotateSpeed = (rps * 60) * 60;

        if (isAcc)
        { 
            //create particals
        }

        if (rotateSpeed < desiredRotateSpeed)
        {
            isAcc = false;
            rotateSpeed += 0.003f;
        }

        transform.RotateAround(sunVec, Vector3.up, rotateSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        if (!selected)
        {
            UnityEditor.Handles.color = Color.white;
        }
        else
        {
            UnityEditor.Handles.color = Color.blue;
        }
        if (allowOrbitDebug)
        {
            float distance = Vector3.Distance(transform.position, sun.transform.position);
            UnityEditor.Handles.DrawWireDisc(sun.transform.position, Vector3.up, distance);
        }
    }

    public void setSelected()
    {
        selected = true;
    }
    public void unSelect()
    {
        selected = false;
    }

    public void getDirection()
    {
        direction = (transform.position - prevPos).normalized;
        prevPos = transform.position;
        transform.LookAt(direction);
    }
}
