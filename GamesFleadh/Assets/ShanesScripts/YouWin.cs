using UnityEngine;
using System.Collections;

public class YouWin : MonoBehaviour {

	public string newScene;
	
	void OnGUI()
	{
		int buttonWidth = 120;
		int buttonHeight = 60;
		
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),(1 * Screen.height / 3) - (buttonHeight / 2),buttonWidth,buttonHeight),"Next Level"))
		{
			Application.LoadLevel("DemoScene");
		}
		
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),(2 * Screen.height / 3) - (buttonHeight / 2),buttonWidth,buttonHeight),"Quit game"))
		{
			Application.LoadLevel("-MainMenuScreen");
		}
	}
}
