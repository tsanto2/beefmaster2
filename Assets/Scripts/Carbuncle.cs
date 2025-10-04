using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carbuncle : MonoBehaviour
{
    [SerializeField]
    AudioSource carbuncleSound;

    bool hasPlayed;

    public void PlayCarbuncle()
    {
        if (!hasPlayed)
        {
            hasPlayed = true;
            carbuncleSound.Play();
        }
    }

}
