using UnityEngine;
using System.Collections.Generic;
using System;

public class ToolItem : MonoBehaviour 
{
	SceneController sceneController;
    PointsController pc;

    public enum ItemType
    {
        Weapon,
        Container,
        Decorative
    }

    public ItemType type;
    public int decorativeTimesPlaced;

    void Awake () 
    {
		sceneController = GameObject.Find ("GLOBAL_SCRIPTS").GetComponent<SceneController> ();
        pc = GameObject.Find("GLOBAL_SCRIPTS").GetComponent<PointsController>();
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
                    d.Decorate(this);
                }
                break;
        }

        return false;
    }

    internal void AddPoints()
    {
        switch (type)
        {
            case ItemType.Decorative:
                pc.putPoints += (1000 / (decorativeTimesPlaced == 0 ? 1 : decorativeTimesPlaced)) - (100 * decorativeTimesPlaced);
                decorativeTimesPlaced++;
                break;
            default:
                break;
        }
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