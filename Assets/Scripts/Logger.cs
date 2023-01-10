using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger
{
    public int SelectedLevel = 0;
    public int SelectedPointNumber = 0;
    public int LastPosiblePointNumber = -1;
    public Vector3 PointOneCordinates;
    public Vector3 FirstSelectedPointCordinates ;
    public Vector3 SecondSelectedPointCordinates;
    public string[] LevelData;

    private static Logger instance;

    private Logger() {}

    public static Logger Instance{
        get{
            if(instance == null){
                instance = new Logger();
            }
            return instance;
        }
    }
}
