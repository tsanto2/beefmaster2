using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeManager : MonoBehaviour
{
    [SerializeField]
    public int masterSlot=1;

    [SerializeField]
    private bool clearPrefsOnPlay;

    [SerializeField]
    private AudioSource achievementUnlockedAudio;

    [SerializeField]
    private float achievementUnlockedDuration;

    private UIController uiController;

    public static ChallengeManager instance;

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

        if (clearPrefsOnPlay)
        {
            PlayerPrefs.DeleteAll();
        }
    }

    private void Start()
    {

        if (PlayerPrefs.GetInt("HasPlayed", 0) == 0)
        {
            PlayerPrefs.SetInt("HasPlayed", 1);
        }

        uiController = FindObjectOfType<UIController>();
    }

    private void Update()
    {
        CheckAchievements();
    }

    private void CheckAchievements()
    {
        var totalChomped = PlayerPrefs.GetInt("TotalChomped" + masterSlot, 0);

        if (totalChomped >= 10 && PlayerPrefs.GetInt("Achieved10Chomped" + masterSlot, 0) == 0)
        {
            PlayerPrefs.SetInt("Achieved10Chomped"+masterSlot, 1);
            PlayerPrefs.SetInt("BlackCowSkinUnlocked" + masterSlot, 1);
            UnlockAchievement("10 Chomped, new skin unlocked.");
        }
        if (totalChomped >= 20 && PlayerPrefs.GetInt("Achieved20Chomped" + masterSlot, 0) == 0)
        {
            PlayerPrefs.SetInt("Achieved20Chomped" + masterSlot, 1);
            PlayerPrefs.SetInt("MrWhiteUnlocked" + masterSlot, 1);
            UnlockAchievement("20 Chomped, new skin unlocked.");
        }
        if (totalChomped >= 30 && PlayerPrefs.GetInt("Achieved30Chomped" + masterSlot, 0) == 0)
        {
            PlayerPrefs.SetInt("Achieved30Chomped" + masterSlot, 1);
            PlayerPrefs.SetInt("BeigeCowSkinUnlocked" + masterSlot, 1);
            UnlockAchievement("30 Chomped, new skin unlocked.");
        }
        if (totalChomped >= 40 && PlayerPrefs.GetInt("Achieved40Chomped" + masterSlot, 0) == 0)
        {
            PlayerPrefs.SetInt("Achieved40Chomped" + masterSlot, 1);
            PlayerPrefs.SetInt("JadeCowSkinUnlocked" + masterSlot, 1);
            UnlockAchievement("40 Chomped, new skin unlocked.");
        }
        if (totalChomped >= 50 && PlayerPrefs.GetInt("Achieved50Chomped" + masterSlot, 0) == 0)
        {
            PlayerPrefs.SetInt("Achieved50Chomped" + masterSlot, 1);
            UnlockAchievement("50 Chomped, new skin unlocked.");
        }
        if (totalChomped >= 100 && PlayerPrefs.GetInt("Achieved100Chomped" + masterSlot, 0) == 0)
        {
            PlayerPrefs.SetInt("Achieved100Chomped" + masterSlot, 1);
            UnlockAchievement("100 Chomped, new skin unlocked.");
        }

    }

    private void UnlockAchievement(string achievementText)
    {
        achievementUnlockedAudio.Play();
        FindObjectOfType<UIController>().DisplayAchievementUnlocked(achievementText);
        StartCoroutine(DisplayAchievement());
    }

    private IEnumerator DisplayAchievement()
    {
        yield return new WaitForSeconds(achievementUnlockedDuration);

        FindObjectOfType<UIController>().HideAchievmentUnlocked();
    }
}
