using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class LineController : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject parentObject;

    private bool NextFromQueue = false; 
    private List<LinePoints> points = new List<LinePoints>();
    Logger Logger = Logger.Instance;
    Vector3 startingPoint,endPoint,onePoint;
    bool LastPoint = false;

    public float AnimationLength = 2f;

    void Update(){
        if(NextFromQueue == false && points.Count !=0){
            StartCoroutine(AnimatedLineDraw(points.First()));
            points.RemoveAt(0);
            NextFromQueue = true;
        }

        if(LastPoint == true && NextFromQueue == false){
            StartCoroutine(BackToMainMenu());
            LastPoint = false;
        }
    }
    public void DrawLine(){
        if(points.Count == 0){
            onePoint = Logger.PointOneCordinates;
        }
        points.Add(new LinePoints(Logger.FirstSelectedPointCordinates,Logger.SecondSelectedPointCordinates));

        if(Logger.SelectedPointNumber == Logger.LastPosiblePointNumber){
            Logger.SelectedLevel = -1;
            points.Add(new LinePoints(Logger.SecondSelectedPointCordinates,onePoint));
            LastPoint = true;
        }
    }

    private IEnumerator AnimatedLineDraw(LinePoints linePoints){
        GameObject line = Instantiate(linePrefab,parentObject.transform);
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;

        startingPoint = linePoints.StartPoint;
        endPoint = linePoints.EndPoint;
        

        Vector3 position = startingPoint;

        lineRenderer.SetPosition(0,startingPoint);

        float TimeStart = Time.time;

        while(position != endPoint){
            float time = (Time.time - TimeStart) / AnimationLength;
            position = Vector3.Lerp(startingPoint,endPoint,time);
            lineRenderer.SetPosition(1,position);
            yield return null;
        }
        
        NextFromQueue=false;
        yield return null;
    }

    private IEnumerator BackToMainMenu(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("LevelSelect");
    } 
}
