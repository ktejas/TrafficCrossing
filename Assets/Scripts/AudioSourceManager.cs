using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
    public AudioClip[] audioClip;

    private AudioSource gameManagerAudioSource;

    private void Start()
    {
        gameManagerAudioSource = GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        gameManagerAudioSource.PlayOneShot(audioClip[0]);
    }

    public void PlayAudioClip(string i_audioClipName)
    {
        for (int i = 0; i < audioClip.Length; i++)
        {
            if (audioClip[i].name == i_audioClipName)
            {
                gameManagerAudioSource.PlayOneShot(audioClip[i]);
            }
        }
    }
}