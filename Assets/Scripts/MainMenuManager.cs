using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
   Logger logger = Logger.Instance;
   public string levelSceneName;
   public TextAsset textJSON;
   LevelList levelsList = new LevelList();
   public GameObject LevelContainer;
   public GameObject LevelButtonPrefab;

   void Start(){
    levelsList = JsonUtility.FromJson<LevelList>(textJSON.text);
    SpawnLevels();
   }

   void SpawnLevels(){

      for(var i = 0; i < levelsList.levels.Length;i++){
         GameObject levelPrefab = Instantiate(LevelButtonPrefab, LevelContainer.transform);
         var levelNumber = i + 1;
         levelPrefab.gameObject.transform.GetChild(0).GetComponentsInChildren<Text>()[0].text = "Level " + levelNumber;
         levelPrefab.GetComponent<Button>().onClick.AddListener(() => ChangeToLevel(levelNumber));
      }
   }

   public void ChangeToLevel(int levelId){
      Debug.Log(levelId);
        logger.SelectedLevel = levelId;
        logger.LevelData = levelsList.levels[levelId-1].level_data;
        SceneManager.LoadScene(levelSceneName);
   }
}
