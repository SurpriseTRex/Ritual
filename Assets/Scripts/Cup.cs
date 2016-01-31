using UnityEngine;
using System.Collections.Generic;
using System;

public class Cup : MonoBehaviour 
{
    public int capacity;
    public int fillLevel;
    public int overflowThreshold;
    public Sprite overflowChalice;
    public Sprite fullChalice;

	public bool hasOverflowed;

    PointsController pc;

    void Start () 
    {
        pc = GameObject.Find("GLOBAL_SCRIPTS").GetComponent<PointsController>();

        capacity = 180;
        fillLevel = 0;
        overflowThreshold = capacity * 2;
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
			pc.cupPoints += 5;
        }
        else
        {
			if (!hasOverflowed)
			{
				Overflow();
			}
        }
    }

    private void Overflow()
    {
		pc.cupPoints -= 10 * overflowThreshold;
        gameObject.GetComponent<SpriteRenderer>().sprite = overflowChalice;
        Debug.Log("SPILLED IT! LOSE POINTS.");
		hasOverflowed = true;
    }
}