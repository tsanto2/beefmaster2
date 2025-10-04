using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitToPlayMusic : MonoBehaviour
{
    [SerializeField]
    private float waitTime;

    private void Start()
    {
        StartCoroutine(WaitToPlay());
    }

    IEnumerator WaitToPlay()
    {
        yield return new WaitForSeconds(waitTime);

        GetComponent<AudioSource>().Play();
    }

}
