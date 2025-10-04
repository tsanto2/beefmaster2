using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedTransitioner : MonoBehaviour
{

    [SerializeField]
    private string sceneToLoad;

    [SerializeField]
    private float transitionTime;

    void Start()
    {
        StartCoroutine(StartTransition());
    }

    IEnumerator StartTransition()
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneToLoad);
    }

}
