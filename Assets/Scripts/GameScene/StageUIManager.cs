using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageUIManager : MonoBehaviour
{
    //public Dictionary<string, MonoBehaviour> stageUIDic;
    public GameObject gameOverPanel;
    public GameObject scoreAndTimePanel;

    public static StageUIManager Instance;

    private void Awake()
    {
        Instance = this;
        //stageUIDic = new Dictionary<string, MonoBehaviour>();
    }

    //public void AddUIComponent(MonoBehaviour uiComponent)
    //{
    //    stageUIDic.Add(uiComponent.name, uiComponent);
    //}

    //public MonoBehaviour GetUIComponent(string name)
    //{
    //    return stageUIDic[name];
    //}
}
