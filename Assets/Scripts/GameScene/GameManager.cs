using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [SerializeField] private Stage _stage;
    private int _curStage;
    private bool _isOver;

    private void Awake()
    {
        I = this;
    }

    void Start()
    {
        // StageManager���� stage ���� �������� �κ�
        _curStage = StageManager.SM.GetStage();
        if (_curStage == 1)
        {
            
        }
        else if (_curStage == 2)
        {
            
        }
        else if (_curStage == 3)
        {
           
        }

        // TODO SetStageInfo ���� �� ����
        // _curStage = StageManager.S.GetStage();
        _stage.SetStageInfo("test", "test");
        _isOver = false;
    }

    void Update()
    {
        if (_isOver)
        {
            _stage.StageFail();
        }
    }

    public void GameOver()
    {
        _isOver = true;
    }
}
