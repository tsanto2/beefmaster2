using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource footstepAudioSource;

    [SerializeField]
    private List<AudioClip> footstepAudioClips;

    [SerializeField]
    private float footstepDelayTime;

    [SerializeField]
    private float footstepDelayRandomizedBufferTime;

    [SerializeField]
    private float minVolume, maxVolume;

    private bool isPlayingFootstepAudio, canPlayFootstep;

    private AudioClip lastClipPlayed;

    private void Start()
    {
        canPlayFootstep = true;
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.anyKey && canPlayFootstep)
        {
            canPlayFootstep = false;
            StartCoroutine(PlayFootstepAudio());
        }
    }

    AudioClip GetAudioClip()
    {
        int random = Random.Range(0, footstepAudioClips.Count);

        while (footstepAudioClips[random] == lastClipPlayed)
        {
            random = Random.Range(0, footstepAudioClips.Count);
        }

        return footstepAudioClips[random];
    }

    IEnumerator PlayFootstepAudio()
    {
        var footstepClip = GetAudioClip();

        lastClipPlayed = footstepClip;
        footstepAudioSource.clip = footstepClip;
        footstepAudioSource.volume = Random.Range(minVolume, maxVolume);
        footstepAudioSource.pitch = Random.Range(0.9f, 1.1f);
        footstepAudioSource.Play();

        float randomWaitTime = Random.Range(0f, footstepDelayRandomizedBufferTime);

        yield return new WaitForSeconds(footstepDelayTime + randomWaitTime);

        canPlayFootstep = true;
    }

}
