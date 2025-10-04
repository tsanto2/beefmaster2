using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRoamPlayer : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    public bool CanMove;

    private void Update()
    {
        if (CanMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-Vector3.forward * Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-Vector3.right * Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            }
        }
    }

}
