using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameSetBTNType : MonoBehaviour
{
    public GameSetButtonType setcurrentType;

    public CanvasGroup GameGroup;
    public CanvasGroup SettingGroup;

    public void OnBtnClick()
    {
        switch (setcurrentType)
        {
            case GameSetButtonType.Main:
                SceneManager.LoadScene("StageScene");
                break;

            case GameSetButtonType.Retry:
                Debug.Log("¿ÁΩ√¿€");
                //SceneManager.LoadScene("GameScene");
                //GameMnager.I.retry();
                break;

            case GameSetButtonType.Setting:
                SettingGroupOn(SettingGroup);
                SettingGroupOff(GameGroup);
                Time.timeScale = 0f;
                break;

            case GameSetButtonType.Back:
                SettingGroupOn(GameGroup);
                SettingGroupOff(SettingGroup);
                Time.timeScale = 1f;
                break;

        }
    }

    public void SettingGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void SettingGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

}
