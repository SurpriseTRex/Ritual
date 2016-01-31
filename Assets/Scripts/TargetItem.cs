using UnityEngine;
using System.Collections.Generic;
using System;

public class TargetItem : MonoBehaviour 
{
    Vector3 origScale;
    Vector3 hoverScale;
    internal bool activated;

    void Start () 
    {
        origScale = gameObject.transform.localScale;
        hoverScale = origScale * 1.1f;
    }
    
    void Update () 
    {

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