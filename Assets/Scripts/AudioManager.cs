using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("AudioManager").AddComponent<AudioManager>();
            }
            return instance;
        }
    }

    public AudioClip mainMenuMusic;
    public AudioClip levelMusic;
    public AudioClip buttonPressSound;
    public AudioClip tileChangeSound;

    private AudioSource musicSource;
    private AudioSource sfxSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
        PlayMainMenuMusic();
    }

    public void PlayMainMenuMusic()
    {
        musicSource.clip = mainMenuMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayLevelMusic()
    {
       musicSource.clip = levelMusic;
       musicSource.loop = true;
       musicSource.Play();
    }

    public void PlayButtonPressSound()
    {
        sfxSource.PlayOneShot(buttonPressSound);
    }

    public void PlayTileChangeSound()
    {
        sfxSource.PlayOneShot(tileChangeSound);
    }
}
