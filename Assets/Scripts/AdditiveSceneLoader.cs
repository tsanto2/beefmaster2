using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveSceneLoader : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    public string CurrentlyAdditivedScene;

    void Start()
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
        CurrentlyAdditivedScene = sceneToLoad;
    }
}
