using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatchTrain : MonoBehaviour
{
    [SerializeField]
    private Transform putPlayerPos, dropPlayerPos;

    [SerializeField]
    private TextMeshProUGUI inputText;

    bool isOnTrain, isBoarding;

    float resetMoveSpeed, resetSprintSpeed;

    GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inputText.gameObject.SetActive(true);
            inputText.text = "E - Get On";
        }
    }

    private void Update()
    {
        if (isOnTrain)
        {
            inputText.text = "E - Get Off";

            if (Input.GetKeyDown(KeyCode.E) && !isBoarding)
            {
                isOnTrain = false;
                player.transform.parent = null;
                //other.transform.position = dropPlayerPos.position;
                player.gameObject.GetComponent<CharacterController>().enabled = true;
                var fpc = player.gameObject.GetComponent<FirstPersonController>();
                fpc.MoveSpeed = resetMoveSpeed;
                fpc.SprintSpeed = resetSprintSpeed;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isOnTrain)
                {
                    isBoarding = true;
                    StartCoroutine(BoardingBuffer());
                    other.transform.parent = putPlayerPos;
                    other.transform.position = putPlayerPos.position;
                    other.gameObject.GetComponent<CharacterController>().enabled = false;
                    var fpc = other.gameObject.GetComponent<FirstPersonController>();
                    resetMoveSpeed = fpc.MoveSpeed;
                    resetSprintSpeed = fpc.SprintSpeed;
                    fpc.MoveSpeed = 0;
                    fpc.SprintSpeed = 0;
                }
                else
                {
                    isOnTrain = false;
                    other.transform.parent = null;
                    //other.transform.position = dropPlayerPos.position;
                    other.gameObject.GetComponent<CharacterController>().enabled = true;
                    var fpc = other.gameObject.GetComponent<FirstPersonController>();
                    fpc.MoveSpeed = resetMoveSpeed;
                    fpc.SprintSpeed = resetSprintSpeed;
                }
            }

            if (isOnTrain)
            {
                other.transform.localPosition = Vector3.zero;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inputText.gameObject.SetActive(false);
        }
    }

    IEnumerator BoardingBuffer()
    {
        yield return new WaitForSeconds(0.2f);

        isOnTrain = true;

        isBoarding = false;
    }

}
