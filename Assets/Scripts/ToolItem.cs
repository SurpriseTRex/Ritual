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
		string keyName = Application.loadedLevelName + "-" + gameObject.name;

		if (sceneController.tableObjectPositions.ContainsKey (keyName))
		{			
			Vector2 objectPos = sceneController.tableObjectPositions [keyName];
			gameObject.GetComponent<Rigidbody2D> ().position = objectPos;
		} 
    }

    public bool InteractWith(TargetItem target)
    {
        switch (type)
        {
            case ItemType.Weapon:
                Sacrifice s = target.gameObject.GetComponent<Sacrifice>();
                if (s)
                {
                    s.Kill();
                }
                break;
            case ItemType.Container:
                Liquid l = target.gameObject.GetComponent<Liquid>();
                if (l)
                {
                    l.Collect();
                    gameObject.GetComponent<Cup>().Fill();
                }
                break;
            case ItemType.Decorative:
                DecorationSpace d = target.gameObject.GetComponent<DecorationSpace>();
                if (d)
                {
                    d.Decorate();
                }
                break;
        }

        return false;
    }

    void OnDestroy()
	{
		Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		string keyName = Application.loadedLevelName + "-" + gameObject.name;

		if (sceneController.tableObjectPositions.ContainsKey (keyName))
		{
			sceneController.tableObjectPositions[keyName] = rigidbody.position;
		} 
		else
		{
			sceneController.tableObjectPositions.Add (keyName, rigidbody.position);
		}
	}
}