using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    // 운석 블럭 grid 프리팹
    private string _meteorPrefabName;
    // 배경 이미지
    private string _backgroundImage;

    // Stage End Panel
    private GameObject _canvas;
    private GameObject _stageEndPanelImage;
    private TMP_Text _gameOverText;
    private Image _star1Image;
    private Image _star2Image;
    private Image _star3Image;


    private bool _isOver;   // 스테이지 실패 조건 달성 시 GameManager가 true로 바꿔주는 값

    const string CANVAS = "Canvas";

    // Stage End Panel
    const string STAGE_END_PANEL_IMAGE = "StageEndPanelImage";
    const string GAMEOVER_TEXT = "GameOverText";
    const string STAR1_IMAGE = "Star1Image";
    const string STAR2_IMAGE = "Star2Image";
    const string STAR3_IMAGE = "Star3Image";

    const string STAGE_CLEAR = "STAGE CLEAR";
    const string STAGE_FAIL = "STAGE FAIL";

    void Start()
    {
        InitStage();
        StartGame();
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

        // TODO 백그라운드 이미지 위치, 이름 논의 후 이미지 불러오는 코드 다시 설정
        _canvas = GameObject.Find(CANVAS);
        // Stage End Panel
        _stageEndPanelImage = _canvas.transform.Find(STAGE_END_PANEL_IMAGE).gameObject;
        _gameOverText = _stageEndPanelImage.transform.Find(GAMEOVER_TEXT).GetComponent<TMP_Text>();
        _star1Image = _stageEndPanelImage.transform.Find(STAR1_IMAGE).GetComponent<Image>();
        _star2Image = _stageEndPanelImage.transform.Find(STAR2_IMAGE).GetComponent<Image>();
        _star3Image = _stageEndPanelImage.transform.Find(STAR3_IMAGE).GetComponent<Image>();
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
            string clearText = STAGE_CLEAR + " Score: " + GameManager.I.finalScore;
            _gameOverText.GetComponent<TMP_Text>().text = clearText;
        } else
        {
            _gameOverText.text = STAGE_FAIL;
        }

        SetStarImage();

        _stageEndPanelImage.SetActive(true);
    }

    private void SetStarImage()
    {
        Sprite filledStar = Resources.Load<Sprite>("Image/StarImage/filled_star_img");
        Sprite emptyStar = Resources.Load<Sprite>("Image/StarImage/empty_star_img");

        _star1Image.sprite = (GameManager.I.finalScore > 30) ? filledStar : emptyStar;
        _star2Image.sprite = (GameManager.I.finalScore > 60) ? filledStar : emptyStar;
        _star3Image.sprite = (GameManager.I.finalScore > 90) ? filledStar : emptyStar;
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

    //모든 운석 파괴 여부 확인
    private bool AllMeteorsDestroyed()
    {
        GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
        return meteors.Length == 0;
    }
}
