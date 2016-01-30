using UnityEngine;
using System.Collections.Generic;
using System;

public class TargetItem : MonoBehaviour 
{
    bool active = false;
    Vector3 origScale;
    Vector3 hoverScale;

    void Start () 
    {
        origScale = gameObject.transform.localScale;
        hoverScale = new Vector3(origScale.x * 1.1f, origScale.y * 1.1f, origScale.z);
    }
    
    void Update () 
    {
        if (Input.GetMouseButtonUp(0) && active)
        {
            Activate();
        }
    }

    private void Activate()
    {
        Debug.Log("activated");
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Draggable")
        {
            gameObject.transform.localScale = hoverScale;
            active = true;
        }
    }

    public void OnTriggerExit2D(Collider2D c)
    {
        gameObject.transform.localScale = origScale;
        if (c.gameObject.tag == "Draggable")
        {
            active = false;
        }
    }
}