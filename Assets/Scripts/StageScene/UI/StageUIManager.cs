using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageUIManager : MonoBehaviour
{
    public Dictionary<string, MonoBehaviour> stageUIDic;

    public static StageUIManager Instance;

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
