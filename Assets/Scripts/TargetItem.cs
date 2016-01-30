using UnityEngine;
using System.Collections.Generic;
using System;

public class TargetItem : MonoBehaviour 
{
    Vector3 origScale;
    Vector3 hoverScale;

    void Start () 
    {
        origScale = gameObject.transform.localScale;
        hoverScale = origScale * 1.1f;
    }
    
    void Update () 
    {

    }

    public void Activate(ToolItem item)
    {
        switch (item.type)
        {
            case ToolItem.ItemType.Weapon:
                Debug.Log("Stabbed " + gameObject.name);
                break;
            case ToolItem.ItemType.Container:
                Debug.Log("FIlling up a thing from " + gameObject.name);
                break;
            case ToolItem.ItemType.Decorative:
                Debug.Log("placed item on " + gameObject.name);
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Draggable")
        {
            gameObject.transform.localScale = hoverScale;
        }
    }

    public void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Draggable")
        {
            gameObject.transform.localScale = origScale;
        }
    }
}