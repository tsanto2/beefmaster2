using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowLightDeterctor9000 : MonoBehaviour
{
    [SerializeField]
    private GameObject cow;

    [SerializeField]
    private float minWait, maxWait;

    bool inLight = false;

    void Start()
    {
        StartCoroutine(CheckForLight());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LightCollider")
        {
            inLight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "LightCollider")
        {
            inLight = false;
        }
    }

    IEnumerator CheckForLight()
    {
        yield return new WaitForSeconds(Random.Range(minWait, maxWait));

        if (!inLight)
        {
            cow.SetActive(!cow.active);
        }


        StartCoroutine(CheckForLight());
    }
}
