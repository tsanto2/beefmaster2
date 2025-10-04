using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingClose2DaHood : MonoBehaviour
{

    [SerializeField]
    private Transform hoodTramsfprm;
    private Vector3 hoodPos;

    [SerializeField]
    private float zoneStartDist, zoneFinalDist, minHeight, maxHeight;
    public float minFOV, maxFOV, ratio;

    [SerializeField]
    private CinemachineVirtualCamera vcam;

    private void Start()
    {
        StartCoroutine(CheckFOV());
        hoodPos = hoodTramsfprm.position;
        float fovDiff = maxFOV - minFOV;
        float heightDiff = maxHeight - minHeight;
        ratio = fovDiff / heightDiff;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, hoodPos);
        if (distance < zoneStartDist && distance > zoneFinalDist)
        {
            vcam.GetComponent<VerticalityZoomer>().enabled = false;
            float newY = maxHeight - distance / (zoneStartDist - zoneFinalDist) * minHeight;

            float distRatio = distance / zoneStartDist;
            float fovDiff = maxFOV - minFOV;

            newY = maxHeight * distRatio;
            if (newY < minHeight)
            {
                newY = minHeight;
            }
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            float newFOV = maxFOV - distance / (zoneStartDist - zoneFinalDist) * minFOV;
            newFOV = maxFOV * distRatio;
            if (newFOV < minFOV)
            {
                newFOV = minFOV;
            }

            //vcam.m_Lens.FieldOfView = newFOV;
            vcam.m_Lens.FieldOfView = newFOV;
        }
        else if (distance > zoneFinalDist)
        {
            vcam.GetComponent<VerticalityZoomer>().enabled = true;
        }
    }

    IEnumerator CheckFOV()
    {
        yield return new WaitForSeconds(0.5f);

        //maxHeight = vcam.m_Lens.FieldOfView;
    }

}
