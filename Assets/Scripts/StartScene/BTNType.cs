using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BTNType : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public ButtonType currentType;

    public TextMeshProUGUI textMeshProText;
    public float FontSizeMulti = 1.1f;
    private float defaultFontSize;

    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;

    private void Start()
    {
        defaultFontSize = textMeshProText.fontSize;
    }
    public void OnBtnClick()
    {
        switch(currentType)
        {
            case ButtonType.Start:
                Debug.Log("게임시작");
                break;

            case ButtonType.Option:
                CanvasGroupOn(optionGroup);
                CanvasGroupOff(mainGroup);
                break;

            case ButtonType.Exit:
                Application.Quit();
                Debug.Log("앱종료");
                break;

            case ButtonType.Back:
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(optionGroup);
                break;

        }
    }

    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;          
    }
        public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textMeshProText.fontSize = defaultFontSize * FontSizeMulti;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textMeshProText.fontSize = defaultFontSize;
    }
}
