using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    private int stageValue = 1;

    public static StageManager SM;

	[Header("�� ���̵� �ð�")]
	[SerializeField] float fadeValue = 1f;
	[SerializeField] float fadeTime = 1f;

	
    //StageManager�� GameManager�� ������
	private void Awake()
    {
        SM = this;
        DontDestroyOnLoad(this);
    }

    //�������� �̹����� ������ �� �������� ���� �ؽ�Ʈ�� ���� �������� ������ �ο� �� GameScene �ε�
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
