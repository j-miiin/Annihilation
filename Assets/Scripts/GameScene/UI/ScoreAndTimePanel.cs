using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreAndTimePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _timeText;

    public void SetScoreText(int score)
    {
        _scoreText.text = $"SCORE {score}";
    }

    public void SetTimeText(string time)
    {
        _timeText.text = time;
    }
}
