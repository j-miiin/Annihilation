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
        // Stage End Panel�� Home, Retry, Next Stage ��ư�� Click Listener�� �޾���
        _homeBtn.onClick.AddListener(() => { GameManager.Instance.GoHome(); });
        _retryBtn.onClick.AddListener(() => { GameManager.Instance.RetryGame(); });
        _nextStageBtn.onClick.AddListener(() => { GameManager.Instance.GoNextStage(); });
    }

    // Stage Ŭ������ ȣ���ϴ� �Լ�
    // �������� ���� �� Stage End Panel�� ���¸� Set
    public void SetGameOverPanel(bool isClear, int score, int starRating)
    {
        _gameOverText.text = isClear ? STAGE_CLEAR : STAGE_FAIL;
        _scoreText.text = "SCORE " + (isClear ? score : 0);

        SetStarImage(starRating);
        SetNextStageBtnActive(isClear);

        gameObject.SetActive(true);
    }

    // ������ ���� �� �̹��� ����
    private void SetStarImage(int starRating)
    {
        _star1FilledImage.SetActive((starRating >= 1));
        _star2FilledImage.SetActive((starRating >= 2));
        _star3FilledImage.SetActive((starRating >= 3));
    }

    // �������� Ŭ���� ���ο� ���� ���� �������� ��ư Ȱ��/��Ȱ��ȭ
    private void SetNextStageBtnActive(bool isActive)
    {
        _nextStageBtn.interactable = isActive;
    }
}
