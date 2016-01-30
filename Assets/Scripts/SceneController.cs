using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour 
{
	string levelToLoad;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.E))
		{
			if (Application.loadedLevelName == "table_scene")
			{
				loadNextLevel("player_scene");
			}
		}
	}

	public void loadNextLevel(string levelToLoad)
	{
		if (Application.loadedLevelName != levelToLoad)
		{
			Application.LoadLevel(levelToLoad);
		}
	}
}
