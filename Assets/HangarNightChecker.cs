using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangarNightChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject open, closed;

    QuestTracker9000 qt9k;

    private void Start()
    {
        qt9k = FindObjectOfType<QuestTracker9000>();
    }

    void Update()
    {
        if (qt9k.isNight)
        {
            open.SetActive(true);
            closed.SetActive(false);
        }
        else
        {
            open.SetActive(false);
            closed.SetActive(true);
        }
    }
}
