using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchShifter : MonoBehaviour
{
    [SerializeField]
    private float pitchSustainTimeMin, pitchSustainTimeMax, pitchMin, pitchMax, pitchSwitchSpeedMin, pitchSwitchSpeedMax;

    private AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        StartCoroutine(PitchController());
    }

    IEnumerator PitchController()
    {
        yield return new WaitForSeconds(Random.Range(pitchSustainTimeMin, pitchSustainTimeMax));

        var lerpStart = Time.time;
        var progress = 0f;

        var lerpEndpoint = Random.Range(pitchMin, pitchMax);
        var lerpStartPoint = audioSrc.pitch;

        var lerpDuration = Random.Range(pitchSwitchSpeedMin, pitchSwitchSpeedMax);

        while (lerpDuration > progress)
        {
            progress = Time.time - lerpStart;
            audioSrc.pitch = Mathf.Lerp(lerpStartPoint, lerpEndpoint, progress / lerpDuration);

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(PitchController());
    }

}
