using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadLevelDelay : MonoBehaviour
{
    public int level;
    public float delay;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(wait(delay));
    }

    public void StartLevel()
    {
        Application.LoadLevel(level);
    }


    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);

        StartLevel();
    }

}

