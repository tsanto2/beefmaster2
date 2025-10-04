using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForSphereToBringDownFarmhouseOnPillar : MonoBehaviour
{
    [SerializeField]
    private AudioSource rumbler;
    [SerializeField]
    private GameObject tower;
    [SerializeField]
    private float bringEmDownSpeed, rotateSpeed;
    [SerializeField]
    private float bringEmDownHeight;

    bool activatorInSlot;
    bool hasActivated;
    bool doneRumblin;
    GameObject activator = null;

    private void Update()
    {
        if (activatorInSlot && activator != null && !hasActivated)
        {
            if (Vector3.Distance(activator.GetComponent<Rigidbody>().velocity.normalized, Vector3.zero) < 0.8f)
            {
                hasActivated = true;
                Debug.Log("Activating!");
                rumbler.Play();
                StartCoroutine(BringEmDownBoys());
            }
        }

        if (doneRumblin)
        {
            rumbler.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Activator")
        {
            activatorInSlot = true;
            activator = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            activatorInSlot = false;
            activator = null;
        }
    }

    IEnumerator BringEmDownBoys()
    {
        Vector3 targetPos = new Vector3(tower.transform.position.x, bringEmDownHeight, tower.transform.position.z);

        while (Vector3.Distance(tower.transform.position, targetPos) > .2f)
        {
            tower.transform.position = Vector3.MoveTowards(tower.transform.position, targetPos, bringEmDownSpeed * Time.deltaTime);
            tower.transform.RotateAround(Vector3.up, Time.deltaTime * rotateSpeed);

            yield return new WaitForEndOfFrame();
        }

        doneRumblin = true;
    }

}
