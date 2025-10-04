using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenForPlayerRaceReady : MonoBehaviour
{
    [SerializeField]
    private List<MultiLiner> multiLiners;

    [SerializeField]
    private List<RacerSpeedRandomizer9000> racers;

    [SerializeField]
    private CowRaceManager crm;

    [SerializeField]
    private MoneyManager mm;

    public bool hasTriggered;

    private bool hasRacedBefore;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (MultiLiner ml in multiLiners)
        {
            if (ml.HasCompletedFullDialogue && !hasTriggered)
            {
                if (hasRacedBefore)
                {
                    crm.ResetRace();
                    mm.hasRacePayedOut = false;
                }

                hasRacedBefore = true;
                hasTriggered = true;

                foreach (RacerSpeedRandomizer9000 racer in racers)
                {
                    racer.TriggerRace();
                }
            }
        }
    }
}
