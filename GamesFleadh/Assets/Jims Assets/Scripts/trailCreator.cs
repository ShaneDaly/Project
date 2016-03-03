using UnityEngine;
using System.Collections;

public class trailCreator : MonoBehaviour
{
    public TrailRenderer TR;
    
    public void enableTrail()
    {
        TR.enabled = true;
    }
    public void disableTrail()
    {
        TR.enabled = false;
    }

}
