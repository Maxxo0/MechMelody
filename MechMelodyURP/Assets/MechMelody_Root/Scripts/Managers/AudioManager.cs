using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance
    { get { return instance; } }

    [Header("AudioSource References")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Clip Configuration")]
    public AudioClip[] musicArray;
    public AudioClip[] sfxArray;

    public int pop;
    public int jazz;
    public int rock;
    public int classic;

    AudioClip popMusic;
    AudioClip jazzMusic;
    AudioClip rockMusic;
    AudioClip classicMusic;

    private void Start()
    {
        pop = Random.Range(0, 3);
        jazz = Random.Range(3, 6);
        rock = Random.Range(6, 9);
        classic = Random.Range(9, 12);
        PlayMusic(pop);
    }

    private void Awake()
    {
        instance = this;
    }
    
    public void PlayMusic(int musicToPlay)
    {
        musicSource.clip = musicArray[musicToPlay];
        musicSource.Play();
    }

    public void ChangeMusic(int musicToPlay)
    {
        musicSource.clip = musicArray[musicToPlay];
    }

    public void PlaySFX(int soundToPlay)
    {
        sfxSource.PlayOneShot(sfxArray[soundToPlay]);
    }
}
