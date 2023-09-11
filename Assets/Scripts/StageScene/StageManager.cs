using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    private int stageValue = 1;

    public static StageManager SM;

	[Header("�� ���̵� �ð�")]
	[SerializeField] float fadeValue = 1f;
	[SerializeField] float fadeTime = 1f;

    public TMP_Text starRatingText;
    public Image star1Image;
    public Image star2Image;
    public Image star3Image;

    //StageManager�� GameManager�� ������
    private void Awake()
    {
        SM = this;
        DontDestroyOnLoad(gameObject);
    }

    // 게임 시작 시 유저가 선택한 UI에 따라 각각 다른 stage value를 설정 후 해금된 스테이지라면 게임씬 로드
    public void gameStart(SwipeUI swipeUI)
    {
        if (swipeUI.StageLevelText.text == "EASY")
        {
            stageValue = 1;
        }
        else if (swipeUI.StageLevelText.text == "NORMAL")
        {
			stageValue = 2;
		}
		else if (swipeUI.StageLevelText.text == "HARD")
		{
			stageValue = 3;
		}
        if (stageValue <= PlayerPrefs.GetInt(StringKey.LOCKED_STAGE_PREFS)) SceneManager.LoadScene("kjm-GameScene");
    }

    void Start()
    {
        int starRating = PlayerPrefs.GetInt("StarRating", 0);

        if (starRatingText != null)
        {
            starRatingText.text = "Star Rating: " + starRating.ToString();
        }

        if (star1Image != null && star2Image != null && star3Image != null)
        {
            SetStarImage(starRating);
        }
    }

    public void SetStarImage(int starRating)
    {
        Sprite filledStar = Resources.Load<Sprite>("Image/StarImage/filled_star_img");
        Sprite emptyStar = Resources.Load<Sprite>("Image/StarImage/empty_star_img");

        star1Image.sprite = (starRating >= 1) ? filledStar : emptyStar;
        star2Image.sprite = (starRating >= 2) ? filledStar : emptyStar;
        star3Image.sprite = (starRating >= 3) ? filledStar : emptyStar;
    }

    public int GetStage()
    {
        return stageValue;
    }

    public void SetStage(int value)
    {
        SM.stageValue = value;
    }

    public void DeletePlayerInfo()
    {
        PlayerPrefs.DeleteKey("StarRating");
    }
}
