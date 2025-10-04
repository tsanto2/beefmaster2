using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour
{
    [SerializeField]
    private Transform rotatio;

    [SerializeField]
    private float rotateSpeed = 10f;

    void Update()
    {
        transform.RotateAround(rotatio.position, Vector3.up, Time.deltaTime * rotateSpeed);
    }
}
