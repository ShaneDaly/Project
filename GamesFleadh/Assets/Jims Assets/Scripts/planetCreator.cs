using UnityEngine;
using System.Collections;

public class planetCreator : MonoBehaviour 
{
    public float sunSize;
    public int numOfPlanets;
    public float planetDistance;

    private GameObject Sun;
    private GameObject nPlanet;

	// Use this for initialization
	void Start () 
    {
        createSun();
        createPlanets();
	}

    void createSun()
    {
        Sun = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Sun.AddComponent<sun>();
        Sun.GetComponent<sun>().setSize(sunSize);
        Sun.tag = "sun";
        Sun.name = "Sun";
    }

    void createPlanets()
    {
        float distanceCounter = 1;
        for (int x = 1; x <= numOfPlanets; x++)
        {
            nPlanet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            nPlanet.AddComponent<Planet>();
            nPlanet.tag = "planet";
            nPlanet.name = "Planet";
            nPlanet.GetComponent<Planet>().setSun(Sun);
            nPlanet.GetComponent<Planet>().setDistanceFromSun(planetDistance * distanceCounter);
            distanceCounter++;
        }
    }
}
