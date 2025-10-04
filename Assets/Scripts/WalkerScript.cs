using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerScript : MonoBehaviour
{

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private bool shouldAlwaysWalk;

    [SerializeField]
    public bool shouldNotWalk;

    // Update is called once per frame
    void Update()
    {
        if (!shouldNotWalk)
        {
            if (!shouldAlwaysWalk)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || (Input.anyKey))
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
                }
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
            }
        }
    }
}
