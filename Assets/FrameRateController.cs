using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateController : MonoBehaviour
{
    [SerializeField]
    private int targetFrameRate;


    private void Update()
    {
        Application.targetFrameRate = targetFrameRate;
    }


}
