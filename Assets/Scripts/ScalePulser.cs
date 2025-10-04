using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class ScalePulser : MonoBehaviour
{
    [SerializeField]
    MMScaleShaker scaleShaker;

    [SerializeField]
    private float bpm;

    [SerializeField]
    private float bpmScalar;

    private void Start()
    {
        StartCoroutine(PumpIt());
    }

    IEnumerator PumpIt()
    {
        yield return new WaitForSeconds(60 / bpm);

        scaleShaker.StartShaking();

        StartCoroutine(PumpIt());
    }

}
