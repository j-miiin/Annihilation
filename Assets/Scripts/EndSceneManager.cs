using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject happyScene; 
    public GameObject badScene;  
    public float delayInSeconds = 28f; 

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

    public void SwitchToNextScene()
    {
        SceneManager.LoadScene(0);
    }
}
