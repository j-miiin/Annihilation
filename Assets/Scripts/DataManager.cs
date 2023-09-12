using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data Manager", order = 1)]
public class DataManager : ScriptableObject
{  
    public int curStage = 1;
    public int lockedStage = 1;

    public int easyStar = 0;
    public int normalStar = 0;
    public int hardStar = 0;
}
