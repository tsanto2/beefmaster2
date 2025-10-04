using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CawCaw : MonoBehaviour
{
    [SerializeField]
    AudioSource[] audioSources;

    [SerializeField]
    private AudioClip[] audioClips;

    void Start()
    {
        
    }


    void Update()
    {
        foreach(AudioSource source in audioSources)
        {
            if (!source.isPlaying)
            {
                source.clip = audioClips[Random.Range(0, audioClips.Length)];
                source.Play();
            }
        }
    }
}
