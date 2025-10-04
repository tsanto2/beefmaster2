using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamo : MonoBehaviour
{

    [SerializeField]
    private SkinnedMeshRenderer cowSKM;

    [SerializeField]
    private List<Material> materials;

    [SerializeField]
    private Shader psxShader;

    [SerializeField]
    private AudioSource buttonClickedSFX;

    public void ChangeCamoClicked()
    {
        var newMat = materials[Random.Range(0,materials.Count)];

        while (newMat == cowSKM.material)
        {
            newMat = materials[Random.Range(0, materials.Count)];
        }

        cowSKM.material = newMat;
        cowSKM.material.shader = psxShader;

        buttonClickedSFX.Play();
    }

}
