using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    [SerializeField]
    private UnveilGreatly unveiler;

    [SerializeField]
    private bool changeSceneWithClick, changeSceneWithTimer, stopAllAudio;

    [SerializeField]
    private float transitionTime;

    [SerializeField]
    private string sceneToLoad, currentScene;

    private bool transitionInProgress;

    private void Start()
    {
        if (changeSceneWithTimer)
        {
            StartCoroutine(TransitionToNextScene(sceneToLoad));
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && !transitionInProgress && changeSceneWithClick)
        {
            transitionInProgress = true;

            StartCoroutine(TransitionToNextScene(sceneToLoad));
        }
    }

    public void BeginTransition(string sceneName)
    {
        StartCoroutine(TransitionToNextScene(sceneName));
    }

    IEnumerator TransitionToNextScene(string sceneName)
    {
        if (unveiler != null)
        {
            unveiler.PublicChangeVeiledNess();
        }

        if (stopAllAudio)
        {
            var audioSources = FindObjectsOfType<AudioSource>();

            foreach (AudioSource source in audioSources)
            {
                source.Stop();
            }
        }

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        FindObjectOfType<AdditiveSceneLoader>().CurrentlyAdditivedScene = sceneName;
        SceneManager.UnloadScene(currentScene);
    }

}
