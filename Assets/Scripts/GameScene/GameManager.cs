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
        // StageManager에서 stage 정보 가져오는 부분
        //_curStage = StageManager.SM.GetStage();
        _curStage = 1;
        if (_curStage == 1)
        {
            // TODO SetStageInfo 인자 값 설정
            _stage.SetStageInfo("NewEasyStageGrid", "");
        }
        else if (_curStage == 2)
        {
            _stage.SetStageInfo("NormalStageGrid", "");
        }
        else if (_curStage == 3)
        {
            _stage.SetStageInfo("HardStageGrid", "");
        }
       
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
