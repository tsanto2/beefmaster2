using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRotate : MonoBehaviour
{

    [SerializeField]
    private float rotateSpeedMin, rotateSpeedMax, rotationMin, rotationMax;

    float rotateSpeed;
    Vector3 rotateDir;

    private void Start()
    {
        rotateSpeed = Random.Range(rotateSpeedMin, rotateSpeedMax);
        rotateDir = new Vector3(Random.Range(rotationMin, rotationMax), Random.Range(rotationMin, rotationMax), Random.Range(rotationMin, rotationMax));
    }

    private void Update()
    {
        transform.Rotate(rotateDir, rotateSpeed * Time.deltaTime);
    }

}
