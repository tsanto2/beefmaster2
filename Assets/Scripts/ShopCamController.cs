using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCamController : MonoBehaviour
{
    private bool hasSwitched;

    [SerializeField]
    private CinemachineVirtualCamera outsideCam, shopkeepCam, carCam;

    void Update()
    {
        if (/*!hasSwitched && */Input.GetMouseButtonUp(0))
        {
            hasSwitched = true;
            outsideCam.Priority = 0;
            carCam.Priority = 0;
            shopkeepCam.Priority = 10;
        }
        if (/*!hasSwitched && */Input.GetMouseButtonUp(1))
        {
            hasSwitched = true;
            outsideCam.Priority = 0;
            carCam.Priority = 10;
            shopkeepCam.Priority = 0;
        }
    }
}
