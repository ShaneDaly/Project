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
        Debug.Log("Satellite offence upgraded!");
        offence += 1;
        cost += 1;
    }

    public void upgradeDefence()
    {
        Debug.Log("Satellite defence upgraded!");
        defence += 1;
        cost += 1;
    }
}
