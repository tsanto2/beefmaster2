using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerleportPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform receiver;

    private FirstPersonController fpc;

    private bool needReenableFPC;

    private void Update()
    {
        if (needReenableFPC)
        {
            needReenableFPC = false;
            fpc.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fpc = other.gameObject.GetComponent<FirstPersonController>();
            fpc.enabled = false;

            other.gameObject.transform.position = receiver.transform.position;
            other.gameObject.transform.rotation = receiver.transform.rotation;

            StartCoroutine(WaitToEnableFPC());
        }
    }

    IEnumerator WaitToEnableFPC()
    {
        yield return new WaitForSeconds(0.1f);

        needReenableFPC = true;
    }

}
