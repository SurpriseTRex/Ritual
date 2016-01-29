using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour 
{
	string levelToLoad;

	void Update () 
	{
		// INPUT TEST WHEN YOU PRESS ONE AND TWO
		// NEED TO CHANGE
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			levelToLoad = "player_scene";
			loadNextLevel(levelToLoad);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			levelToLoad = "table_scene";
			loadNextLevel(levelToLoad);
		}
	}

	void loadNextLevel(string levelToLoad)
	{
		if (Application.loadedLevelName != levelToLoad)
		{
			Application.LoadLevel(levelToLoad);
		}
	}
}
