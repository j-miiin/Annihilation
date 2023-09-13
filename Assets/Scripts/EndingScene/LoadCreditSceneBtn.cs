using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCreditSceneBtn : MonoBehaviour
{
    public void LoadCreditScene()
    {
        SceneManager.LoadScene("CreditsRollScene");
    }
}
