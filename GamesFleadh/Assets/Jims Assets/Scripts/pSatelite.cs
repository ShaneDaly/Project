using UnityEngine;
using System.Collections;

public class pSatelite : MonoBehaviour
{
    public GameObject sun;
    public float rotationSpeed;

    private Vector3 sunVec;

    // 10km = 1 Scale
    public float size;
    public float sizeKm;

    private float g;
    private float m;
    private float gm;
    private float gmOverRadius;
    private float orbitV;

    public float circumference;
    public float rps;
    public float rotateSpeed;
    public float desiredRotateSpeed;

    public GameObject emitter;

    public bool isAcc;

    // Use this for initialization
    void Start()
    {
        isAcc = true;
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
            emitter.GetComponent<ParticleSystem>().enableEmission = false;
        }
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
            rotateSpeed += 0.001f;
        }

        transform.RotateAround(sunVec, Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
