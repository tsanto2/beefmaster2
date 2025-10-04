using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunter : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] grunts;

    private AudioSource gruntSource;

    [SerializeField]
    private float gruntTimeMin, gruntTimeMax;

    private void Start()
    {
        gruntSource = GetComponent<AudioSource>();

        StartCoroutine(Grunt());
    }

    IEnumerator Grunt()
    {
        yield return new WaitForSeconds(Random.Range(gruntTimeMin, gruntTimeMax));

        gruntSource.clip = grunts[Random.Range(0, grunts.Length)];
        gruntSource.Play();

        StartCoroutine(Grunt());
    }

}
