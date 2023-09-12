using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverPanel : MonoBehaviour
{
    const string STAGE_CLEAR = "STAGE CLEAR";
    const string STAGE_FAIL = "STAGE FAIL";

    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject _star1EmptyImage;
    [SerializeField] private GameObject _star2EmptyImage;
    [SerializeField] private GameObject _star3EmptyImage;
    [SerializeField] private GameObject _star1FilledImage;
    [SerializeField] private GameObject _star2FilledImage;
    [SerializeField] private GameObject _star3FilledImage;
    [SerializeField] private Button _homeBtn;
    [SerializeField] private Button _retryBtn;
    [SerializeField] private Button _nextStageBtn;

    private void Awake()
    {
        SetBtn();
    }

    public void SetBtn()
    {
        // Stage End Panel의 Home, Retry, Next Stage 버튼에 Click Listener를 달아줌
        _homeBtn.onClick.AddListener(() => { GameManager.Instance.GoHome(); });
        _retryBtn.onClick.AddListener(() => { GameManager.Instance.RetryGame(); });
        _nextStageBtn.onClick.AddListener(() => { GameManager.Instance.GoNextStage(); });
    }

    // Stage 클래스가 호출하는 함수
    // 스테이지 종료 시 Stage End Panel의 상태를 Set
    public void SetGameOverPanel(bool isClear, int score, int starRating)
    {
        _gameOverText.text = isClear ? STAGE_CLEAR : STAGE_FAIL;
        _scoreText.text = "SCORE " + (isClear ? score : 0);

        SetStarImage(starRating);
        SetNextStageBtnActive(isClear);

        gameObject.SetActive(true);
    }

    // 점수에 따른 별 이미지 세팅
    private void SetStarImage(int starRating)
    {
        _star1FilledImage.SetActive((starRating >= 1));
        _star2FilledImage.SetActive((starRating >= 2));
        _star3FilledImage.SetActive((starRating >= 3));
    }

    // 스테이지 클리어 여부에 따라 다음 스테이지 버튼 활성/비활성화
    private void SetNextStageBtnActive(bool isActive)
    {
        _nextStageBtn.interactable = isActive;
    }
}
