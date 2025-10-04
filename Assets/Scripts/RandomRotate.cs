using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{

    [SerializeField]
    private float rotSpeedY, rotSpeedX;

    void Update()
    {
        transform.Rotate(Vector3.up, Random.Range(rotSpeedY, rotSpeedX) * Time.deltaTime);
        transform.Rotate(Vector3.right, Random.Range(rotSpeedY, rotSpeedX) * Time.deltaTime);
    }
}
