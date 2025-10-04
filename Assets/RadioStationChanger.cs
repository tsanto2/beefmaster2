using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioStationChanger : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] songs;

    [SerializeField]
    private AudioSource source;

    int index = 0;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            index++;
            if (index >= songs.Length)
            {
                index = 0;
            }

            source.clip = songs[index];
            source.Play();
        }

        /*if (!source.isPlaying)
        {
            index++;
            if (index >= songs.Length)
            {
                index = 0;
            }

            source.clip = songs[index];
        }*/
    }


}
