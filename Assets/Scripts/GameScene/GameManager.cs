using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [SerializeField] private Stage _stage;
    private int _curStage;
    private bool _isOver;

    public int finalScore = 0;
    public int score = 0;
    public TMP_Text scoreText; // 점수를 표시할 UI Text

    private float _runningTime = 0f;
    public TMP_Text timeText;

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
            _stage.SetStageInfo("EasyStageGrid", "");
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
        
        _runningTime += Time.deltaTime;
        timeText.text = _runningTime.ToString("N2");

        finalScore = score + Mathf.FloorToInt(_runningTime);
    }

    public void GameOver()
    {
        _isOver = true;
    }

    public void UpdateScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "Score: " + score; // UI 텍스트 업데이트
    }
}
