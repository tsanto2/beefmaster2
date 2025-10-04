using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVBlaster : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vCam;

    [SerializeField]
    private float pitchSustainTimeMin, pitchSustainTimeMax, pitchMin, pitchMax, pitchSwitchSpeedMin, pitchSwitchSpeedMax;

    private void Start()
    {
        StartCoroutine(BlurController());
    }

    IEnumerator BlurController()
    {
        yield return new WaitForSeconds(Random.Range(pitchSustainTimeMin, pitchSustainTimeMax));

        var lerpStart = Time.time;
        var progress = 0f;

        var lerpEndpoint = Random.Range(pitchMin, pitchMax);
        var lerpStartPoint = vCam.m_Lens.FieldOfView;

        var lerpDuration = Random.Range(pitchSwitchSpeedMin, pitchSwitchSpeedMax);

        while (lerpDuration > progress)
        {
            progress = Time.time - lerpStart;
            vCam.m_Lens.FieldOfView = Mathf.Lerp(lerpStartPoint, lerpEndpoint, progress / lerpDuration);

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(BlurController());
    }
}
