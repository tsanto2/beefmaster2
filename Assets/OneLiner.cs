using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OneLiner : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI oneLinerText, inputText;

    [SerializeField]
    private AudioSource mooAudio;

    [SerializeField]
    private string myOneLiner;

    bool isInMyZone, linerVisible;

    private void Start()
    {
        mooAudio = GetComponent<AudioSource>();
        mooAudio.pitch = Random.Range(0.5f, 1.2f);
        //oneLinerText = GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        //inputText = GameObject.Find("InputText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (isInMyZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //if (!linerVisible)
                //{
                    mooAudio.Play();
                //}
                linerVisible = true;
            }
            if (!linerVisible)
            {
                inputText.gameObject.SetActive(true);
                oneLinerText.gameObject.SetActive(false);
                inputText.text = "E - Interact";
            }
            else
            {
                inputText.gameObject.SetActive(false);
                oneLinerText.gameObject.SetActive(true);
                oneLinerText.text = myOneLiner;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInMyZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInMyZone = false;
            linerVisible = false;
            inputText.gameObject.SetActive(false);
            oneLinerText.gameObject.SetActive(false);
        }
    }

}
