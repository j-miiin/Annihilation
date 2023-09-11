using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    // � ���� grid ������
    private string _meteorPrefabName;
    // ��� �̹���
    private string _backgroundImage;

    private bool _isOver;   // �������� ���� ���� �޼� �� GameManager�� true�� �ٲ��ִ� ��

    void Start()
    {
        InitStage();
    }

    void Update()
    {
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
    }

    //��� � �ı� ���� Ȯ��
    private bool AllMeteorsDestroyed()
    {
        GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
        return meteors.Length == 0;
    }

    // isClear == true �̸� �������� Ŭ����, false �̸� ����
    private void GameOver(bool isClear)
    {
        Time.timeScale = 0f;

        if (isClear)
        {
            PlayerPrefs.SetInt(StringKey.LOCKED_STAGE_PREFS, PlayerPrefs.GetInt(StringKey.LOCKED_STAGE_PREFS) + 1);
        }

        StageUIManager.S.SetStageEndPanel(isClear, GameManager.I.starRating);
    }

    // GameManager���� ȣ���Ͽ� Stage ���� ����
    public void SetStageInfo(string meteorPrefabName, string backgroundImage)
    {
        _meteorPrefabName = meteorPrefabName;
        _backgroundImage = backgroundImage;
    }

    // GameManager���� �������� ���� ���� �޼� �� ȣ��
    public void StageFail()
    {
        _isOver = true;
    }
}
