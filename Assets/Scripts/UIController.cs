using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField]
    private GameObject MainMenu, CamoMenu, AchievementUnlocked, AchievementMiniCow;

    [SerializeField]
    private List<GameObject> gameplayUIElements;

    [SerializeField]
    private TextMeshProUGUI challengeCompleteText;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private AchievementMiniCow amc;

    public void PlayButtonClicked()
    {
        MainMenu.SetActive(false);
        CamoMenu.SetActive(false);
    }

    public void GameplayEnded()
    {
        MainMenu.SetActive(true);
        CamoMenu.SetActive(false);
    }

    public void MainMenuClicked()
    {
        MainMenu.SetActive(true);
        CamoMenu.SetActive(false);
    }

    public void HideGameplayUI()
    {
        gameManager.StopCubeFirer();

        foreach(GameObject go in gameplayUIElements)
        {
            go.SetActive(false);
        }
    }

    public void ShowGameplayUI()
    {
        gameManager.StartCubeFirer();

        foreach (GameObject go in gameplayUIElements)
        {
            go.SetActive(true);
        }
    }

    public void CamoMenuClicked()
    {
        MainMenu.SetActive(false);
        CamoMenu.SetActive(true);
    }

    public void DisplayAchievementUnlocked(string achievementText)
    {
        AchievementUnlocked.SetActive(true);
        challengeCompleteText.text = achievementText;
        AchievementMiniCow.SetActive(true);
        amc.SetMyMat();
    }

    public void HideAchievmentUnlocked()
    {
        AchievementUnlocked.SetActive(false);
        AchievementMiniCow.SetActive(false);
    }

}
