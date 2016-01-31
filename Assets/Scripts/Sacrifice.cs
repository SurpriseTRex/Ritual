using UnityEngine;
using System.Collections.Generic;
using System;

public class Sacrifice : MonoBehaviour
{
    GameObject liquidCollider;
    private int blood = 500;

    private int stabbedTimes;
    private int maxStabbings;

    void Start()
    {
        liquidCollider = Instantiate(GameObject.Find("liquid"));
        liquidCollider.SetActive(false);

        maxStabbings = 3;
        stabbedTimes = 0;
    }

    void Update () 
    {
        if (gameObject.GetComponent<TargetItem>().activated && blood > 0)
        {
            blood--;
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

        stabbedTimes++;

        if (stabbedTimes > maxStabbings)
        {
            Overkill();
        }
    }

    private void Overkill()
    {
        Debug.Log("OVERKILL! LOST POINTS!");
    }
}