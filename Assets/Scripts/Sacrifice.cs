using UnityEngine;
using System.Collections.Generic;
using System;

public class Sacrifice : MonoBehaviour
{
    GameObject liquidCollider;
    private int quantity = 500;

    void Start()
    {
        liquidCollider = Instantiate(GameObject.Find("liquid"));
        liquidCollider.SetActive(false);
    }

    void Update () 
    {
        if (gameObject.GetComponent<TargetItem>().activated && quantity > 0)
        {
            quantity--;
        }
        else if (gameObject.GetComponent<TargetItem>().activated)
        {
            liquidCollider.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
    }

    internal void Kill()
    {
        Debug.Log("Killed " + gameObject.name);
        gameObject.GetComponent<ParticleSystem>().Play();

        Vector3 pos = transform.position;
        liquidCollider.SetActive(true);
        liquidCollider.transform.position = new Vector3(pos.x, pos.y - 1.7f, pos.z);
        gameObject.GetComponent<TargetItem>().activated = true;
    }
}