using UnityEngine;
using System.Collections;

public class PlanetStats : MonoBehaviour {

    public string planetName = null;
    public int offence = 0;
    public int defence = 0;
    public int utility = 0;
    public int cost = 20;
    public bool colonised = true;

    public void upgradeOffence()
    {
        Debug.Log("offence upgraded!");
        offence += 1;
    }
    public void upgradeDefence()
    {
        Debug.Log("defence upgraded!");
        defence += 1;
    }
    public void upgradeUtility()
    {
        Debug.Log("utility upgraded!");
        utility += 1;
    }
}
