using UnityEngine;
using System.Collections.Generic;
using System;

public class Sacrifice : MonoBehaviour
{
    GameObject liquidCollider;
    private int blood = 500;

    private int stabbedTimes;
    private int maxStabbings;

    PointsController pc;

    void Start()
    {
        pc = GameObject.Find("GLOBAL_SCRIPTS").GetComponent<PointsController>();

        liquidCollider = Instantiate(GameObject.Find("liquid"));
        liquidCollider.SetActive(false);

        maxStabbings = 1;
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
        gameObject.GetComponent<ParticleSystem>().Play();

        Vector3 pos = transform.position;
        liquidCollider.SetActive(true);
        liquidCollider.transform.position = new Vector3(pos.x, pos.y - 1.7f, pos.z);
        gameObject.GetComponent<TargetItem>().activated = true;

        if (stabbedTimes > maxStabbings)
        {
            Overkill();
        }
        else
        {
            pc.sacPoints += 1000;
        }

        stabbedTimes++;
    }

    private void Overkill()
    {
        Debug.Log("OVERKILL! LOST POINTS!");
        pc.sacPoints -= 1500;
    }
}