using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    private int stage = 1;

    public static StageSelectManager SSM;

	[Header("씬 페이드 시간")]
	[SerializeField] float fadeValue = 1f;
	[SerializeField] float fadeTime = 1f;

	

	private void Awake()
    {
        SSM = this;
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getStage()
    {
        return stage;
    }

    public void SetStage(int value)
    {
        SSM.stage = value;
    }
}
