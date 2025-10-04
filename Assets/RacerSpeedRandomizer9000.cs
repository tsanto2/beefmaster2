using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerSpeedRandomizer9000 : MonoBehaviour
{
    private SplineFollower myFollower;

    [SerializeField]
    private float minSpeed, maxSpeed, updateTimeMin, updateTimeMax;

    [SerializeField]
    public float defaultSpeed, speedVariance;

    [SerializeField]
    public float waitForRaceTime;

    [SerializeField]
    private bool WaitForTrigger;

    CowRaceManager crm;

    private void Start()
    {
        myFollower = GetComponent<SplineFollower>();
        crm = FindObjectOfType<CowRaceManager>();

        if (!WaitForTrigger)
        {
            StartCoroutine(Wait2Race());
        }
    }

    public void TriggerRace()
    {
        StartCoroutine(Wait2Race());
    }

    private void Update()
    {
    }

    IEnumerator Wait2Race()
    {
        myFollower.followSpeed = 0;
        yield return new WaitForSeconds(waitForRaceTime);
        myFollower.follow = true;
        myFollower.followSpeed = myFollower.spline.CalculateLength() / 172.8353f * defaultSpeed;
        minSpeed = myFollower.followSpeed - speedVariance;
        maxSpeed = myFollower.followSpeed + speedVariance;
        StartCoroutine(UpdateRacerSpeed());
    }

    IEnumerator UpdateRacerSpeed()
    {
        yield return new WaitForSeconds(Random.Range(updateTimeMin, updateTimeMax));

        int myNum = 0;
        for (int i=0; i<crm.racerSF.Count; i++)
        {
            if (myFollower == crm.racerSF[i])
            {
                myNum = i;
            }
        }
        myFollower.followSpeed = Random.Range(minSpeed, maxSpeed);

        if (myFollower == crm.currentPositions[1] && crm.currentPositions[0].GetPercent() - myFollower.GetPercent() > 0.05f)
        {
            Debug.Log("Catchup scenario: Second place increasing effort");
            //myFollower.followSpeed = Random.Range((((maxSpeed + minSpeed) / 2f) + minSpeed) / 2f, maxSpeed);
            myFollower.followSpeed = Random.Range((((maxSpeed + minSpeed) / 2f) + maxSpeed) / 2f, maxSpeed);
        }
        if ((myFollower == crm.currentPositions[2]) && crm.currentPositions[0].GetPercent() - myFollower.GetPercent() > 0.06f)
        {
            Debug.Log("Catchup scenario: Third place increasing effort");
            myFollower.followSpeed = Random.Range((maxSpeed + minSpeed) / 2, maxSpeed);
        }
        if (myFollower == crm.currentPositions[3] && crm.currentPositions[0].GetPercent() - myFollower.GetPercent() > 0.075f)
        {
            Debug.Log("Catchup scenario: Last place increasing effort");
            myFollower.followSpeed = Random.Range((((maxSpeed + minSpeed) / 2f) + maxSpeed) / 2f, maxSpeed);
        }
        else
        {
            myFollower.followSpeed = Random.Range(minSpeed, maxSpeed);
        }

        StartCoroutine(UpdateRacerSpeed());
    }

}
