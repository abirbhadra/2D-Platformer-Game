using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

   
    public AudioSource audioEffect;
    public AudioSource audioMusic;

    public AudioType[] Audios;

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
    }

    private void Start()
    {
        PlayMusic(global::Audios.Music); //Audios != array, Audios = enum
    }
    public void PlayMusic(Audios audio)
    {
        AudioClip clip = getAudioClip(audio);
        if (clip != null)
        {
            audioMusic.clip = clip;
            audioMusic.Play();
        }
        else
        {
            Debug.LogError("Clip not found for sound type: " + audio);
        }
    }

    public void Play(Audios audio)
    {
        AudioClip clip = getAudioClip(audio);
        if (clip != null)
        {
            audioEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found for sound type: "+audio);
        }
        
    }

    public AudioClip getAudioClip(Audios audio)
    {
         
        AudioType item = Array.Find(Audios, i => i.audioType == audio);
        if (item != null)
            return item.audioClip;
        return null;
    }
}

[Serializable]
public class AudioType
{
    public Audios audioType;
    public AudioClip audioClip;
}

public enum Audios
{
    Music,
    ButtonClick,
    PlayerMove,
    PlayerDeath,
}
