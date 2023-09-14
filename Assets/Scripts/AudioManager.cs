using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource backgroundMusicSource; // ��������� ����� AudioSource
    public AudioSource buttonClickSource; // ��ư Ŭ������ ����� AudioSource
    public List<AudioSource> gameSoundSources; // ���� ȿ������ ����� AudioSource ���

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� �����ϸ� ���� ������ ��ü�� �ı��մϴ�.
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
        // ��� ������ AudioSource�� ã�� ȿ������ ����մϴ�.
        foreach (var source in gameSoundSources)
        {
            if (!source.isPlaying)
            {
                source.clip = sound;
                source.Play();
                return;
            }
        }
        // ��� ������ AudioSource�� ���ٸ� ���ο� AudioSource�� �����Ͽ� ȿ������ ����մϴ�.
        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        newSource.clip = sound;
        newSource.Play();
        gameSoundSources.Add(newSource);
    }

    // �ʿ信 ���� �ٸ� ����� �߰��� �� �ֽ��ϴ�.
}
