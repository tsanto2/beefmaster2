using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameoAppearance : MonoBehaviour
{

    [SerializeField]
    private Transform[] positions;

    private void Start()
    {
        if (Random.Range(0,2) == 1)
        {
            gameObject.SetActive(false);
        }

        int posIndex = Random.Range(0, positions.Length);

        transform.position = positions[posIndex].position;
        transform.rotation = positions[posIndex].rotation;
    }

}
