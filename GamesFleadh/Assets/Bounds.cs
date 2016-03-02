using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour
{
    public Bounds bounds = new Bounds(Vector3.zero, new Vector3(0, 0, 0));
    private Vector3 vector3;
    private Vector3 zero;

    public Bounds(Vector3 zero, Vector3 vector3)
    {
        this.zero = zero;
        this.vector3 = vector3;
    }

    void Start ()
    {
        
	}

	void Update ()
    {
	
	}
}
