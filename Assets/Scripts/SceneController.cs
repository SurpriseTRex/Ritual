using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour 
{
	string levelToLoad;

	void Update () 
	{

	}

	public void loadNextLevel(string levelToLoad)
	{
		if (Application.loadedLevelName != levelToLoad)
		{
			Application.LoadLevel(levelToLoad);
		}
	}
}
