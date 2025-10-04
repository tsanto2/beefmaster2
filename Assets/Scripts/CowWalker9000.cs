using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowWalker9000 : MonoBehaviour
{
    [SerializeField]
    private Transform movementObj;

    [SerializeField]
    private Vector3 targetGrazePos;

    [SerializeField]
    private Vector3[] standPositions;

    private Vector3 startPos;

    private Vector3 newDir;

    [SerializeField]
    private float moveSpeed, grazeSpeed, grazeWaitTimeMin, grazeWaitTimeMax, idleTimeMin, idleTimeMax, decisionTimeMin, decisionTimeMax;

    private void Start()
    {
        startPos = movementObj.localPosition;

        StartCoroutine(ArtificiallyIntelligentCowBehaviour());
    }

    private IEnumerator ArtificiallyIntelligentCowBehaviour()
    {
        yield return new WaitForSeconds(Random.Range(decisionTimeMin, decisionTimeMax));

        int decision = Random.Range(0, 100);

        if (decision < 10)
        {
            StartCoroutine(Idle());
        }
        else if (decision >= 10 && decision < 30)
        {
            StartCoroutine(Graze());
        }
        else
        {
            StartCoroutine(Meander());
        }
    }

    private IEnumerator Meander()
    {
        var newPos = standPositions[Random.Range(0, standPositions.Length)];

        while (newPos == transform.position)
        {
            newPos = standPositions[Random.Range(0, standPositions.Length)];
        }


        // Determine which direction to rotate towards
        Vector3 targetDirection = newPos - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = moveSpeed * Time.deltaTime;

        while (transform.forward != targetDirection)
        {
            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            if (newDirection == newDir)
            {
                break;
            }
            newDir = newDirection;

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);

            yield return new WaitForEndOfFrame();
        }


        while (transform.position != newPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * moveSpeed);

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(ArtificiallyIntelligentCowBehaviour());
    }

    private IEnumerator Idle()
    {
        yield return new WaitForSeconds(Random.Range(idleTimeMin, idleTimeMax));

        StartCoroutine(ArtificiallyIntelligentCowBehaviour());
    }

    private IEnumerator Graze()
    {
        yield return new WaitForSeconds(Random.Range(grazeWaitTimeMin, grazeWaitTimeMax));

        while (movementObj.localPosition != targetGrazePos)
        {
            movementObj.localPosition = Vector3.MoveTowards(movementObj.localPosition, targetGrazePos, Time.deltaTime * grazeSpeed);

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(Random.Range(grazeWaitTimeMin, grazeWaitTimeMax));

        while (movementObj.localPosition != startPos)
        {
            movementObj.localPosition = Vector3.MoveTowards(movementObj.localPosition, startPos, Time.deltaTime * grazeSpeed);

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(ArtificiallyIntelligentCowBehaviour());
    }
}
