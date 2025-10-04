using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inputText;

    [SerializeField]
    private Material daySkybox, nightSkybox;

    [SerializeField]
    private List<GameObject> lights;

    [SerializeField]
    private Light directionalLight;

    private QuestTracker9000 qm9000;

    private void Start()
    {
        qm9000 = FindObjectOfType<QuestTracker9000>();
    }

    private void Update()
    {
        if (qm9000.isNight)
        {
            RenderSettings.skybox = nightSkybox;
            RenderSettings.ambientIntensity = 0f;
            foreach (GameObject obj in lights)
            {
                obj.SetActive(true);
            }

            //directionalLight.intensity = 0.03f;
        }
        else
        {
            RenderSettings.skybox = daySkybox;
            RenderSettings.ambientIntensity = 1f;
            foreach (GameObject obj in lights)
            {
                obj.SetActive(false);
            }

            //directionalLight.intensity = 1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inputText.gameObject.SetActive(true);

            if (qm9000.isNight)
            {
                inputText.text = "E - Turn On";
            }
            else
            {
                inputText.text = "E - Turn On";
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                qm9000.isNight = !qm9000.isNight;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inputText.gameObject.SetActive(false);
        }
    }


}
