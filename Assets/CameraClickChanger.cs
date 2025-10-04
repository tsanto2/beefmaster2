using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClickChanger : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera[] cams;

    private int index = 0;

    private void Start()
    {
        foreach (CinemachineVirtualCamera cam in cams)
        {
            if (cam == cams[index])
            {
                cam.Priority = 10000;
            }
            else
            {
                cam.Priority = 0;
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            index++;
            if (index >= cams.Length)
            {
                index = 0;
            }

            foreach(CinemachineVirtualCamera cam in cams)
            {
                if (cam == cams[index])
                {
                    cam.Priority = 10000;
                }
                else
                {
                    cam.Priority = 0;
                }
            }
        }
    }

}
