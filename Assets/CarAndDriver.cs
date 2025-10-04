using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAndDriver : MonoBehaviour
{
    [SerializeField]
    private float speed, startSpeed, incrementAmount, incrementTime;

    private int skipAFrame = 0;

    void Start()
    {
        speed = startSpeed;

        StartCoroutine(IncrementSpeed());
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        /*if (skipAFrame == 2)
        {
            transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed);
            skipAFrame = 0;
        }
        else
        {
            skipAFrame++;
        }*/
    }

    IEnumerator IncrementSpeed()
    {
        yield return new WaitForSeconds(incrementTime);

        speed += incrementAmount;

        StartCoroutine(IncrementSpeed());
    }
}
