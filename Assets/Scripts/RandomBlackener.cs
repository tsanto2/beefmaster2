using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBlackener : MonoBehaviour
{
    [SerializeField]
    private float pitchSustainTimeMin, pitchSustainTimeMax, pitchMin, pitchMax, pitchSwitchSpeedMin, pitchSwitchSpeedMax;

    [SerializeField]
    private float waitUntilTime;

    [SerializeField]
    private MeshRenderer mr;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForTime());
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(waitUntilTime);

        StartCoroutine(PitchController());
    }

    IEnumerator PitchController()
    {
        yield return new WaitForSeconds(Random.Range(pitchSustainTimeMin, pitchSustainTimeMax));

        var lerpStart = Time.time;
        var progress = 0f;
        var tempColor = mr.material.color;

        var lerpEndpoint = Random.Range(0, 1);
        var lerpStartPoint = tempColor.a;

        var lerpDuration = Random.Range(pitchSwitchSpeedMin, pitchSwitchSpeedMax);

        while (lerpDuration > progress)
        {
            progress = Time.time - lerpStart;
            tempColor.a = Mathf.Lerp(lerpStartPoint, lerpEndpoint, progress / lerpDuration);
            mr.material.color = tempColor;

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(PitchController());
    }
}
