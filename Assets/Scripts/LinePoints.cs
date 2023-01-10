using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePoints
{
    public Vector3 StartPoint {get;}
    public Vector3 EndPoint {get;}

    public LinePoints(Vector3 startPoint, Vector3 endPoint){
        this.StartPoint = startPoint;
        this.EndPoint = endPoint;
    }
}
