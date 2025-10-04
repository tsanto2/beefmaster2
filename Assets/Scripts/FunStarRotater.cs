using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunStarRotater : MonoBehaviour
{

    [SerializeField]
    private float pauseTimeMin, pauseTimeMax, minTurnSpeed, maxTurnSpeed;

    [SerializeField]
    private float yMin, yMax, xMin, xMax;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForTurn());
    }

    IEnumerator WaitForTurn()
    {
        yield return new WaitForSeconds(GetRandom(pauseTimeMin, pauseTimeMax));

        StartCoroutine(BeginTurn());
    }

    IEnumerator BeginTurn()
    {
        Vector3 newDestination = new Vector3(GetRandom(xMin, xMax), GetRandom(yMin, yMax), transform.position.z);
        var moveSpeed = GetRandom(minTurnSpeed, maxTurnSpeed);

        while (transform.position != newDestination)
        {
            transform.position = Vector3.MoveTowards(transform.position, newDestination, moveSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(WaitForTurn());
    }

    float GetRandom(float min, float max)
    {
        return Random.Range(min, max);
    }
}
