using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FileButton : MonoBehaviour
{

    private void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = gameObject.name;
    }

    public void LoadMyBytes()
    {
        FindObjectOfType<ReadBytes>().LoadBytes(gameObject.name);
    }


}
