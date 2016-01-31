using UnityEngine;
using System.Collections.Generic;

public class PointsController : MonoBehaviour 
{
    public int sacPoints;
    public int cupPoints;
    public int putPoints;
    public int finalPoints;

    void Start () 
    {
        sacPoints = cupPoints = putPoints = 0;
    }
    
    void Update () 
    {
        finalPoints = sacPoints + cupPoints + putPoints;
    }
}