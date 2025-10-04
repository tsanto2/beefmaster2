using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckForCheatCodeInput : MonoBehaviour
{

    public static CheckForCheatCodeInput instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            Debug.Log("Cheat Code Time");
            SceneManager.LoadScene("CheatCodeTest", LoadSceneMode.Additive);
            SceneManager.UnloadScene(FindObjectOfType<AdditiveSceneLoader>().CurrentlyAdditivedScene);
            FindObjectOfType<AdditiveSceneLoader>().CurrentlyAdditivedScene = "CheatCodeTest";
        }
    }
}
