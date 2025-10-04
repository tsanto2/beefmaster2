using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeTrain : MonoBehaviour
{
    [SerializeField]
    private CarCustomizationSO carCustomization;

    void Start()
    {
        foreach (MeshRenderer mr in GetComponentsInChildren<MeshRenderer>())
        {
            mr.material = carCustomization.customizationOptions[Random.Range(0, carCustomization.customizationOptions.Count)];
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            foreach (MeshRenderer mr in GetComponentsInChildren<MeshRenderer>())
            {
                mr.material = carCustomization.customizationOptions[Random.Range(0, carCustomization.customizationOptions.Count)];
            }
        }
    }

}
