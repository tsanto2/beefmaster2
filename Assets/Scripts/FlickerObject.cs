using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerObject : MonoBehaviour
{

    [SerializeField]
    private float remainOnTime, remainOffTime;

    [SerializeField]
    private GameObject flickerObj;

    private void Start()
    {
        StartCoroutine(Flicker(false));
    }

    IEnumerator Flicker(bool turnOn)
    {
        var waitTime = remainOnTime;

        if (turnOn)
        {
            waitTime = remainOffTime;
        }

        yield return new WaitForSeconds(waitTime);

        flickerObj.SetActive(turnOn);

        StartCoroutine(Flicker(!turnOn));
    }

}
