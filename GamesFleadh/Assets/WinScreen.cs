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
<<<<<<< HEAD
            //null;
=======
>>>>>>> c7a750b27c3eb47548b7e219d493c83a347893c1
        }
    }
    void Update()
	{
        
    }
}
