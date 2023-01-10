using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    Point pointData;
    RectTransform rectTransform;
    Logger Logger = Logger.Instance;
    public Sprite overrideSprite;
    Text numberText;
    Animator animator;
    LineController lineController;

    private void Start() {

        numberText = this.GetComponentsInChildren<Text>()[0];
        lineController = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LineController>();
        SetPosition();
        UpdateTextNumber();       
    }

    public void ChangeState(){
        
        if(pointData.PointNumber == 1 && pointData.IsSelected == false){
            Logger.SelectedPointNumber = 1;
            PlayAnimationFadeOut();
            pointData.IsSelected = true;
            ChangeTexture();
            Logger.FirstSelectedPointCordinates = transform.localPosition;
            Logger.PointOneCordinates = transform.localPosition;
        }else if(Logger.SelectedPointNumber +1 == pointData.PointNumber && pointData.IsSelected == false){
            Logger.SelectedPointNumber = pointData.PointNumber;
            Logger.SecondSelectedPointCordinates = transform.localPosition;
            PlayAnimationFadeOut();
            lineController.DrawLine();
            Logger.FirstSelectedPointCordinates = transform.localPosition;
            pointData.IsSelected = true;
            ChangeTexture();
        }
    }

    public void SetDataForPoint(Point point){
        pointData = point;
    }

    void SetPosition(){
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(pointData.X,pointData.Y*-1);
    }

    void UpdateTextNumber(){
       numberText.text = pointData.PointNumber.ToString();
    }

    void ChangeTexture(){
        this.GetComponent<Image>().sprite = overrideSprite;
    }

    void PlayAnimationFadeOut(){
        if(pointData.IsSelected == false){
            animator = numberText.GetComponent<Animator>();
            animator.SetTrigger("ObjectClicked");
        }

    }

}
