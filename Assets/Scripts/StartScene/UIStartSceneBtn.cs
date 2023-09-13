using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIStartSceneBtn : MonoBehaviour
{
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _optionBtn;
    [SerializeField] private Button _closeBtn;
    [SerializeField] private GameObject _optionMenu;

    private void Awake()
    {
        _startBtn.onClick.AddListener(() => { GoStageScene(); });
        _optionBtn.onClick.AddListener(() => { SetOptionMenuActive(true); });
        _closeBtn.onClick.AddListener(() => { SetOptionMenuActive(false); });
    }

    public void GoStageScene()
    {
        SceneManager.LoadScene("StageScene");
    }

    public void SetOptionMenuActive(bool isActive)
    {
        _optionMenu.SetActive(isActive);
    }
}
