using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCustomizer : MonoBehaviour
{

    [SerializeField]
    private CarCustomizationSO customizationMats;

    [SerializeField]
    private MeshRenderer paintJob;

    [SerializeField]
    private MeshRenderer interior;

    private int custIndex = 0;
    private int custIndex2 = 0;

    private ChallengeManager cm;

    private void Start()
    {
        cm = FindObjectOfType<ChallengeManager>();

        paintJob.material = customizationMats.customizationOptions[0];
        interior.material = customizationMats.customizationOptions[0];

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
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            custIndex++;
            if (custIndex >= customizationMats.customizationOptions.Count)
            {
                custIndex = 0;
            }
            paintJob.material = customizationMats.customizationOptions[custIndex];
            //paintJob.material = customizationMats[Random.Range(0, customizationMats.Count)];
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            custIndex--;
            if (custIndex < 0)
            {
                custIndex = customizationMats.customizationOptions.Count-1;
            }
            paintJob.material = customizationMats.customizationOptions[custIndex];
            //paintJob.material = customizationMats[Random.Range(0, customizationMats.Count)];
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            custIndex2++;
            if (custIndex2 >= customizationMats.customizationOptions.Count)
            {
                custIndex2 = 0;
            }
            interior.material = customizationMats.customizationOptions[custIndex2];
            //interior.material = customizationMats[Random.Range(0, customizationMats.Count)];
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            custIndex2--;
            if (custIndex2 < 0)
            {
                custIndex2 = customizationMats.customizationOptions.Count - 1;
            }
            interior.material = customizationMats.customizationOptions[custIndex2];
            //interior.material = customizationMats[Random.Range(0, customizationMats.Count)];
        }
    }

    public void ConfirmCustomization()
    {
        PlayerPrefs.SetInt("CarPaintCust" + cm.masterSlot, custIndex);
        PlayerPrefs.SetInt("CarInteriorCust" + cm.masterSlot, custIndex2);

        SceneManager.LoadScene("CaoGarden", LoadSceneMode.Additive);
        FindObjectOfType<AdditiveSceneLoader>().CurrentlyAdditivedScene = "CarCustomization";
        SceneManager.UnloadScene("CarCustomization");
    }

}
