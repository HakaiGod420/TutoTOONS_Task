using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    List<Point> points = new List<Point>();

    public GameObject prefabPoint;
    public GameObject parentObject;
    public RectTransform canvasRect;
    public RectTransform pointLocationRect;
    Logger logger = Logger.Instance;

    float valueScaleX;
    float valueScaleY;

    private void Awake(){
        pointLocationRect.sizeDelta = new Vector2(canvasRect.rect.height, canvasRect.rect.height);
        valueScaleX = pointLocationRect.rect.size.x / (float)1000f;
        valueScaleY = pointLocationRect.rect.size.y / (float)1000f;
        ReadPoints();
        SpawnPoints();

    }
    public void ReadPoints(){

        int PointCounter = 0;

        Debug.Log(logger.LevelData.Length);
        
        for(int i = 0; i<logger.LevelData.Length; i+=2 ){
            PointCounter++;
            points.Add(new Point(PointCounter,Convert.ToInt32(logger.LevelData[i]) * valueScaleX,Convert.ToInt32(logger.LevelData[i+1]) * valueScaleY));

        }
        logger.LastPosiblePointNumber = PointCounter;
        
    }

    public void SpawnPoints(){

        foreach(Point p in points){
            GameObject pointPrefab = Instantiate(prefabPoint, parentObject.transform);
            pointPrefab.GetComponent<PointManager>().SetDataForPoint(p);
        }
    }
}
