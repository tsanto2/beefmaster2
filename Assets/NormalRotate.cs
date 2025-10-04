using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRotate : MonoBehaviour
{

    [SerializeField]
    private float rotSpeedY, rotSpeedX;

    void Update()
    {
        transform.Rotate(Vector3.up, rotSpeedY * Time.deltaTime);
        transform.Rotate(Vector3.right, rotSpeedX * Time.deltaTime);
    }
}
