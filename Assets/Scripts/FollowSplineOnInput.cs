using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSplineOnInput : MonoBehaviour
{

    [SerializeField]
    private SplineFollower splineFollower;

    [SerializeField]
    private float followSpeed;

    private void Update()
    {
        if (Input.anyKey || Input.GetMouseButton(0))
        {
            splineFollower.followSpeed = followSpeed;
        }

        else
        {
            splineFollower.followSpeed = 0;
        }
    }


}
