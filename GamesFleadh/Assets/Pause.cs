using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    private bool isEnabled = false;
    public GameObject pauseMenu;
    public GameObject sideBar;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
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
        sideBar.SetActive(false);
        pauseMenu.SetActive(true);
        isEnabled = true;
        Time.timeScale = 0;
    }

    public void unpause()
    {
        sideBar.SetActive(true);
        pauseMenu.SetActive(false);
        isEnabled = false;
        Time.timeScale = 1;
    }

}
