using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTurnOnner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] turnOns;

    [SerializeField]
    private AudioSource turnOnAudio;

    [SerializeField]
    private float turnOnWaitTime;

    private void Start()
    {
        StartCoroutine(WaitToTurnOn());
    }

    IEnumerator WaitToTurnOn()
    {
        yield return new WaitForSeconds(turnOnWaitTime);

        turnOnAudio.Play();

        foreach (GameObject obj in turnOns)
        {
            obj.SetActive(true);
        }
    }

}
