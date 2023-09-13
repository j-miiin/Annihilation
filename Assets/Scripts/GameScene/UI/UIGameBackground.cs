using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameBackground : MonoBehaviour
{
    private GameObject backgroundImages;

    private void Awake()
    {
        SetBackgroundActive();
    }

    public void SetBackgroundActive()
    {
        int randomIdx = Random.Range(0, transform.childCount);
        backgroundImages = transform.GetChild(randomIdx).gameObject;
        backgroundImages.SetActive(true);
    }
}
