using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomAcrossScreen : MonoBehaviour
{

    [SerializeField]
    private AudioSource vroomAudio;

    [SerializeField]
    private float initialWaitTime, minWaitBetweenZoomsTime, maxWaitBetweenZoomsTime, minZoomSpeed, maxZoomSpeed;

    [SerializeField]
    private Vector3 leftDestination, rightDestination;

    private bool hasInitiallyWaited;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Zoom(true));
    }

    IEnumerator Zoom(bool zoomRight)
    {
        if (!hasInitiallyWaited)
        {
            hasInitiallyWaited = true;
            yield return new WaitForSeconds(initialWaitTime);
        }

        Vector3 dest = rightDestination;
        /*if (!zoomRight)
        {
            dest = leftDestination;
        }*/

        var zoomSpeed = Random.Range(minZoomSpeed, maxZoomSpeed);

        yield return new WaitForSeconds(Random.Range(minWaitBetweenZoomsTime, maxWaitBetweenZoomsTime));

        vroomAudio.Play();

        while (transform.position != dest)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest, Time.deltaTime * zoomSpeed);
            yield return new WaitForEndOfFrame();
        }

        transform.position = leftDestination;

        StartCoroutine(Zoom(!zoomRight));
    }
}
