using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsateLighting : MonoBehaviour
{
    [SerializeField]
    private float minPulseTime, maxPulseTime, minIntensity, maxIntensity, pulseSpeedMin, pulseSpeedMax;

    private Light myLight;

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        StartCoroutine(PulseController());
    }

    IEnumerator PulseController()
    {
        yield return new WaitForSeconds(Random.Range(minPulseTime, maxPulseTime));

        var lerpStart = Time.time;
        var progress = 0f;

        var lerpEndpoint = Random.Range(minIntensity, maxIntensity);

        if (Random.Range(0, 10) > 5)
        {
            lerpEndpoint = 0f;
        }

        var lerpStartPoint = myLight.intensity;

        var lerpDuration = Random.Range(pulseSpeedMin, pulseSpeedMax);

        while (lerpDuration > progress)
        {
            progress = Time.time - lerpStart;
            myLight.intensity = Mathf.Lerp(lerpStartPoint, lerpEndpoint, progress / lerpDuration);

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(PulseController());
    }
}
