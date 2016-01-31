using UnityEngine;
using System.Collections.Generic;
using System;

public class Cup : MonoBehaviour 
{
    public int capacity;
    public int fillLevel;
    public float overflowThreshold;
    public Sprite overflowChalice;
    public Sprite fullChalice;

	public bool hasOverflowed;

    PointsController pc;

    void Start () 
    {
        pc = GameObject.Find("GLOBAL_SCRIPTS").GetComponent<PointsController>();

        capacity = 180;
        fillLevel = 0;
        overflowThreshold = capacity * 1.5f;
    }

    internal void Fill()
    {
        if (fillLevel > capacity && !hasOverflowed)
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
		pc.cupPoints -= (int)(10 * overflowThreshold);
        gameObject.GetComponent<SpriteRenderer>().sprite = overflowChalice;
		hasOverflowed = true;
    }
}