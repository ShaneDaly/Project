using UnityEngine;
using System.Collections;

public class Satelite : MonoBehaviour 
{
    [SerializeField] private GameObject sun;

    [SerializeField] private Vector3 sunVec;
    public float rotationSpeed;

    // 10km = 1 Scale
    [SerializeField]
    private float size;
    [SerializeField]
    private float sizeKm;

    [SerializeField]
    private float g;
    [SerializeField]
    private float m;
    [SerializeField]
    private float gm;
    [SerializeField]
    private float gmOverRadius;
    [SerializeField]
    private float orbitV;

    [SerializeField]
    private float circumference;
    [SerializeField]
    private float rps;
    public float rotateSpeed;
    [SerializeField]
    private float desiredRotateSpeed;

    [SerializeField]
    private float height;

    //public GameObject emitter;

    [SerializeField]
    private bool isAcc;

    // Use this for initialization
    void Start()
    {
        isAcc = true;

        sun = GameObject.FindGameObjectWithTag("sun");
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
        //transform.up = GetComponent<Rigidbody>().velocity;
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
        UnityEditor.Handles.color = Color.blue;
        float distance = Vector3.Distance(transform.position, sun.transform.position);
        UnityEditor.Handles.DrawWireDisc(sun.transform.position, Vector3.up, distance);
    }
}
