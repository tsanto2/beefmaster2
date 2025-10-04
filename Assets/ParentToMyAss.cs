using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToMyAss : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.gameObject.transform.parent = gameObject.transform;
            GetComponent<SplineFollower>().followSpeed = 8f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.gameObject.transform.parent = null;
        }
    }

}
