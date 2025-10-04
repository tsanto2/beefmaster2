using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/JukeboxSongDataSO", order = 1)]
public class JukeboxSongInfoSO : ScriptableObject
{
    public string songName;
    public string artistName;
    public string albumName;
    public Texture2D albumImage;
    public AudioClip songAudio;
}
