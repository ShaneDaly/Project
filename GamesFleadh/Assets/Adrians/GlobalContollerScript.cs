using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalContollerScript : MonoBehaviour 
{
    public float resourceDelay;
    public int resources = 0;
    GameObject selectedPlanet = null;
    GameObject selectedSatellite = null;
    GameObject sidebarPlanet;
    GameObject sidebarSatellite;
    GameObject sidebarPlanetUpgrades;
    GameObject sidebarSatelliteUpgrades;
    RaycastHit hitInfo = new RaycastHit();
    GameObject nameStat;
    GameObject offenceStat;
    GameObject defenceStat;
    GameObject utilityStat;
    GameObject offenceStatSat;
    GameObject defenceStatSat;
    Text name;
    Text off;
    Text def;
    Text util;
    Text satOff;
    Text satDef;
    PlanetStats planetStats;
    SatelliteStats satelliteStats;
    GameObject resVal;
    Text resValText;
    GameObject[] satellite = null;
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
        sidebarPlanetUpgrades = GameObject.Find("PlanetUpgrades");
        sidebarPlanetUpgrades.SetActive(false);
        sidebarSatelliteUpgrades = GameObject.Find("SatelliteUpgrades");
        sidebarSatelliteUpgrades.SetActive(false);
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
        else if (selectedSatellite != null)
        {
            if (sidebarSatellite.activeInHierarchy)
            {
                setSatelliteStats();
                costVal.text = ("" + satelliteStats.cost);
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
                    sidebarPlanetUpgrades.SetActive(true);
                } 
                else if (hitInfo.transform.gameObject.tag == "Satellite")
                {
                    Debug.Log("Satellite selected!");
                    selectedSatellite = hitInfo.transform.gameObject;
                    sidebarPlanet.SetActive(false);
                    sidebarSatellite.SetActive(true);
                    sidebarSatelliteUpgrades.SetActive(true);
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

    void setSatelliteStats()
    {
        offenceStatSat = GameObject.Find("SatelliteOff");
        defenceStatSat = GameObject.Find("SatelliteDef");
        satOff = offenceStatSat.GetComponent<Text>();
        satDef = defenceStatSat.GetComponent<Text>();
        satelliteStats = selectedSatellite.GetComponent<SatelliteStats>();
        if (sidebarSatellite.activeInHierarchy)
        {
            satOff.text = "" + satelliteStats.offence;
            satDef.text = "" + satelliteStats.defence;
        }
    }

    public void upgradePlanetOffence()
    {
        if (resources >= planetStats.cost)
        {
            resources -= planetStats.cost;
            planetStats.upgradeOffence();
            planetStats.cost++;
            resValText.text = "" + resources;
        }
    }

    public void upgradePlanetDefence()
    {
        if (resources >= planetStats.cost)
        {
            resources -= planetStats.cost;
            planetStats.upgradeDefence();
            planetStats.cost++;
            resValText.text = "" + resources;
        }
    }

    public void upgradePlanetUtility()
    {
        if (resources >= planetStats.cost)
        {
            resources -= planetStats.cost;
            planetStats.upgradeUtility();
            planetStats.cost++;
            resValText.text = "" + resources;
        }
    }

    public void upgradeSatOffence()
    {
        if (resources >= satelliteStats.cost)
        {
            resources -= satelliteStats.cost;
            satelliteStats.upgradeOffence();
            satelliteStats.cost++;
            resValText.text = "" + resources;
        }
    }

    public void upgradeSatDefence()
    {
        if (resources >= satelliteStats.cost)
        {
            resources -= satelliteStats.cost;
            satelliteStats.upgradeDefence();
            satelliteStats.cost++;
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
