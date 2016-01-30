using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour 
{
	string levelToLoad;
	public Vector2 playerPosition;

	void Start()
	{
		DontDestroyOnLoad (this);
		playerPosition = Vector2.zero;

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
