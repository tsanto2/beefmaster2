using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCameraPan : MonoBehaviour
{
    [SerializeField]
    private float panSpeedScalar, basePanSpeed, panSpeed = 5f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            panSpeed = basePanSpeed * panSpeedScalar;
        }
        else
        {
            panSpeed = basePanSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime);
        }
    }


}
