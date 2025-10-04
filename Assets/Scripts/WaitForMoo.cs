using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForMoo : MonoBehaviour
{

    [SerializeField]
    private float waitTime;

    [SerializeField]
    private AudioSource mooAudio;

    private void Start()
    {
        StartCoroutine(Wait2Moo());
    }

    IEnumerator Wait2Moo()
    {
        yield return new WaitForSeconds(waitTime);

        mooAudio.Play();
    }


}
