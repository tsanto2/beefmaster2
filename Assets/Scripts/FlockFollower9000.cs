using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockFollower9000 : MonoBehaviour
{
    [SerializeField]
    private Transform followObject;

    private void Update()
    {
        transform.position = new Vector3(followObject.position.x, transform.position.y, followObject.position.z);
    }


}
