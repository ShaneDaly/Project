using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{

	public string newScene;
	string level;

	void OnGUI()
	{
		int buttonWidth = 120;
		int buttonHeight = 60;
		
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),(1 * Screen.height / 3) - (buttonHeight / 2),buttonWidth,buttonHeight),"Retry!"))
		{
			level = LevelManager.getLastLevel();
			Application.LoadLevel(level);
		}
		
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),(2 * Screen.height / 3) - (buttonHeight / 2),buttonWidth,buttonHeight),"Quit game"))
		{
			Application.LoadLevel("-MainMenuScreen");
		}
	}
	

}
