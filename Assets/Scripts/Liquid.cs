using UnityEngine;
using System.Collections.Generic;
using System;

public class Liquid : MonoBehaviour 
{

    void Start () 
    {
    
    }
    
    void Update () 
    {
        
    }

    internal void Collect()
    {
        Debug.Log("Collected " + gameObject.name);
    }
}