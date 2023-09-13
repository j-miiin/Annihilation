using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIStartBtnAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private const float HOVER_FONT_SIZE = 1.1f;

    private TMP_Text _startBtnText;
    private float _defaultFontSize;

    private void Awake()
    {
        _startBtnText = gameObject.GetComponent<TMP_Text>();
        _defaultFontSize = _startBtnText.fontSize;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _startBtnText.fontSize *= HOVER_FONT_SIZE;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _startBtnText.fontSize = _defaultFontSize;
    }
}
