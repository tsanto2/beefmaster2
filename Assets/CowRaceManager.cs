using Cinemachine;
using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CowRaceManager : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera resultsCam;

    [SerializeField]
    private GameObject ResultsCanvas;

    [SerializeField]
    private List<TextMeshProUGUI> resultsTexts;

    [SerializeField]
    private float resultsWaitTime, resultsDisplayTime;

    [SerializeField]
    private bool useNames;

    [SerializeField]
    public List<SplineFollower> racerSF;

    [SerializeField]
    private List<int> racerLaps = new List<int>(4);

    [SerializeField]
    public int lapCount;

    public bool hasAnyoneFinished, hasEveryoneFinished;

    [SerializeField]
    private List<double> racerPercentages = new List<double>();

    [SerializeField]
    public List<SplineFollower> currentPositions, positions = new List<SplineFollower>();

    [SerializeField]
    private ListenForPlayerRaceReady raceStartListener;

    public Dictionary<SplineFollower, int> positionLapDict = new Dictionary<SplineFollower, int>();

    private void Start()
    {
        racerSF[0].onEndReached += RacerZeroEnded;
        racerSF[1].onEndReached += RacerOneEnded;
        racerSF[2].onEndReached += RacerTwoEnded;
        racerSF[3].onEndReached += RacerThreeEnded;
        racerLaps.Add(0);
        racerLaps.Add(0);
        racerLaps.Add(0);
        racerLaps.Add(0);
    }

    private void Update()
    {
        UpdateCurrentPositions();

        if (!hasEveryoneFinished && positions.Count >= 4)
        {
            hasEveryoneFinished = true;

            if (resultsCam != null)
            {
                resultsCam.Priority = 1000002;
            }

            StartCoroutine(DisplayResults());
        }
    }

    public void ResetRace()
    {
        hasAnyoneFinished = false;
        hasEveryoneFinished = false;

        positions.Clear();

        for (int i=0; i < racerLaps.Count; i++)
        {
            racerLaps[i] = 0;
        }
    }

    void UpdateCurrentPositions()
    {
        currentPositions.Clear();
        positionLapDict.Clear();

        int lapNum = Mathf.Max(racerLaps.ToArray());
        List<SplineFollower> prevLap = new List<SplineFollower>();

        foreach (SplineFollower sf in racerSF.OrderByDescending(splinefollower => splinefollower.GetPercent()))
        {
            int sfInd = racerSF.IndexOf(sf);
            if (racerLaps[sfInd] == lapNum)
            {
                currentPositions.Add(sf);
                positionLapDict.Add(sf, lapNum);
            }
            else
            {
                prevLap.Add(sf);
            }
        }

        foreach (SplineFollower sf in prevLap.OrderByDescending(splinefollower => splinefollower.GetPercent()))
        {
            currentPositions.Add(sf);
            positionLapDict.Add(sf, lapNum-1);
        }

    }

    void RacerZeroEnded(double number)
    {
        racerLaps[0]++;

        if (racerLaps[0] >= lapCount)
        {
            racerSF[0].follow = false;
            hasAnyoneFinished = true;
            positions.Add(racerSF[0]);
        }
    }

    void RacerOneEnded(double number)
    {
        racerLaps[1]++;

        if (racerLaps[1] >= lapCount)
        {
            racerSF[1].follow = false;
            hasAnyoneFinished = true;
            positions.Add(racerSF[1]);
        }
    }

    void RacerTwoEnded(double number)
    {
        racerLaps[2]++;

        if (racerLaps[2] >= lapCount)
        {
            racerSF[2].follow = false;
            hasAnyoneFinished = true;
            positions.Add(racerSF[2]);
        }
    }

    void RacerThreeEnded(double number)
    {
        racerLaps[3]++;

        if (racerLaps[3] >= lapCount)
        {
            racerSF[3].follow = false;
            hasAnyoneFinished = true;
            positions.Add(racerSF[3]);
        }
    }

    IEnumerator DisplayResults()
    {
        yield return new WaitForSeconds(resultsWaitTime);

        if (raceStartListener != null)
        {
            raceStartListener.hasTriggered = false;
        }

        ResultsCanvas.SetActive(true);

        int position = 1;
        foreach (SplineFollower sf in positions)
        {
            for (int i = 0; i < racerSF.Count; i++)
            {
                if (racerSF[i] == sf)
                {
                    Debug.Log("Position " + position + ": Racer " + i);
                    if (!useNames)
                    {
                        resultsTexts[position - 1].text = "Cow " + i;
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0:
                                resultsTexts[position - 1].text = "Black";
                                break;
                            case 1:
                                resultsTexts[position - 1].text = "Tan";
                                break;
                            case 2:
                                resultsTexts[position - 1].text = "Spots";
                                break;
                            case 3:
                                resultsTexts[position - 1].text = "Bull";
                                break;
                        }
                    }
                    position++;
                }
            }
        }

        if (resultsDisplayTime > 0)
        {
            yield return new WaitForSeconds(resultsDisplayTime);
            ResultsCanvas.SetActive(false);
        }
    }
}
