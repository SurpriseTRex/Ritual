using UnityEngine;
using System.Collections.Generic;
using System;

public class Cup : MonoBehaviour 
{
    public int capacity;
    public int fillLevel;
    public int overflowThreshold;
    public Sprite emptyChalice;
    public Sprite fullChalice;

    void Start () 
    {
        capacity = 250;
        fillLevel = 0;
        overflowThreshold = capacity + (capacity / 10);
    }
    
    void Update () 
    {
    
    }

    internal void Fill()
    {
        if (fillLevel < overflowThreshold)
        {
            fillLevel++;
        }
        else
        {
            Overflow();
        }
        Debug.Log("cup capacity: " + fillLevel + " / " + capacity);
    }

    private void Overflow()
    {
        throw new NotImplementedException();
    }
}