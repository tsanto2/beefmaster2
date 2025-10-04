using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCarCustomization : MonoBehaviour
{
    ChallengeManager cm;

    [SerializeField]
    private MeshRenderer paintJob, interior;

    [SerializeField]
    private CarCustomizationSO customizationMats;

    void Start()
    {
        cm = FindObjectOfType<ChallengeManager>();

        if (cm != null)
        {
            if (PlayerPrefs.GetInt("CarPaintCust" + cm.masterSlot, -1) != -1)
            {
                paintJob.material = customizationMats.customizationOptions[PlayerPrefs.GetInt("CarPaintCust" + cm.masterSlot, -1)];
            }
            if (PlayerPrefs.GetInt("CarInteriorCust" + cm.masterSlot, -1) != -1)
            {
                interior.material = customizationMats.customizationOptions[PlayerPrefs.GetInt("CarInteriorCust" + cm.masterSlot, -1)];
            }
        }
        else
        {
            paintJob.material = customizationMats.customizationOptions[Random.Range(0, customizationMats.customizationOptions.Count)];
            interior.material = customizationMats.customizationOptions[Random.Range(0, customizationMats.customizationOptions.Count)];
        }
    }
}
