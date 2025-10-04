using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DaySetter : MonoBehaviour
{
    void Start()
    {
        var texxxt = GetComponent<TextMeshProUGUI>();

        if (DayProgressManager.instance != null)
        {
            texxxt.text = "Day " + DayProgressManager.instance.currentDay.ToString();
        }
        else
        {
            texxxt.text = "Day ???";
        }
    }

}
