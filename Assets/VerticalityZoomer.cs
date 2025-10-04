using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalityZoomer : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public float minFOV, maxFOV, minHeight, maxHeight, ratio, startHeight;

    private void Start()
    {
        startHeight = transform.position.y;
        float fovDiff = maxFOV - minFOV;
        float heightDiff = maxHeight - minHeight;
        ratio = fovDiff / heightDiff;
    }

    private void Update()
    {
        if (transform.position.y > startHeight)
        {
            float heightRatio = transform.position.y / maxHeight;
            float fovDiff = maxFOV - minFOV;

            cam.m_Lens.FieldOfView = maxFOV - heightRatio * fovDiff;
        }
    }
}
