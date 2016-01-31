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
        capacity = 180;
        fillLevel = 0;
        overflowThreshold = capacity * 2;
    }
    
    void Update () 
    {
    
    }

    internal void Fill()
    {
        if (fillLevel > capacity)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = fullChalice;
        }
        if (fillLevel < overflowThreshold)
        {
            fillLevel++;
        }
        else
        {
            Overflow();
        }
    }

    private void Overflow()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = emptyChalice;
        Debug.Log("SPILLED IT! LOSE POINTS.");
    }
}