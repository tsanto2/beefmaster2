using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetDailyMessage : MonoBehaviour
{

    [SerializeField]
    private DailyMessageSO dailyMessageObj;

    [SerializeField]
    private TextMeshProUGUI dayText, messageText;

    private ChallengeManager cm;

    private void Start()
    {
        cm = FindObjectOfType<ChallengeManager>();

        int day = PlayerPrefs.GetInt("CurrentDay" + cm.masterSlot, 1);
        dayText.text = "Day " + day.ToString();

        messageText.text = "Don't let the herd down.";

        if (dailyMessageObj.messages[day-1] != null)
        {
            messageText.text = dailyMessageObj.messages[day - 1];
        }
    }

}
