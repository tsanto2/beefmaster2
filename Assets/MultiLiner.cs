using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MultiLiner : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI oneLinerText, inputText;

    [SerializeField]
    private AudioSource mooAudio;

    [SerializeField]
    private List<string> myLines;

    [SerializeField]
    private bool shouldLoop;

    public bool HasCompletedFullDialogue;

    [SerializeField]
    private bool shouldRetriggerHasCompletedFullDialogue;

    bool isInMyZone, linerVisible;
    int linerIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        linerIndex = -1;
        if (mooAudio == null)
        {
            mooAudio = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInMyZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //if (!linerVisible)
                //{
                mooAudio.pitch = Random.Range(0.5f, 1.4f);
                mooAudio.Play();
                //}
                linerVisible = true;

                linerIndex++;
                if (linerIndex == myLines.Count && shouldLoop)
                {
                    linerIndex = 0;
                }
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
                oneLinerText.text = myLines[linerIndex];
                if (linerIndex == myLines.Count - 1)
                {
                    HasCompletedFullDialogue = true;
                }
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
            linerIndex = -1;
            if (shouldRetriggerHasCompletedFullDialogue)
            {
                HasCompletedFullDialogue = false;
            }
        }
    }
}
