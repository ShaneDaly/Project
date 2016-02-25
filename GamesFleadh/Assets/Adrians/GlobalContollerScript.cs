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
    public PlanetStats planetStats;
    public SatelliteStats satelliteStats;
    GameObject resVal;
    public Text resValText;
    GameObject[] satellite = null;
    GameObject[] planets = null;
    GameObject costTxtPlanet;
    GameObject costTxtSatellite;
    Text costValPlanet;
    Text costValSatellite;
    public int newSatelliteCost = 100;
    GameObject newSatelliteCost2;



    void Start () 
    {
        newSatelliteCost2 = GameObject.Find("SatCostValue");
        Text newSatelliteCostTxt = newSatelliteCost2.GetComponent<Text>();
        newSatelliteCostTxt.text = "" + newSatelliteCost;
        costTxtPlanet = GameObject.Find("PlanetCostValue");
        costValPlanet = costTxtPlanet.GetComponent<Text>();
        costTxtSatellite = GameObject.Find("SatelliteCostValue");
        costValSatellite = costTxtSatellite.GetComponent<Text>();
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
                planetStats = selectedPlanet.GetComponent<PlanetStats>();
                setPlanetStats();
                costValPlanet.text = ("" + planetStats.cost);
            }
        }
        if (selectedSatellite != null)
        {
            if (sidebarSatellite.activeInHierarchy)
            {
                satelliteStats = selectedSatellite.GetComponent<SatelliteStats>();
                setSatelliteStats();
                costValSatellite.text = ("" + satelliteStats.cost);
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
                //Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Planet")
                {
                    Debug.Log("Planet selected!");
                    selectedPlanet = hitInfo.transform.gameObject;
                    sidebarPlanet.SetActive(true);
                    sidebarPlanetUpgrades.SetActive(true);
                    sidebarSatellite.SetActive(false);
                    sidebarSatelliteUpgrades.SetActive(false);
                    setPlanetStats();
                } 
                else if (hitInfo.transform.gameObject.tag == "Satellite")
                {
                    Debug.Log("Satellite selected!");
                    selectedSatellite = hitInfo.transform.gameObject;
                    sidebarSatellite.SetActive(true);
                    sidebarSatelliteUpgrades.SetActive(true);
                    sidebarPlanetUpgrades.SetActive(false);
                    sidebarPlanet.SetActive(false);
                    setSatelliteStats();
                }
            }
            else
            {

                //Debug.Log("Nothing hit");
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
            resValText.text = "" + resources;
            setPlanetStats();
        }
    }

    public void upgradePlanetDefence()
    {
        if (resources >= planetStats.cost)
        {
            resources -= planetStats.cost;
            planetStats.upgradeDefence();
            resValText.text = "" + resources;
            setPlanetStats();
        }
    }

    public void upgradePlanetUtility()
    {
        if (resources >= planetStats.cost)
        {
            resources -= planetStats.cost;
            planetStats.upgradeUtility();
            resValText.text = "" + resources;
            setPlanetStats();
        }
    }

    public void upgradeSatOffence()
    {
        if (resources >= satelliteStats.cost)
        {
            resources -= satelliteStats.cost;
            satelliteStats.upgradeOffence();
            resValText.text = "" + resources;
            setSatelliteStats();
        }
    }

    public void upgradeSatDefence()
    {
        if (resources >= satelliteStats.cost)
        {
            resources -= satelliteStats.cost;
            satelliteStats.upgradeDefence();
            resValText.text = "" + resources;
            setSatelliteStats();
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
