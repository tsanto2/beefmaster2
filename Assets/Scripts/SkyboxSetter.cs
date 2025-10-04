using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxSetter : MonoBehaviour
{
    [SerializeField]
    private bool setSkybox, setLightIntensity;

    [SerializeField]
    private Material sceneSkybox;

    [SerializeField]
    private float lightIntensity = 1;

    private void Start()
    {
        if (setSkybox)
        {
            RenderSettings.skybox = sceneSkybox;
        }
        if (setLightIntensity)
        {
            RenderSettings.ambientIntensity = lightIntensity;
        }
    }

}
