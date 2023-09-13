using UnityEngine;

public class NewSoundManager : MonoBehaviour
{
    public static NewSoundManager instance;

    public AudioClip playerBallCollisionSound;
    public AudioClip ballMeteorCollisionSound;
    public AudioClip playerItemPickupSound;
    public AudioClip playerMeteorCollisionSound;

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
}
