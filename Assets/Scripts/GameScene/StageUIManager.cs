using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageUIManager : MonoBehaviour
{
    public Dictionary<string, MonoBehaviour> stageUIDic;

    //public GameObject gameOverPanel;
    //public GameObject scoreAndTimePanel;

    public static StageUIManager Instance;

    private void Awake()
    {
        Instance = this;
        stageUIDic = new Dictionary<string, MonoBehaviour>();                                               
    }

    public void AddUIComponent(MonoBehaviour uiComponent)
    {
        if (!stageUIDic.ContainsKey(uiComponent.name))
        {
            stageUIDic.Add(uiComponent.name, uiComponent);
        }
    }

    public T GetUIComponent<T>() where T : MonoBehaviour
    {
        if (stageUIDic.ContainsKey(typeof(T).Name))
        {
            return stageUIDic[typeof(T).Name] as T;
        }
        else return null;
    }
}
