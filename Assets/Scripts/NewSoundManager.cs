using UnityEngine;

public class NewSoundManager : MonoBehaviour
{
    public static NewSoundManager instance;

    public AudioClip playerBallCollisionSound;
    public AudioClip ballMeteorCollisionSound;
    public AudioClip playerItemPickupSound;
    public AudioClip playerMeteorCollisionSound;
	public AudioClip failStageSound;
	public AudioClip clearStageSound;
	public AudioClip shootingSound;

	private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPlayerBallCollisionSound()
    {
        audioSource.PlayOneShot(playerBallCollisionSound);
    }

    public void PlayBallMeteorCollisionSound()
    {
        audioSource.PlayOneShot(ballMeteorCollisionSound);
    }

    public void PlayPlayerItemPickupSound()
    {
        audioSource.PlayOneShot(playerItemPickupSound);
    }

    public void PlayPlayerMeteorCollisionSound()
    {
        audioSource.PlayOneShot(playerMeteorCollisionSound);
    }

    

	public void PlayFailStageSound()
	{
		audioSource.PlayOneShot(failStageSound);
	}
	public void PlayClearStageSound()
	{
		audioSource.PlayOneShot(clearStageSound);
	}
	public void PlayShootingSound()
	{
		audioSource.PlayOneShot(shootingSound);
	}

}
