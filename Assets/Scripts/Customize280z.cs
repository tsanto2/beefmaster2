using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customize280z : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer mr;

    [SerializeField]
    private CarCustomizationSO carCustomization;

    private void Start()
    {
        for (int i=0; i<mr.materials.Length; i++)
        {
            mr.materials[i] = carCustomization.customizationOptions[Random.Range(0, carCustomization.customizationOptions.Count)];
        }

        mr.material = carCustomization.customizationOptions[Random.Range(0, carCustomization.customizationOptions.Count)];
    }


}
