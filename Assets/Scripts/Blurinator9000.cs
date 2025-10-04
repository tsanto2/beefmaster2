using SCPE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Blurinator9000 : MonoBehaviour
{

    [SerializeField]
    private Volume globalVolume;

    [SerializeField]
    private Blur theBlur;

    [SerializeField]
    private float pitchSustainTimeMin, pitchSustainTimeMax, pitchMin, pitchMax, pitchSwitchSpeedMin, pitchSwitchSpeedMax;

    private void Start()
    {
        globalVolume.profile.TryGet<Blur>(out theBlur);

        //theBlur.amount.SetValue(new ClampedFloatParameter(2f, 0f, 5f));

        StartCoroutine(BlurController());
    }

    IEnumerator BlurController()
    {
        yield return new WaitForSeconds(Random.Range(pitchSustainTimeMin, pitchSustainTimeMax));

        var lerpStart = Time.time;
        var progress = 0f;

        var lerpEndpoint = Random.Range(pitchMin, pitchMax);
        var lerpStartPoint = theBlur.amount.value;

        var lerpDuration = Random.Range(pitchSwitchSpeedMin, pitchSwitchSpeedMax);

        while (lerpDuration > progress)
        {
            progress = Time.time - lerpStart;
            theBlur.amount.SetValue(new ClampedFloatParameter(Mathf.Lerp(lerpStartPoint, lerpEndpoint, progress / lerpDuration), 0f, 5f));

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(BlurController());
    }

}
