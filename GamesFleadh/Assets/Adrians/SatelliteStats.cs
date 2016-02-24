using UnityEngine;
using System.Collections;

public class SatelliteStats : MonoBehaviour
{

    public int offence = 0;
    public int defence = 0;
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
}
