using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public DataManager _dataManager;

	//[Header("�� ���̵� �ð�")]
	[SerializeField] float fadeValue = 1f;
	[SerializeField] float fadeTime = 1f;

    public TMP_Text starRatingText;
    public Image star1Image;
    public Image star2Image;
    public Image star3Image;

    public static StageManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // 게임 시작 시 유저가 선택한 UI에 따라 각각 다른 stage value를 설정 후 해금된 스테이지라면 게임씬 로드
    public void StartGame(int stage)
    {
        _dataManager.curStage = stage;
        if (stage <= _dataManager.lockedStage) SceneManager.LoadScene("kjm-GameScene");
    }

    public int GetLockedStage()
    {
        return _dataManager.lockedStage;
    }

    public int GetEasyStar()
    {
        return _dataManager.easyStar;
    }

    public void DeletePlayerInfo()
    {
        PlayerPrefs.DeleteKey("StarRating");
    }
}
