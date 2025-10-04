using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowGrazer9000 : MonoBehaviour
{

    [SerializeField]
    private Transform movementObj;

    [SerializeField]
    private Vector3 targetPos;

    private Vector3 startPos;

    [SerializeField]
    private float speed, grazeWaitTimeMin, grazeWaitTimeMax;

    private void Start()
    {
        startPos = movementObj.localPosition;

        StartCoroutine(Graze());
    }

    private IEnumerator Graze()
    {
        yield return new WaitForSeconds(Random.Range(grazeWaitTimeMin, grazeWaitTimeMax));

        while (movementObj.localPosition != targetPos)
        {
            movementObj.localPosition = Vector3.MoveTowards(movementObj.localPosition, targetPos, Time.deltaTime * speed);

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(Random.Range(grazeWaitTimeMin, grazeWaitTimeMax));

        while (movementObj.localPosition != startPos)
        {
            movementObj.localPosition = Vector3.MoveTowards(movementObj.localPosition, startPos, Time.deltaTime * speed);

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(Graze());
    }

}
