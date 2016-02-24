using UnityEngine;
using System.Collections;

public class SatelliteStats : MonoBehaviour
{

    public string satelliteName = null;
    public int offence = 0;
    public int defence = 0;
    public int utility = 0;
    public int cost = 20;
    public bool active = true;

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
