using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseLeaver9000 : MonoBehaviour
{
    [SerializeField]
    private GameObject houseLeaverUI;

    bool inTrigger;

    private void Update()
    {
        if (inTrigger && Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("JustAField 1");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = true;
        }

        houseLeaverUI.SetActive(inTrigger);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = false;
        }

        houseLeaverUI.SetActive(inTrigger);
    }

}
