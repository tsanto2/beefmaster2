using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayProgressManager : MonoBehaviour
{

    public static DayProgressManager instance;

    private ChallengeManager cm;

    public int currentDay;

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

    private void Start()
    {
        cm = FindObjectOfType<ChallengeManager>();

        currentDay = PlayerPrefs.GetInt("CurrentDay" + cm.masterSlot, 1);
    }

    public void UpdateDay(int day)
    {
        currentDay = day;
        PlayerPrefs.SetInt("CurrentDay" + cm.masterSlot, day);

        if (day == 2 || day == 3 || day == 4)
        {
            UnlockEgg();
        }

        UpdateEggProgress();
    }

    void UnlockEgg()
    {
        int eggType = UnityEngine.Random.Range(0, 4);

        if (PlayerPrefs.GetString("EggsOwned" + cm.masterSlot, "") == "")
        {
            PlayerPrefs.SetString("EggsOwned" + cm.masterSlot, eggType.ToString());
        }
        else
        {
            PlayerPrefs.SetString("EggsOwned" + cm.masterSlot, PlayerPrefs.GetString("EggsOwned" + cm.masterSlot, "").ToString() + eggType.ToString());
        }

        PlayerPrefs.SetString("EggsOwnedProgress" + cm.masterSlot, PlayerPrefs.GetString("EggsOwnedProgress" + cm.masterSlot, "") + "0");
    }

    void UpdateEggProgress()
    {
        var EggProgressList = new List<int>();
        string newProgressList = "";

        foreach (char egg in PlayerPrefs.GetString("EggsOwnedProgress" + cm.masterSlot, ""))
        {
            EggProgressList.Add(Convert.ToInt32(Char.GetNumericValue(egg)));
        }

        foreach (int egg in EggProgressList)
        {
            var newEgg = egg + 1;
            newProgressList += newEgg.ToString();
        }

        PlayerPrefs.SetString("EggsOwnedProgress" + cm.masterSlot, newProgressList);
    }

}
