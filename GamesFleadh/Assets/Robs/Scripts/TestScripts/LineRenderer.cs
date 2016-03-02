using UnityEngine;
using System.Collections;

public class LineRenderer : MonoBehaviour 
{
    public float radius;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        OnDrawGizmosSelected(radius);
	
	}

    

    void OnDrawGizmosSelected(float radius)
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
