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

        Vector3 pos = transform.position;
        GameObject liquidCollider = Instantiate(GameObject.Find("liquid"));
        liquidCollider.transform.position = new Vector3(pos.x, pos.y - 1.7f, pos.z);
    }
}