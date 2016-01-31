using UnityEngine;
using System.Collections.Generic;
using System;

public class DecorationSpace : MonoBehaviour 
{
    int timesPlaced = 0;

    PointsController pc;

    void Start () 
    {
        pc = GameObject.Find("GLOBAL_SCRIPTS").GetComponent<PointsController>();
    }
    
    void Update () 
    {

    }

    internal void Decorate(ToolItem decItem)
    {
        float magnitude = (gameObject.transform.position - decItem.transform.position).magnitude;
        int pts = (int)(1000 - ((timesPlaced * 100) * (magnitude * 10)));
        pc.putPoints += pts;
    }
}