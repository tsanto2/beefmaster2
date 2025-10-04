using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSetter : MonoBehaviour
{

    [SerializeField]
    private Material[] skyboxes;

    [SerializeField]
    private GameObject[] directionalLights;

    private void Start()
    {
        RenderSettings.skybox = skyboxes[Random.Range(0, skyboxes.Length)];

        directionalLights[Random.Range(0, directionalLights.Length)].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            RenderSettings.skybox = skyboxes[Random.Range(0, skyboxes.Length)];

            foreach(GameObject obj in directionalLights)
            {
                obj.SetActive(false);
            }

            directionalLights[Random.Range(0, directionalLights.Length)].SetActive(true);
        }
    }

}
