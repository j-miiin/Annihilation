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

    private UISwipeStageThumbnail _uiSwipeStageThumbnail;
    private UISelectPaddleSkinPanel _uiSelectPaddleSkinPanel;

    public static StageManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _uiSwipeStageThumbnail = StageUIManager.Instance.GetUIComponent<UISwipeStageThumbnail>();
        _uiSelectPaddleSkinPanel = StageUIManager.Instance.GetUIComponent<UISelectPaddleSkinPanel>();
    }

    // 게임 시작 시 유저가 선택한 UI에 따라 각각 다른 stage value를 설정 후 해금된 스테이지라면 게임씬 로드
    public void StartGame(int stage)
    {
        _dataManager.curStage = stage;
        if (stage <= _dataManager.lockedStage) SceneManager.LoadScene("GameScene");
    }

    public int GetLockedStage()
    {
        return _dataManager.lockedStage;
    }

    public int GetStarNum(int stage)
    {
        if (stage == 1) return _dataManager.easyStar;
        else if (stage == 2) return _dataManager.normalStar;
        else return _dataManager.hardStar;
    }

    public void DeletePlayerInfo()
    {
        PlayerPrefs.DeleteKey("StarRating");
    }

    public void SavePaddleInfo(PaddleType paddleInfo)
    {
        _dataManager.paddleInfo = (int)paddleInfo;
    }
}
