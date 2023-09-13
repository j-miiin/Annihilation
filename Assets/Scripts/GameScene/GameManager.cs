using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public DataManager _dataManager;

    [SerializeField] private Stage _stage;
    private int _curStage;
    private bool _isOver;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // DataManager에서 현재 선택된 스테이지 정보를 받아옴
        _curStage = _dataManager.curStage;
        if (_curStage == 1)
        {
            // TODO 스테이지 배경 이미지 정보 세팅
            _stage.SetStageInfo("NewEasyStageGrid");
        }
        else if (_curStage == 2)
        {
            _stage.SetStageInfo("NewNormalStageGrid");
        }
        else if (_curStage == 3)
        {
            _stage.SetStageInfo("NewHardStageGrid");
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

    public PaddleType GetPaddleType()
    {
        return (PaddleType)_dataManager.paddleInfo;
    }

    public int GetCurStage()
    {
        return _curStage;
    }

    public void GameOver()
    {
        _isOver = true;
    }

     public void UpdateScore(int score)
    {
        _stage.UpdateScore(score);
    }

    public void SaveData(int starRating)
    {
        if (_curStage == 1)
        {
            _dataManager.easyStar = starRating;
        }
        if (_curStage == 2)
        {
            _dataManager.normalStar = starRating;
        } else
        {
            _dataManager.hardStar = starRating;
        }
    }

    public void UpdateLockedStage()
    {
        if (_dataManager.lockedStage < 3) _dataManager.lockedStage = _curStage + 1;
    }

    public void GoHome()
    {
        SceneManager.LoadScene("StageScene");
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoNextStage()
    {
        if (_dataManager.curStage != 3)
        {
            _dataManager.curStage += 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            NewSoundManager.instance.DestroySoundManager();
            SceneManager.LoadScene("EndScene");
        }
    }
}
