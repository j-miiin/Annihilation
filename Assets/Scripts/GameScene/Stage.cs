using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    // 생성할 운석 grid prefab
    private string _meteorPrefabName;
    // 스테이지 배경 이미지 리소스 이름
    private string _backgroundImage;

    private bool _isOver;   // GameManager에서 게임 실패 조건 달성 시 바뀌는 값
    private float _runningTime = 0f;
    private int _score = 0;

    void Start()
    {
        InitStage();
    }

    void Update()
    {
        UpdateTime();

        if (AllMeteorsDestroyed())
        {
            GameOver(true);
        }
        if (_isOver)
        {
            GameOver(false);
        }
    }

    private void InitStage()
    {
        Time.timeScale = 1f;
        _isOver = false;

        Instantiate(Resources.Load<GameObject>("Prefabs/Stages/" + _meteorPrefabName));
    }

    private void UpdateTime()
    {
        _runningTime += Time.deltaTime;
        StageUIManager.Instance.scoreAndTimePanel.GetComponent<ScoreAndTimePanel>().SetTimeText(_runningTime.ToString("N2"));
    }

    // 모든 운석이 파괴되었는지 확인
    private bool AllMeteorsDestroyed()
    {
        GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
        return meteors.Length == 0;
    }

    // isClear == true 이면 스테이지 클리어, false 이면 스테이지 실패
    private void GameOver(bool isClear)
    {
        Time.timeScale = 0f;

        int starRating = 0;
        if (isClear)
        {
            starRating = GetStageStarResult();
            //PlayerPrefs.SetInt(StringKey.STAR_RATING_PREFS, starRating);
            //PlayerPrefs.SetInt(StringKey.LOCKED_STAGE_PREFS, PlayerPrefs.GetInt(StringKey.LOCKED_STAGE_PREFS) + 1);
        }

        GameManager.Instance.SaveData(starRating);
        StageUIManager.Instance.gameOverPanel.GetComponent<GameOverPanel>().SetGameOverPanel(isClear, _score, starRating);
    }

    private int GetStageStarResult()
    {
        int finalScore = _score + Mathf.FloorToInt(1000 / _runningTime);

        int starRating = finalScore / 100;
        starRating = Math.Min(starRating, 3);

        return starRating;
    }

    // GameManager에서 받아온 운석 grid 프리팹 이름과 스테이지 배경 이미지 리소스 이름 세팅
    public void SetStageInfo(string meteorPrefabName, string backgroundImage)
    {
        _meteorPrefabName = meteorPrefabName;
        _backgroundImage = backgroundImage;
    }

    // GameManager에서 스테이지 실패 조건 달성 시 호출
    public void StageFail()
    {
        _isOver = true;
    }

    public void UpdateScore(int score)
    {
        _score += score;
        StageUIManager.Instance.scoreAndTimePanel.GetComponent<ScoreAndTimePanel>().SetScoreText(_score);
        //ScoreAndTimePanel scoreAndTimePanel = (ScoreAndTimePanel)StageUIManager.Instance.GetUIComponent("ScoreAndTimePanel");
        //scoreAndTimePanel.SetScoreText(_score);
    }
}
