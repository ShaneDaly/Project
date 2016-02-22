using UnityEngine;
using System.Collections;

public class sun : MonoBehaviour 
{
	void Start () 
    {
        transform.position.Set(0, 0, 0);
	}

    public void setSize(float nSize)
    {
        transform.localScale = new Vector3(nSize, nSize, nSize);
    }
	
	void Update () 
    {
	    
	}
}
