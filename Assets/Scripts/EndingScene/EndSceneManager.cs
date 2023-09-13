using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject happyScene; 
    public GameObject badScene;  
    public float delayInSeconds = 28f;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        Invoke("SwitchObjects", delayInSeconds);
    }

    private void SwitchObjects()
    {
        if (happyScene != null)
        {
            happyScene.SetActive(false);
        }

        if (badScene != null)
        {
            badScene.SetActive(true);
        }
    }

    private void SwitchToNextScene()
    {
        SceneManager.LoadScene("CreditsRollScene");
    }
}
