using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    // 운석 블럭 grid 프리팹
    private string _meteorPrefabName;
    // 배경 이미지
    private string _backgroundImage;

    private bool _isOver;   // 스테이지 실패 조건 달성 시 GameManager가 true로 바꿔주는 값

    void Start()
    {
        InitStage();
    }

    void Update()
    {
        // TODO MeteorController 완성 시 주석 풀기
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

    //모든 운석 파괴 여부 확인
    private bool AllMeteorsDestroyed()
    {
        GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
        return meteors.Length == 0;
    }

    // isClear == true 이면 스테이지 클리어, false 이면 실패
    private void GameOver(bool isClear)
    {
        Time.timeScale = 0f;

        StageUIManager.S.SetStageEndPanel(isClear, GameManager.I.starRating);
    }

    // GameManager에서 호출하여 Stage 정보 설정
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

    public void GoHome()
    {

    }

    public void RetryGame()
    {

    }

    public void GoNextStageBtn()
    {

    }
}
