using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitleMachine : MonoBehaviour
{

    [SerializeField]
    private float[] displayWaitTimes, displayTimes;

    [SerializeField]
    private string[] subtitles;

    private int index = 0;

    [SerializeField]
    private TextMeshProUGUI singleCharSubtitle;

    private void Start()
    {
        StartCoroutine(DisplaySubtitles());
    }

    IEnumerator DisplaySubtitles()
    {
        yield return new WaitForSeconds(displayWaitTimes[index]);

        singleCharSubtitle.text = subtitles[index];

        yield return new WaitForSeconds(displayTimes[index]);

        singleCharSubtitle.text = "";

        StartCoroutine(DisplaySubtitles());
    }

}
