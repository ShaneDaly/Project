using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	public float Minutes = 5;
	public float Seconds = 0;
	public float Length;
	public string newScene;

	void OnGUI ()
	{
		Length = Screen.width / 8;
		GUI.Box(new Rect(45, 30, Length, 20), "Time left:" + Minutes + ":" + (int)Seconds);
	}

	void Update () 
	{
		if(Seconds <= 0)
		{
			Seconds = 60;
			if(Minutes >= 1)
			{
				Minutes--;
			}
			else
			{
				Minutes = 0;
				Seconds = 0;
			}
		}
		else
		{
			Seconds -= Time.deltaTime;
		}

		if (Minutes <= 0) 
		{
			Application.LoadLevel("WinScreen");
		}
	
	}
}
