using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPauseCanvas : MonoBehaviour
{
    [SerializeField] private Button _pauseBtn;
    [SerializeField] private Button _closeBtn;
    [SerializeField] private Button _homeBtn;
    [SerializeField] private Button _retryBtn;
    [SerializeField] private GameObject _pauseMenu;
    private bool isPaused = false;

    private void Awake()
    {
        _pauseBtn.onClick.AddListener(() => { PauseGame(true); });
        _closeBtn.onClick.AddListener(() => { PauseGame(false); });
        _homeBtn.onClick.AddListener(() => { GameManager.Instance.GoHome(); });
        _retryBtn.onClick.AddListener(() => { GameManager.Instance.RetryGame(); });
    }

    private void PauseGame(bool isActive)
    {
        if(isActive)
        {
            Time.timeScale = 0f;
            _pauseMenu.SetActive(isActive);
            _pauseBtn.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            _pauseMenu.SetActive(isActive);
            _pauseBtn.gameObject.SetActive(true);
        }
    }
}
