using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUnityCharacter : MonoBehaviour
{

    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            cc.Move(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cc.Move(Vector3.right);
        }
        if (Input.GetKey(KeyCode.S))
        {
            cc.Move(Vector3.back);
        }
        if (Input.GetKey(KeyCode.A))
        {
            cc.Move(Vector3.left);
        }
    }
}
