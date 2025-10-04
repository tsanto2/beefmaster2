using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckForActivateElevator : MonoBehaviour
{
    public TextMeshProUGUI inputText;
    public GameObject elevatorBase;
    public float elevateSpeed;
    public Vector3 startPos, endPos;

    public bool isElevating;
    public bool isColliding;
    public bool goingUp;

    private void Start()
    {
        startPos = elevatorBase.transform.position;
    }

    private void Update()
    {
        if (isColliding)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                goingUp = !goingUp;
            }
        }

        Vector3 dest = startPos;
        if (goingUp)
        {
            dest = endPos;
        }

        elevatorBase.transform.position = Vector3.MoveTowards(elevatorBase.transform.position, dest, elevateSpeed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isColliding = true;
            other.gameObject.transform.parent = elevatorBase.transform;

            if (!inputText.gameObject.activeInHierarchy)
            {
                inputText.gameObject.SetActive(true);
            }
            if (goingUp)
            {
                inputText.text = "E - Go Down";
            }
            else
            {
                inputText.text = "E - Go Up";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (inputText.gameObject.activeInHierarchy)
            {
                inputText.gameObject.SetActive(false);
            }
            isColliding = false;
            other.gameObject.transform.parent = null;
        }
    }

}
