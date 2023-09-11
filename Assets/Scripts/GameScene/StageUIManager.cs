using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageUIManager : MonoBehaviour
{
    [SerializeField] private Stage _stage;

    const string STAGE_CLEAR = "STAGE CLEAR";
    const string STAGE_FAIL = "STAGE FAIL";

    const string CANVAS = "Canvas";
    // Stage End Panel
    const string STAGE_END_PANEL_IMAGE = "StageEndPanelImage";
    const string GAMEOVER_TEXT = "GameOverText";
    const string STAR1_IMAGE = "Star1Image";
    const string STAR2_IMAGE = "Star2Image";
    const string STAR3_IMAGE = "Star3Image";
    const string HOME_BTN = "HomeBtn";
    const string RETRY_BTN = "RetryBtn";
    const string NEXT_STAGE_BTN = "NextStageBtn";

    private GameObject _canvas;
    private GameObject _stageEndPanelImage;
    private TMP_Text _gameOverText;
    private Image _star1Image;
    private Image _star2Image;
    private Image _star3Image;
    private Button _homeBtn;
    private Button _retryBtn;
    private Button _nextStageBtn;

    public static StageUIManager S;

    private void Awake()
    {
        S = this;
        InitStagePanel();
    }

    // Stage End Panel에 사용될 오브젝트 Init
    private void InitStagePanel()
    {
        // TODO 백그라운드 이미지 위치, 이름 논의 후 이미지 불러오는 코드 다시 설정
        _canvas = GameObject.Find(CANVAS);
        // Stage End Panel
        _stageEndPanelImage = _canvas.transform.Find(STAGE_END_PANEL_IMAGE).gameObject;

        // 게임 종료 텍스트 (Clear or Fail)
        _gameOverText = _stageEndPanelImage.transform.Find(GAMEOVER_TEXT).GetComponent<TMP_Text>();

        // 별 이미지
        _star1Image = _stageEndPanelImage.transform.Find(STAR1_IMAGE).GetComponent<Image>();
        _star2Image = _stageEndPanelImage.transform.Find(STAR2_IMAGE).GetComponent<Image>();
        _star3Image = _stageEndPanelImage.transform.Find(STAR3_IMAGE).GetComponent<Image>();

        // 버튼
        _homeBtn = _stageEndPanelImage.transform.Find(HOME_BTN).GetComponent<Button>();
        _retryBtn = _stageEndPanelImage.transform.Find(RETRY_BTN).GetComponent<Button>();
        _nextStageBtn = _stageEndPanelImage.transform.Find(NEXT_STAGE_BTN).GetComponent<Button>();
    }

    // Stage 클래스가 호출하는 함수
    // 스테이지 종료 시 Stage End Panel의 상태를 Set
    public void SetStageEndPanel(bool isClear, int score)
    {

        if (isClear)
        {
            _gameOverText.text = STAGE_CLEAR;
        }
        else
        {
            _gameOverText.text = STAGE_FAIL;
        }

        SetStarImage(score);
        SetBtn();

        _stageEndPanelImage.SetActive(true);
    }

    // 점수에 따른 별 이미지 세팅
    private void SetStarImage(int score)
    {
        Sprite filledStar = Resources.Load<Sprite>("Image/StarImage/filled_star_img");
        Sprite emptyStar = Resources.Load<Sprite>("Image/StarImage/empty_star_img");

        _star1Image.sprite = (score > 30) ? filledStar : emptyStar;
        _star2Image.sprite = (score > 60) ? filledStar : emptyStar;
        _star3Image.sprite = (score > 90) ? filledStar : emptyStar;
    }

    // Stage End Panel의 Home, Retry, Next Stage 버튼에 Click Listener를 달아줌
    private void SetBtn()
    {
        _homeBtn.onClick.AddListener(() => { GameManager.I.GoHome(); } );
        _retryBtn.onClick.AddListener(() => { GameManager.I.RetryGame(); });
        _nextStageBtn.onClick.AddListener(() => { GameManager.I.GoNextStage(); });
    }
}
