using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AudioVolumeChange : PlayableBehaviour
{
    public float volumeLevel;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        AudioSource audioSource = playerData as AudioSource;
        audioSource.volume = info.weight;
    }

}
