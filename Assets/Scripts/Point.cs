using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    public int PointNumber {get;}
    public bool IsSelected {get;set;}
    public float X {get;}
    public float Y {get;}

    public Point(int pointNumber,float X_Cords,float Y_Cords){
        this.PointNumber = pointNumber;
        this.IsSelected = false;
        this.X = X_Cords;
        this.Y = Y_Cords;
    }
}
