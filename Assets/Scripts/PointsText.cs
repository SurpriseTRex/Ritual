using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PointsText : MonoBehaviour 
{
    PointsController pc;
    Text text;

    void Start () 
    {
        pc = GameObject.Find("GLOBAL_SCRIPTS").GetComponent<PointsController>();
        text = gameObject.GetComponent<Text>();
    }
    
    void Update () 
    {
        text.text = "EVIL GOD POINTS: " + pc.finalPoints.ToString();
    }
}