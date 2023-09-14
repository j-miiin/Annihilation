using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource backgroundMusicSource; // 배경음악을 재생할 AudioSource
    public AudioSource buttonClickSource; // 버튼 클릭음을 재생할 AudioSource
    public List<AudioSource> gameSoundSources; // 게임 효과음을 재생할 AudioSource 목록

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 새로 생성된 객체를 파괴합니다.
        }
    }

    public void PlayBackgroundMusic(AudioClip music)
    {
        backgroundMusicSource.clip = music;
        backgroundMusicSource.Play();
    }

    public void PlayButtonClickSound(AudioClip sound)
    {
        buttonClickSource.PlayOneShot(sound);
    }

    public void PlayGameSound(AudioClip sound)
    {
        // 사용 가능한 AudioSource를 찾아 효과음을 재생합니다.
        foreach (var source in gameSoundSources)
        {
            if (!source.isPlaying)
            {
                source.clip = sound;
                source.Play();
                return;
            }
        }
        // 사용 가능한 AudioSource가 없다면 새로운 AudioSource를 생성하여 효과음을 재생합니다.
        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        newSource.clip = sound;
        newSource.Play();
        gameSoundSources.Add(newSource);
    }

    // 필요에 따라 다른 기능을 추가할 수 있습니다.
}
