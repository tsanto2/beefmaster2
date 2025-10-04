using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JukeboxController9000 : MonoBehaviour
{
    [SerializeField]
    private List<JukeboxSongInfoSO> songInfos;

    [SerializeField]
    private TextMeshProUGUI trackTitle, artistName, albumName;

    [SerializeField]
    private RawImage albumImage;

    private int songIndex = 0;

    private AudioSource musicPlayer;

    private void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
    }

    public void PlayNextSong()
    {
        songIndex++;
        JukeboxSongInfoSO songInfo = songInfos[songIndex];

        musicPlayer.clip = songInfo.songAudio;
        trackTitle.text = songInfo.songName;
        artistName.text = songInfo.artistName;
        albumName.text = songInfo.albumName;
        albumImage.texture = songInfo.albumImage;
    }

    public void PlayPrevSong()
    {
        songIndex--;
        JukeboxSongInfoSO songInfo = songInfos[songIndex];

        musicPlayer.clip = songInfo.songAudio;
        trackTitle.text = songInfo.songName;
        artistName.text = songInfo.artistName;
        albumName.text = songInfo.albumName;
        albumImage.texture = songInfo.albumImage;
    }

}
