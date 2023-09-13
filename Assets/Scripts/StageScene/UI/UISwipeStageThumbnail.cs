using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISwipeStageThumbnail : MonoBehaviour
{
    [SerializeField] private GameObject _star1EmptyImage;
    [SerializeField] private GameObject _star2EmptyImage;
    [SerializeField] private GameObject _star3EmptyImage;
    [SerializeField] private GameObject _star1FilledImage;
    [SerializeField] private GameObject _star2FilledImage;
    [SerializeField] private GameObject _star3FilledImage;
    [SerializeField] private TMP_Text _stageLevelText;

    public static UISwipeStageThumbnail Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SetStageStarImage(int star)
    {
        _star1FilledImage.SetActive((star >= 1));
        _star2FilledImage.SetActive((star >= 2));
        _star3FilledImage.SetActive((star >= 3));
    }

    public void SetStageLevelText(string stageLevelStr, bool isLocked)
    {
        _stageLevelText.text = stageLevelStr; //stageText[i];
        _stageLevelText.color = (isLocked) ? Color.white : Color.grey;
    }
}
