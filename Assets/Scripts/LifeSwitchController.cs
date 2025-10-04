using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LifeSwitchController : MonoBehaviour
{
    private AdditiveSceneLoader sceneLoader;

    private bool hasBegunLifeSwitch;

    [SerializeField]
    private PlayableDirector playableDirector;

    private void Start()
    {
        sceneLoader = FindObjectOfType<AdditiveSceneLoader>();
    }

    private void Update()
    {
        if (DayProgressManager.instance != null)
        {
            if (DayProgressManager.instance.currentDay == 3 && sceneLoader.CurrentlyAdditivedScene == "ResultsScreen" && !hasBegunLifeSwitch)
            {
                hasBegunLifeSwitch = true;

                BeginLifeSwitch();
            }
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            hasBegunLifeSwitch = true;

            BeginLifeSwitch();
        }
    }

    private void BeginLifeSwitch()
    {
        playableDirector.Play();
        FindObjectOfType<FreeRoamPlayer>().CanMove = true;
    }
}
