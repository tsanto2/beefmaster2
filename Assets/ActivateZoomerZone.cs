using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateZoomerZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<VerticalityZoomer>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<VerticalityZoomer>().enabled = false;
        }
    }

}
