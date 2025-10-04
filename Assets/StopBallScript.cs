using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBallScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Activator")
        {
            Debug.Log("HSDFASDFASDF");
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

}
