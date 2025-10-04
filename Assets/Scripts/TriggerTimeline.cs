using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerTimeline : MonoBehaviour
{
    [SerializeField]
    private bool isCollision, freezeMovement;

    [SerializeField]
    private string tagName;

    [SerializeField]
    private PlayableDirector playableDirector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagName)
        {
            playableDirector.Play();
        }

        if (freezeMovement)
        {
            FindObjectOfType<WalkerScript>().shouldNotWalk = true;
        }
    }
}
