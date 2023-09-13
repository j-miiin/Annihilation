using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public static BtnManager BS;

	public static BtnManager Instance;

	private AudioSource audioSource;

	public AudioClip clickBtnSound;

	private void Awake()
	{
        BS = this;
        DontDestroyOnLoad(this);
	}

	public void PlayClickBtnSound()
	{
		audioSource.PlayOneShot(clickBtnSound);
	}




	// Start is called before the first frame update
	void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
