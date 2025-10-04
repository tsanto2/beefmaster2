using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccelerationer : MonoBehaviour
{
    [SerializeField]
    private float normalAccel, sprintAccel;

    private FirstPersonController fpc;

    private void Start()
    {
        fpc = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            fpc.SpeedChangeRate = sprintAccel;
        }
        else
        {
            fpc.SpeedChangeRate = normalAccel;
        }
    }
}
