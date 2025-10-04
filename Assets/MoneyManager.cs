using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    private CowRaceManager crm;

    [SerializeField]
    private SplineFollower blackCow;

    public bool hasRacePayedOut;

    public int money = 0;

    void Update()
    {
        if (crm.hasEveryoneFinished && !hasRacePayedOut)
        {
            hasRacePayedOut = true;

            if (crm.positions[0] == blackCow)
            {
                money += 1000;
            }
        }
    }
}
