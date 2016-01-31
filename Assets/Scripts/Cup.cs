using UnityEngine;
using System.Collections.Generic;
using System;

public class Cup : MonoBehaviour 
{
    public int capacity;
    public int fillLevel;

    void Start () 
    {
        capacity = 500;
        fillLevel = 0;
    }
    
    void Update () 
    {
    
    }

    internal void Fill()
    {
        if (fillLevel < capacity)
        {
            fillLevel++;
        }
        Debug.Log("cup capacity: " + fillLevel + " / " + capacity);
    }
}