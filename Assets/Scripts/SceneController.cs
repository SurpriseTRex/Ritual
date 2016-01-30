using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour 
{
	string levelToLoad;

	void Start()
	{
		DontDestroyOnLoad (this);

		if (Application.loadedLevelName == "loader_scene")
		{
			loadNextLevel("player_scene");
		}
	}

	void Update () 
	{
		if (Application.loadedLevelName == "table_scene")
		{
			if (Input.GetKeyDown (KeyCode.E))
			{
				loadNextLevel("player_scene");
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.Quit();
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
