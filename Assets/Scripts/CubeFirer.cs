using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFirer : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;

    [SerializeField]
    public float currentMinWaitTime, currentMaxWaitTime, defaultMinWaitTime, defaultMaxWaitTime, hyperMinWaitTime, hyperMaxWaitTime;

    [SerializeField]
    private float minAngle, maxAngle;

    [SerializeField]
    private float minForce, maxForce;

    [SerializeField]
    private bool fireVertical;

    [SerializeField]
    private List<Color> colors;

    private void Start()
    {
        StartCoroutine(FireCube());
        currentMinWaitTime = defaultMinWaitTime;
        currentMaxWaitTime = defaultMaxWaitTime;
    }

    public void StartCubeFirer()
    {
        StartCoroutine(FireCube());
    }

    private IEnumerator FireCube()
    {
        yield return new WaitForSeconds(Random.Range(currentMinWaitTime, currentMaxWaitTime));

        var cube = Instantiate(cubePrefab, transform.position, transform.rotation);
        cube.transform.parent = this.transform;
        var cubeRb = cube.GetComponentInChildren<Rigidbody>();
        //cube.GetComponent<MeshRenderer>().material.color = colors[Random.Range(0,colors.Count)];

        var firingDirection = new Vector3(Random.Range(minAngle, maxAngle), Random.Range(minAngle, maxAngle), Random.Range(minAngle, maxAngle)).normalized;

        cubeRb.AddForce(firingDirection * Random.Range(minForce, maxForce), ForceMode.Impulse);

        StartCoroutine(FireCube());
    }

}
