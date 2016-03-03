using UnityEngine;
using System.Collections;

public class trailCreator : MonoBehaviour
{

    void Start()
    {
        gameObject.tag = "Trailer";
        transform.position.Set(transform.position.x, -50, transform.position.z);
    }

    public void enableTrail()
    {
        //gameObject.GetComponent<TrailRenderer>().time = 9;
    }
    public void disableTrail()
    {
        //gameObject.GetComponent<TrailRenderer>().time = 0;
    }

}
