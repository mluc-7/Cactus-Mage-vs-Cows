using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip[] musicArray;
    [SerializeField] float musicTime = 30f;

    private void Awake()
    {
        //sanity check for AudioSource
        if (audioSource ==null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void Start()
    {
        //Play(musicOnStart, true);
        PlayMusic();
    }

    void CallAudio()
    {
        Invoke("PlayMusic", musicTime); //plays a new music track every set amount of time set by musicTime
    }

    void PlayMusic()
    {
        audioSource.clip = musicArray[Random.Range(0, musicArray.Length)]; //asssigns a random track within the given musicArray range (elements 0-2, range is 3, random.range is no-inclusive)
        audioSource.Play(); //plays the randomly assigned music clip
        CallAudio(); //starts the invokation to repeart the process in X seconds set by musicTime
    }
}
