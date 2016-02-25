using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    private bool isEnabled = false;
    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pauseMenu.activeSelf == false)
            {
                pause();
                
            }
            else if (pauseMenu.activeSelf == true)
            {
                unpause();
            }

        }
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        isEnabled = true;
        Time.timeScale = 0;
    }

    public void unpause()
    {
        pauseMenu.SetActive(false);
        isEnabled = false;
        Time.timeScale = 1;
    }

}
