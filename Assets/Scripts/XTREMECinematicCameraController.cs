using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class XTREMECinematicCameraController : MonoBehaviour
{

    [SerializeField]
    private List<CinemachineVirtualCamera> cams;

    [SerializeField]
    private List<float> camTimes;

    [SerializeField]
    private List<bool> hasSubtitle;

    [SerializeField]
    private float[] displayWaitTimes, displayTimes;

    [SerializeField]
    private string[] subtitles;

    private int subtitleIndex = 0;

    [SerializeField]
    private TextMeshProUGUI singleCharSubtitle;

    private int sequence = 1;

    private void Start()
    {
        foreach (CinemachineVirtualCamera cam in cams)
        {
            cam.Priority = 0;
        }

        cams[0].Priority = 10;

        StartCoroutine(XTREMECinematicSequence());
    }

    IEnumerator XTREMECinematicSequence()
    {
        yield return new WaitForSeconds(camTimes[sequence]);

        if (hasSubtitle[sequence])
        {
            StartCoroutine(ShowSubs());
        }

        cams[sequence - 1].Priority = 0;

        cams[sequence].Priority = 10;

        sequence++;

        StartCoroutine(XTREMECinematicSequence());
    }

    IEnumerator ShowSubs()
    {
        yield return new WaitForSeconds(displayWaitTimes[subtitleIndex]);

        singleCharSubtitle.text = subtitles[subtitleIndex];

        yield return new WaitForSeconds(displayTimes[subtitleIndex]);

        subtitleIndex++;

        singleCharSubtitle.text = "";
    }

}
