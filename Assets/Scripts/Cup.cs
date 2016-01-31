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

    PointsController pc;

    void Start () 
    {
        pc = GameObject.Find("GLOBAL_SCRIPTS").GetComponent<PointsController>();

        capacity = 180;
        fillLevel = 0;
        overflowThreshold = capacity * 2;
    }
    
    void Update () 
    {
        if (fillLevel < overflowThreshold)
        {
            pc.cupPoints = fillLevel * 5;
        }
        else
        {
            pc.cupPoints = capacity * -10;
        }
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