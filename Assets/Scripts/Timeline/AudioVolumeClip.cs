using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AudioVolumeClip : PlayableAsset
{
    public float volumeLevel;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<AudioVolumeChange>.Create(graph);

        AudioVolumeChange audioVolumeChange = playable.GetBehaviour();
        audioVolumeChange.volumeLevel = volumeLevel;

        return playable;
    }

}
