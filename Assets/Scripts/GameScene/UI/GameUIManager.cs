using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Dictionary<string, MonoBehaviour> stageUIDic;

    public static GameUIManager Instance;

    private void Awake()
    {
        Instance = this;
        stageUIDic = new Dictionary<string, MonoBehaviour>();                                               
    }

    public T GetUIComponent<T>() where T : MonoBehaviour
    {
        if (!stageUIDic.ContainsKey(typeof(T).Name))
        {
            var obj = Instantiate(Resources.Load($"Prefabs/UI/{typeof(T).Name}"));
            stageUIDic.Add(typeof(T).Name, obj.GetComponent<T>());
        }
        return stageUIDic[typeof(T).Name] as T;
    }
}
