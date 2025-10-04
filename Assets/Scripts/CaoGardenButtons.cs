using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaoGardenButtons : MonoBehaviour
{

    ChallengeManager cm;

    private void Start()
    {
        cm = FindObjectOfType<ChallengeManager>();
    }

    public void QuestPressed()
    {
        SceneManager.LoadScene("CharacterSelect", LoadSceneMode.Additive);
        FindObjectOfType<AdditiveSceneLoader>().CurrentlyAdditivedScene = "CharacterSelect";
        UnloadCaoGarden();
    }

    public void GaragePressed()
    {
        SceneManager.LoadScene("CarCustomization", LoadSceneMode.Additive);
        FindObjectOfType<AdditiveSceneLoader>().CurrentlyAdditivedScene = "CarCustomization";
        UnloadCaoGarden();
    }

    public void CheatsPressed()
    {
        SceneManager.LoadScene("CheatCodeTest", LoadSceneMode.Additive);
        FindObjectOfType<AdditiveSceneLoader>().CurrentlyAdditivedScene = "CheatCodeTest";
        UnloadCaoGarden();
    }

    public void ShopPressed()
    {
        SceneManager.LoadScene("Shoppe", LoadSceneMode.Additive);
        FindObjectOfType<AdditiveSceneLoader>().CurrentlyAdditivedScene = "Shoppe";
        UnloadCaoGarden();
    }

    private void UnloadCaoGarden()
    {
        SceneManager.UnloadScene("CaoGarden");
    }

}
