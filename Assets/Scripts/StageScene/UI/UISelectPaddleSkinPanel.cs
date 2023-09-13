using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelectPaddleSkinPanel : MonoBehaviour
{
    [SerializeField] private Button _selectPaddleSkinBtn;
    [SerializeField] private GameObject _backgroundPanel;
    [SerializeField] private Button _closeBtn;
    [SerializeField] private Button _defaultPaddleBtn;
    [SerializeField] private Button _cheesePaddleBtn;

    private void Awake()
    {
        SetBtn();
    }

    public void SetBtn()
    {
        // Stage End Panel의 Home, Retry, Next Stage 버튼에 Click Listener를 달아줌
        _selectPaddleSkinBtn.onClick.AddListener(() => { SetBackgroundPanel(true); });
        _closeBtn.onClick.AddListener(() => { SetBackgroundPanel(false); });
        _defaultPaddleBtn.onClick.AddListener(() => { SavePaddleInfo(PaddleType.DEFAULT); });
        _cheesePaddleBtn.onClick.AddListener(() => { SavePaddleInfo(PaddleType.CHEESE); });
    }

    public void SetBackgroundPanel(bool isActive)
    {
        _backgroundPanel.SetActive(isActive);
    }

    public void SavePaddleInfo(PaddleType paddleInfo)
    {
        StageManager.Instance.SavePaddleInfo(paddleInfo);
        SetBackgroundPanel(false);
    }
}
