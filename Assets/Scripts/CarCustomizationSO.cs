using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CarCustomizationSO", order = 1)]
public class CarCustomizationSO : ScriptableObject
{
    public List<Material> customizationOptions;
}