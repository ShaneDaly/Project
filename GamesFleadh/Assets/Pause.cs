using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isEnabled = false;
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isEnabled)
        {
            if (Time.timeScale == 1)
            {
                GameObject.FindWithTag("pauseMenu").SetActive(true);
                isEnabled = true;
                Time.timeScale = 0;
                
            }
            else if(isEnabled)
            {
                GameObject.FindWithTag("pauseMenu").SetActive(false);
                isEnabled = false;
                Time.timeScale = 1;
            }
        }
    }
}
