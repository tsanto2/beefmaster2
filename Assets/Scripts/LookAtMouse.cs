using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{

    [SerializeField]
    private Camera camera;

    void Update()
    {
        var newDir = Vector3.RotateTowards(transform.forward, camera.ScreenToWorldPoint(Input.mousePosition), Time.deltaTime/10, 0f );
        var rot = Quaternion.LookRotation(newDir);

        var mousePosScalarX = 720f / (float)Screen.width;
        var mousePosScalarY = 405f / (float)Screen.height;

        var normalizedMousePos = new Vector3(Input.mousePosition.x * mousePosScalarX, Input.mousePosition.y * mousePosScalarY);

        var newPos = camera.ScreenToWorldPoint(normalizedMousePos);
        newPos = new Vector3(newPos.x, newPos.y, newPos.z + 2f);
        transform.position = newPos;
    }
}
