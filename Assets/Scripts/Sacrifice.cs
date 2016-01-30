using UnityEngine;
using System.Collections.Generic;
using System;

public class Sacrifice : MonoBehaviour
{
    void Start () 
    {
    
    }
    
    void Update () 
    {
    
    }

    internal void Kill()
    {
        Debug.Log("Killed " + gameObject.name);
        gameObject.GetComponent<ParticleSystem>().Play();
    }
}