using UnityEngine;
using System.Collections;

public class WinScreen : MonoBehaviour
{
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Enemy").Equals(0))
        {
            Application.LoadLevel("MainMenu");
        }
        else
        {
            //null;
        }
    }
    void Update()
	{
        
    }
}
