using UnityEngine;
using System.Collections.Generic;

public class ToolItem : MonoBehaviour 
{
	SceneController sceneController;

    public enum ItemType
    {
        Weapon,
        Container,
        Decorative
    }

    public ItemType type;

    void Awake () 
    {
		sceneController = GameObject.Find ("GLOBAL_SCRIPTS").GetComponent<SceneController> ();

		if (sceneController.tableObjectPositions.ContainsKey (gameObject.name))
		{			
			Vector2 objectPos = sceneController.tableObjectPositions [gameObject.name];
			gameObject.GetComponent<Rigidbody2D> ().position = objectPos;
		} 
    }

	void OnDestroy()
	{
		Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		if (sceneController.tableObjectPositions.ContainsKey (gameObject.name))
		{
			sceneController.tableObjectPositions[gameObject.name] = rigidbody.position;
		} 
		else
		{
			sceneController.tableObjectPositions.Add (gameObject.name, rigidbody.position);
		}
	}
}