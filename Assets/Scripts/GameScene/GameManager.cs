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
        // TODO StageManager에서 stage 정보 가져오는 부분 연결
        // TODO SetStageInfo 인자 값 설정
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
