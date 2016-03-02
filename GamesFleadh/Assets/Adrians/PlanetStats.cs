using UnityEngine;
using System.Collections;

public class PlanetStats : MonoBehaviour {

    public string planetName = null;
    public int offence = 0;
    public float defence = 0;
    public int utility = 0;
    public int cost = 20;
    public bool colonised = true;

    public void upgradeOffence()
    {
        Debug.Log("Planet offence upgraded!");
        offence += 1;
        cost += 5;
    }
    public void upgradeDefence()
    {
        Debug.Log("Planet defence upgraded!");
        defence += 1;
        cost += 5;
    }
    public void upgradeUtility()
    {
        Debug.Log("Planet utility upgraded!");
        utility += 1;
        cost += 5;
    }
}
