using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WorldspaceButtonHandler : MonoBehaviour
{

    [SerializeField]
    private Camera camera;

    private Button selectedButton = null;

    public Vector3 mousePos;

    public Vector3 offset;

    private void Update()
    {
        var mousePosScalarX = 720f / (float)Screen.width;
        var mousePosScalarY = 405f / (float)Screen.height;

        mousePos = Input.mousePosition;

        var normalizedMousePos = new Vector3(mousePos.x * mousePosScalarX, mousePos.y * mousePosScalarY);
        var newPos = camera.ScreenToWorldPoint(normalizedMousePos);

        Debug.Log(newPos);

        newPos += offset;

        transform.position = newPos;

        if (Input.GetMouseButtonUp(0))
        {
            if (selectedButton != null)
            {
                selectedButton.onClick.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UIButton")
        {
            selectedButton = other.GetComponent<Button>();
            selectedButton.Select();
            if (other.GetComponent<AudioSource>() != null)
            {
                other.GetComponent<AudioSource>().Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "UIButton")
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

}
