using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnveilGreatly : MonoBehaviour
{

    [SerializeField]
    private bool shouldUnveil, shouldStartTransparent, waitForButtonPress;

    [SerializeField]
    private float veilDuration, delayBeforeVeilChange;

    [SerializeField]
    private MeshRenderer mr;

    private float lerpStart;

    private void Start()
    {
        if (shouldStartTransparent)
        {
            var tempColor = mr.material.color;
            tempColor.a = 0f;
            mr.material.color = tempColor;
        }

        if (!waitForButtonPress)
        {
            StartCoroutine(ChangeVeiledness());
        }
    }

    public void PublicChangeVeiledNess()
    {
        StartCoroutine(ChangeVeiledness());
    }

    IEnumerator ChangeVeiledness()
    {
        yield return new WaitForSeconds(delayBeforeVeilChange);

        lerpStart = Time.time;
        var progress = 0f;
        var tempColor = mr.material.color;

        var lerpEndpoint = 0f;
        var lerpStartPoint = 1f;
        if (!shouldUnveil)
        {
            lerpEndpoint = 1f;
            lerpStartPoint = 0f;
        }

        while (veilDuration > progress)
        {
            progress = Time.time - lerpStart;
            tempColor.a = Mathf.Lerp(lerpStartPoint, lerpEndpoint, progress/veilDuration);
            mr.material.color = tempColor;

            yield return new WaitForEndOfFrame();
        }

    }

}
