using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    private GameObject _canvas;
    private GameObject _gameOverText;
    private GameObject _meteorController;

    private string _meteorPrefabName;
    private string _backgroundImage;

    private bool _isOver;   // 스테이지 실패 조건 달성 시 GameManager가 true로 바꿔주는 값

    const string CANVAS = "Canvas";
    const string METEOR_CONTROLLER = "MeteorController";
    const string GAMEOVER_TEXT = "GameOverText";

    const string STAGE_CLEAR = "Stage Clear";
    const string STAGE_FAIL = "Stage Fail";

    void Start()
    {
        InitStage();
        StartGame();
    }

    void Update()
    {
        // TODO MeteorController 완성 시 주석 풀기
        //if (_meteorController.transform.childCount == 0)
        //{
        //    GameOver(true);
        //}
        if (_isOver)
        {
            GameOver(false);
        }
    }

    private void InitStage()
    {
        Time.timeScale = 1f;
        _isOver = false;

        // 운석 grid 생성
        Instantiate(Resources.Load<GameObject>("Prefabs/Stages/"+_meteorPrefabName));

        // TODO 백그라운드 이미지 위치, 이름 논의 후 이미지 불러오는 코드 다시 설정
        _canvas = GameObject.Find(CANVAS);
        //Image backgroundImage = _canvas.transform.Find("BackgroundImage").GetComponent<Image>();
        //backgroundImage.sprite = Resources.Load<Sprite>("easystage_bg");
        _gameOverText = _canvas.transform.Find(GAMEOVER_TEXT).gameObject;

        // TODO MeteorController 완성 시 주석 풀기
        //_meteorController = GameObject.Find(METEOR_CONTROLLER);
    }

    private void StartGame()
    {
        // 마우스 클릭 시 공 움직이기 시작
    }

    // isClear == true 이면 스테이지 클리어, false 이면 실패
    private void GameOver(bool isClear)
    {
        Time.timeScale = 0f;

        if (isClear)
        {
            _gameOverText.GetComponent<TMP_Text>().text = STAGE_CLEAR;
        } else
        {
            _gameOverText.GetComponent<TMP_Text>().text = STAGE_FAIL;
        }

        _gameOverText.SetActive(true);
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
}
