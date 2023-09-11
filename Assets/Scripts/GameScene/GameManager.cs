using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [SerializeField] private Stage _stage;
    private int _curStage;
    private bool _isOver;

    public int finalScore = 0;
    public int score = 0;
    public TMP_Text scoreText;

    public int starRating = 0;

    private float _runningTime = 0f;
    public TMP_Text timeText;

    private void Awake()
    {
        I = this;
    }

    void Start()
    {
        // StageManager���� stage ���� �������� �κ�
        //_curStage = StageManager.SM.GetStage();
        _curStage = 1;
        if (_curStage == 1)
        {
            // TODO SetStageInfo ���� �� ����
            _stage.SetStageInfo("NewEasyStageGrid", "");
        }
        else if (_curStage == 2)
        {
            _stage.SetStageInfo("NewNormalStageGrid", "");
        }
        else if (_curStage == 3)
        {
            _stage.SetStageInfo("NewHardStageGrid", "");
        }
       
        _isOver = false;

        starRating = PlayerPrefs.GetInt(StringKey.STAR_RATING_PREFS, 0);
    }

    void Update()
    {
        if (_isOver)
        {
            _stage.StageFail();
        }

        _runningTime += Time.deltaTime;
        timeText.text = _runningTime.ToString("N2");

        finalScore = score + Mathf.FloorToInt(1000 / _runningTime);

        CalculateStarRating();
    }

    public void GameOver()
    {
        _isOver = true;
    }

    public void GoHome()
    {
        SceneManager.LoadScene("StageScene");
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoNextStage()
    {

    public void UpdateScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "Score: " + score;
    }

    private void CalculateStarRating()
    {
        if (finalScore > 300)
        {
            starRating = 3;
        }
        else if (finalScore > 200)
        {
            starRating = 2;
        }
        else if (finalScore > 100)
        {
            starRating = 1;
        }
        else
        {
            starRating = 0;
        }

        PlayerPrefs.SetInt(StringKey.STAR_RATING_PREFS, starRating);
        PlayerPrefs.Save();
    }
}
