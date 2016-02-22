using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalContollerScript : MonoBehaviour 
{
    public float resourceDelay;
    public int resources = 0;
    GameObject selectedPlanet = null;
    GameObject sidebarPlanet;
    GameObject sidebarSatellite;
    GameObject sidebarUpgrades;
    RaycastHit hitInfo = new RaycastHit();
    GameObject nameStat;
    GameObject offenceStat;
    GameObject defenceStat;
    GameObject utilityStat;
    Text name;
    Text off;
    Text def;
    Text util;
    PlanetStats planetStats;
    GameObject resVal;
    Text resValText;
    GameObject[] planets = null;
    GameObject costTxt;
    Text costVal;

    void Start () 
    {
        costTxt = GameObject.Find("CostValue");
        costVal = costTxt.GetComponent<Text>();
        sidebarPlanet = GameObject.Find("PlanetStuff");
        sidebarPlanet.SetActive(false);
        sidebarSatellite = GameObject.Find("SatelliteStuff");
        sidebarSatellite.SetActive(false);
        sidebarUpgrades = GameObject.Find("Upgrades");
        sidebarUpgrades.SetActive(false);
        resVal = GameObject.Find("ResourceNumber");
        resValText = resVal.GetComponent<Text>();
        resValText.text = "" + resources;
        StartCoroutine(wait(resourceDelay));
    }
	
	void Update () 
    {
        checkSelection();
        if (selectedPlanet != null)
        {
            if (sidebarPlanet.activeInHierarchy)
            {
                setPlanetStats();
                costVal.text = ("" + planetStats.cost);
            }
        }
    }

    void checkSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Planet")
                {
                    Debug.Log("Planet selected!");
                    selectedPlanet = hitInfo.transform.gameObject;
                    sidebarPlanet.SetActive(true);
                    sidebarSatellite.SetActive(false);
                    sidebarUpgrades.SetActive(true);
                }
            }
            else
            {
                Debug.Log("Nothing hit");
            }
        }

    }

    void setPlanetStats()
    {
        nameStat = GameObject.Find("PlanetName");
        offenceStat = GameObject.Find("PlanetOff");
        defenceStat = GameObject.Find("PlanetDef");
        utilityStat = GameObject.Find("PlanetUtil");
        name = nameStat.GetComponent<Text>();
        off = offenceStat.GetComponent<Text>();
        def = defenceStat.GetComponent<Text>();
        util = utilityStat.GetComponent<Text>();
        planetStats = selectedPlanet.GetComponent<PlanetStats>();
        if (sidebarPlanet.activeInHierarchy)
        {
            name.text = "" + planetStats.name;
            off.text = "" + planetStats.offence;
            def.text = "" + planetStats.defence;
            util.text = "" + planetStats.utility;
        }
    }

    public void upgradeSelectedOffence()
    {
        if (resources >= planetStats.cost)
        {
            resources -= planetStats.cost;
            planetStats.upgradeOffence();
            planetStats.cost++;
            resValText.text = "" + resources;
        }
    }

    public void upgradeSelectedDefence()
    {
        if (resources >= planetStats.cost)
        {
            resources -= planetStats.cost;
            planetStats.upgradeDefence();
            planetStats.cost++;
            resValText.text = "" + resources;
        }
    }

    public void upgradeSelectedUtility()
    {
        if (resources >= planetStats.cost)
        {
            resources -= planetStats.cost;
            planetStats.upgradeUtility();
            planetStats.cost++;
            resValText.text = "" + resources;
        }
    }

    public void calcResources()
    {

        planets = GameObject.FindGameObjectsWithTag("Planet");
        int currentProduction = 0;
        
        foreach (GameObject planet in planets)
        {
            PlanetStats planetStats2 = planet.GetComponent<PlanetStats>();
            currentProduction += planetStats2.utility;
        }
        resources += currentProduction;
        //Debug.Log("resources added " + currentProduction);
        resValText.text = "" + resources;
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        calcResources();
        StartCoroutine(wait(resourceDelay));
    }


}
