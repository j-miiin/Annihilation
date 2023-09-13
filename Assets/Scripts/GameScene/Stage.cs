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
    private UIGameOverPanel _gameOverPanel;
    private UIScoreAndTimePanel _scoreAndTimePanel;

    // 생성할 운석 grid prefab
    private string _meteorPrefabName;

    private bool _isOver;   // GameManager에서 게임 실패 조건 달성 시 바뀌는 값
    private float _runningTime = 0f;
    private int _score = 0;

    void Start()
    {
        InitStage();
        InitUIComponent();
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

    private void InitUIComponent()
    {
        _gameOverPanel = GameUIManager.Instance.GetUIComponent<UIGameOverPanel>();
        _scoreAndTimePanel = GameUIManager.Instance.GetUIComponent<UIScoreAndTimePanel>();
    }

    private void UpdateTime()
    {
        _runningTime += Time.deltaTime;
        _scoreAndTimePanel.SetTimeText(_runningTime.ToString("N2"));
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
            starRating = GetStageStarResult();  // 스테이지를 클리어했다면 별점을 계산
            GameManager.Instance.SaveData(starRating);
            GameManager.Instance.UpdateLockedStage();
        } 
        _gameOverPanel.SetGameOverPanel(isClear, _score, starRating);
    }

    private int GetStageStarResult()
    {
        int finalScore = _score + Mathf.FloorToInt(1000 / _runningTime);

        int starRating = finalScore / 100;
        starRating = Math.Min(starRating, 3);

        return starRating;
    }

    // GameManager에서 받아온 운석 grid 프리팹 이름과 스테이지 배경 이미지 리소스 이름 세팅
    public void SetStageInfo(string meteorPrefabName)
    {
        _meteorPrefabName = meteorPrefabName;
    }

    // GameManager에서 스테이지 실패 조건 달성 시 호출
    public void StageFail()
    {
        _isOver = true;
    }

    public void UpdateScore(int score)
    {
        _score += score;
        _scoreAndTimePanel.SetScoreText(_score);
    }
}
