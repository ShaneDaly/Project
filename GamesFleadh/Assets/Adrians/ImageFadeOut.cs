using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFadeOut : MonoBehaviour 
{
    public Image image;
    public float fadeSpeed;
    public float delay;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(wait(delay));
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    void fadeOut(Image newImgOut, float fadeSpeedRepeat)
    {
        newImgOut.CrossFadeAlpha(0, fadeSpeedRepeat, false);
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);

        fadeOut(image, fadeSpeed);
    }

}
