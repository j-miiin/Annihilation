using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    private int stageValue = 1;

    public static StageManager SM;

	[Header("씬 페이드 시간")]
	[SerializeField] float fadeValue = 1f;
	[SerializeField] float fadeTime = 1f;

	
    //StageManager를 GameManager로 가져감
	private void Awake()
    {
        SM = this;
        DontDestroyOnLoad(this);
    }

    //스테이지 이미지를 눌렀을 때 스테이지 레벨 텍스트에 따라 스테이지 벨류값 부여 후 GameScene 로드
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
        if (stageValue <= PlayerPrefs.GetInt(StringKey.LOCKED_STAGE_PREFS)) SceneManager.LoadScene("GameScene");
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public int GetStage()
    {
        return stageValue;
    }

    public void SetStage(int value)
    {
        SM.stageValue = value;
    }
}
