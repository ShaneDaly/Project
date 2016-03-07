/** Author: James Gallagher
 * 
 * 
**/

using UnityEngine;
using System.Collections;

using System;

public class Planet : MonoBehaviour 
{
	public GameObject sun;
    GameObject ptrailer;
    public float rotationSpeed;
    public bool RandomSize;

    public bool allowOrbitDebug;

    private Vector3 sunVec;

    public bool selected;

    // 10km = 1 Scale
    public float size;
    public float sizeKm;

    private float g;
    private float m;
    private float gm;
    private float gmOverRadius;
    private float orbitV;

    float circumference;
    float rps;
    float rotateSpeed;

    public float ownRotateSpeed;
    public GameObject halo;
    public GameObject trailer;

    public bool destroy;
    
    // Use this for initialization
    void Start () 
	{
        sunVec = sun.transform.position;
        if (RandomSize)
        {
            setPlanetSize();
        }
        gameObject.tag = "Planet";

        ptrailer = (GameObject)Instantiate(trailer, transform.position, new Quaternion(0,0,0,0));
    }
	
	// Update is called once per frame
	void Update() 
	{
        sunVec = sun.transform.position;
        if (sun)
        {
            calcOrbit();
        }
        transform.RotateAround(transform.position, Vector3.up, ownRotateSpeed * Time.deltaTime);
    }

    // Sets the Sun to orbit
    public void setSun(GameObject nSun)
    {
        sun = nSun;
    }

    // If Creating the planets at random, it sets the planets distance from the sun
    public void setDistanceFromSun(float nZ)
    {
        transform.position = new Vector3(0,0,nZ);
        size = nZ;
    }

    //calculates the plamets orbit speed
    public void calcOrbit()
    {
        size = Vector3.Distance(transform.position, sun.transform.position);

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
        rotateSpeed = (rps * 60)*60;

        transform.RotateAround(sunVec, Vector3.up, rotateSpeed * Time.deltaTime);

    }

    // If RandomPlanet == true it sets a random planet size
    void setPlanetSize()
    {
        float rSize = UnityEngine.Random.Range(10.0F, 50.0F);
        transform.localScale = new Vector3(rSize, rSize, rSize);
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
        //GetComponent("halo").enabled = false;
    }
    public void unSelect()
    {
        selected = false;
    }
    public void destroyPlanet()
    {
        Destroy(ptrailer);
        Destroy(gameObject);
    }
    


    
    
}
