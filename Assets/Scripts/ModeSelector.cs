using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour
{

    [SerializeField]
    private GameMode gameModeType;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SelectMode()
    {
        switch (gameModeType)
        {
            case GameMode.Gameplay:
                SceneManager.LoadScene("CharacterSelect");
                break;
            case GameMode.CaoGarden:
                SceneManager.LoadScene("CaoGarden");
                break;
            case GameMode.CodeEntry:
                SceneManager.LoadScene("CheatCodeTest");
                break;
            default:
                SceneManager.LoadScene("CharacterSelect");
                break;
        }
    }

}

public enum GameMode
{
    Gameplay,
    CaoGarden,
    CodeEntry,
}
