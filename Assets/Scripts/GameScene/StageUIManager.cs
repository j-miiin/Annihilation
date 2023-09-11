using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageUIManager : MonoBehaviour
{
    //public Dictionary<string, GameObject> stageUIDic;
    public GameObject GameOverPanel;
    public GameObject ScoreAndTimePanel;

    public static StageUIManager Instance;

    private void Awake()
    {
        Instance = this;
        //stageUIDic = new Dictionary<string, GameObject>();
    }

    //public void AddUIComponent(GameObject uiComponent)
    //{
    //    stageUIDic.Add(uiComponent.name, uiComponent);
    //}

    //public GameObject GetUIComponent(string name)
    //{
    //    return stageUIDic[name];
    //}
}
