using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    private GameObject _canvas;
    private GameObject _gameOverText;
    private GameObject _meteorController;

    private string _meteorPrefabName;
    private string _backgroundImage;

    private bool _isOver;   // �������� ���� ���� �޼� �� GameManager�� true�� �ٲ��ִ� ��

    const string CANVAS = "Canvas";
    const string METEOR_CONTROLLER = "MeteorController";
    const string GAMEOVER_TEXT = "GameOverText";

    const string STAGE_CLEAR = "Stage Clear";
    const string STAGE_FAIL = "Stage Fail";

    void Start()
    {
        InitStage();
        StartGame();
    }

    void Update()
    {
        // TODO MeteorController �ϼ� �� �ּ� Ǯ��
        //if (_meteorController.transform.childCount == 0)
        //{
        //    GameOver(true);
        //}
        if (_isOver)
        {
            GameOver(false);
        }
    }

    private void InitStage()
    {
        Time.timeScale = 1f;
        _isOver = false;

        // � grid ����
        Instantiate(Resources.Load<GameObject>("Prefabs/Stages/"+_meteorPrefabName));

        // TODO ��׶��� �̹��� ��ġ, �̸� ���� �� �̹��� �ҷ����� �ڵ� �ٽ� ����
        _canvas = GameObject.Find(CANVAS);
        //Image backgroundImage = _canvas.transform.Find("BackgroundImage").GetComponent<Image>();
        //backgroundImage.sprite = Resources.Load<Sprite>("easystage_bg");
        _gameOverText = _canvas.transform.Find(GAMEOVER_TEXT).gameObject;

        // TODO MeteorController �ϼ� �� �ּ� Ǯ��
        //_meteorController = GameObject.Find(METEOR_CONTROLLER);
    }

    private void StartGame()
    {
        // ���콺 Ŭ�� �� �� �����̱� ����
    }

    // isClear == true �̸� �������� Ŭ����, false �̸� ����
    private void GameOver(bool isClear)
    {
        Time.timeScale = 0f;

        if (isClear)
        {
            _gameOverText.GetComponent<TMP_Text>().text = STAGE_CLEAR;
        } else
        {
            _gameOverText.GetComponent<TMP_Text>().text = STAGE_FAIL;
        }

        _gameOverText.SetActive(true);
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
