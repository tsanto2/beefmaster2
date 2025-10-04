using Cinemachine;
using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceCameraManager : MonoBehaviour
{
    [SerializeField]
    private List<CinemachineVirtualCamera> OverviewCams;

    [SerializeField]
    private CinemachineVirtualCamera pairCam, crewCam, soloCam;

    [SerializeField]
    private List<CinemachineVirtualCamera> turn1Cams, turn2Cams, turn3Cams, turn4Cams;

    [SerializeField]
    private CinemachineTargetGroup frontTwoGroup, rearTwoGroup, fullGroup;

    [SerializeField]
    private GameObject highSpeedCamCanvas;

    [SerializeField]
    private TextMeshProUGUI hiSpeedText;

    [SerializeField]
    private float followCamSwitchTimeMin, followCamSwitchTimeMax;

    private int followTarget;

    [SerializeField]
    private List<SplineFollower> racers;

    CowRaceManager crm;

    [SerializeField]
    private float transitionProtectionTime;

    public bool justTransitioned, canUpdate, hitLastCam, isSpeedCam;

    public int qCamSkipCounter = 0;

    private CinemachineVirtualCamera lastQCam = null;

    private void Start()
    {
        //StartCoroutine(FollowCamAutoSwitcher());
        crm = FindObjectOfType<CowRaceManager>();
        StartCoroutine(WaitToUpdate());
    }

    private void LateUpdate()
    {
        if (!canUpdate)
            return;

        int quadrant = 0;
        var r1Percentage = crm.currentPositions[0].GetPercent();
        if (r1Percentage >= 0 && r1Percentage < 0.25f)
        {
            quadrant = 0;
        }
        else if (r1Percentage >= 0.25f && r1Percentage < 0.5f)
        {
            quadrant = 1;
        }
        else if (r1Percentage >= 0.5f && r1Percentage < 0.75f)
        {
            quadrant = 2;
        }
        else if (r1Percentage >= 0.75f && r1Percentage < 1f)
        {
            quadrant = 3;
        }

        float highSpeed = 0f;
        SplineFollower highMan = null;
        float defaultSpeed = crm.currentPositions[0].GetComponent<RacerSpeedRandomizer9000>().defaultSpeed;
        float variance = crm.currentPositions[0].GetComponent<RacerSpeedRandomizer9000>().speedVariance;
        for (int i=0; i<crm.currentPositions.Count; i++)
        {
            if (crm.currentPositions[i].spline.CalculateLength() / 172.8353f * defaultSpeed + variance - crm.currentPositions[i].followSpeed < 0.15f)
            {
                highSpeed = crm.currentPositions[i].followSpeed * (172.8353f/crm.currentPositions[i].spline.CalculateLength());
                highMan = crm.currentPositions[i];
            }
        }

        if (highMan != null)
        {
            hiSpeedText.text = (highSpeed + Random.Range(-0.1f, 0.1f)).ToString("F2");
        }

        if (crm.positionLapDict[crm.currentPositions[0]] == crm.lapCount-1 && crm.currentPositions[0].GetPercent() > 0.75f)
        {
            justTransitioned = true;
            hitLastCam = true;
            highSpeedCamCanvas.SetActive(false);
            turn4Cams[0].Priority = 1000001;
        }

        frontTwoGroup.m_Targets[0].target = crm.currentPositions[0].transform;
        frontTwoGroup.m_Targets[1].target = crm.currentPositions[1].transform;

        if (!justTransitioned && !hitLastCam)
        {
            if (highMan != null)
            {
                isSpeedCam = true;
                pairCam.Priority = 0;
                crewCam.Priority = 0;
                soloCam.Priority = 100000;
                if (lastQCam != null)
                    lastQCam.Priority = 0;
                soloCam.LookAt = highMan.transform;
                highSpeedCamCanvas.SetActive(true);
                justTransitioned = true;
                StartCoroutine(TransitionWaitTime());
            }
            else if (((crm.positionLapDict[crm.currentPositions[0]] + crm.currentPositions[0].GetPercent() - crm.positionLapDict[crm.currentPositions[3]] - crm.currentPositions[3].GetPercent()) > 0.07f && Random.Range(0,1f) > 0.2f) || Random.Range(0, 1f) > 0.8f)
            {
                highSpeedCamCanvas.SetActive(false);
                pairCam.Priority = 100000;
                crewCam.Priority = 0;
                soloCam.Priority = 0;
                if (lastQCam != null)
                    lastQCam.Priority = 0;
                frontTwoGroup.m_Targets[0].target = crm.currentPositions[0].transform;
                frontTwoGroup.m_Targets[1].target = crm.currentPositions[1].transform;
                justTransitioned = true;
                StartCoroutine(TransitionWaitTime());
            }
            else
            {
                if (qCamSkipCounter < Random.Range(4, 8))
                {
                    qCamSkipCounter++;
                    highSpeedCamCanvas.SetActive(false);
                    pairCam.Priority = 0;
                    crewCam.Priority = 100000;
                    soloCam.Priority = 0;
                    if (lastQCam != null)
                        lastQCam.Priority = 0;
                    //followCam.LookAt = fullGroup.transform;
                    //followCam.Follow = fullGroup.transform;
                    justTransitioned = true;
                    StartCoroutine(TransitionWaitTime());
                }
                else
                {
                    qCamSkipCounter = 0;
                    pairCam.Priority = 0;
                    crewCam.Priority = 0;
                    soloCam.Priority = 0;
                    if (lastQCam != null)
                        lastQCam.Priority = 0;
                    int randCam = 0;
                    highSpeedCamCanvas.SetActive(false);
                    justTransitioned = true;
                    StartCoroutine(TransitionWaitTime());

                    switch (quadrant)
                    {
                        case 0:
                            randCam = Random.Range(0, turn1Cams.Count);
                            turn1Cams[randCam].Priority = 100000;
                            lastQCam = turn1Cams[randCam];
                            break;
                        case 1:
                            randCam = Random.Range(0, turn2Cams.Count);
                            turn2Cams[randCam].Priority = 100000;
                            lastQCam = turn2Cams[randCam];
                            break;
                        case 2:
                            randCam = Random.Range(0, turn3Cams.Count);
                            turn3Cams[randCam].Priority = 100000;
                            lastQCam = turn3Cams[randCam];
                            break;
                        case 3:
                            randCam = Random.Range(0, turn4Cams.Count);
                            turn4Cams[randCam].Priority = 100000;
                            lastQCam = turn4Cams[randCam];
                            break;
                    }
                }
            }
        }
    }

    IEnumerator FollowCamAutoSwitcher()
    {
        yield return new WaitForSeconds(Random.Range(followCamSwitchTimeMin, followCamSwitchTimeMax));

        pairCam.LookAt = racers[Random.Range(0, racers.Count)].transform;

        StartCoroutine(FollowCamAutoSwitcher());
    }

    IEnumerator TransitionWaitTime()
    {
        if (!isSpeedCam)
        {
            yield return new WaitForSeconds(Random.Range(transitionProtectionTime, transitionProtectionTime + 2f));

        }
        else
        {
            isSpeedCam = false;
            yield return new WaitForSeconds(transitionProtectionTime-1f);
        }

        justTransitioned = false;
    }

    IEnumerator WaitToUpdate()
    {
        yield return new WaitForSeconds(racers[0].GetComponent<RacerSpeedRandomizer9000>().waitForRaceTime);

        canUpdate = true;
    }
}
