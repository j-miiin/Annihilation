using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIStartSceneCanvas : MonoBehaviour
{
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _optionBtn;
    [SerializeField] private Button _closeBtn;
    [SerializeField] private GameObject _optionMenu;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Image _soundIcon;

    private void Awake()
    {
        _startBtn.onClick.AddListener(() => { GoStageScene(); });
        _optionBtn.onClick.AddListener(() => { SetOptionMenuActive(true); });
        _closeBtn.onClick.AddListener(() => { SetOptionMenuActive(false); });
    }

    private void Update()
    {
        if (_soundSlider.value == 0) _soundIcon.color = Color.black;
        else _soundIcon.color = Color.white;
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
