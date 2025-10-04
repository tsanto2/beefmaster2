using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockFinder9000 : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vcam;

    private bool hasFoundFlock;

    private Transform target;

    void Update()
    {
        if (!hasFoundFlock)
        {
            GameObject birb = GameObject.Find("bird 1");
            if (birb != null)
            {
                hasFoundFlock = true;
                target = birb.transform;
                vcam.LookAt = target;
            }
        }
    }
}
