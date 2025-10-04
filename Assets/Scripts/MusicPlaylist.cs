using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlaylist : MonoBehaviour
{

    [SerializeField]
    private AudioSource musicPlayer;

    [SerializeField]
    private AudioClip[] playlist;

    [SerializeField]
    private int index = 0;

    private void Start()
    {
        musicPlayer.clip = playlist[index];
        musicPlayer.Play();
    }

    private void Update()
    {
        if (!musicPlayer.isPlaying)
        {
            index++;
            musicPlayer.clip = playlist[index];
            musicPlayer.Play();
        }
    }

}
