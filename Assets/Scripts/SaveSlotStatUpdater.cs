using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveSlotStatUpdater : MonoBehaviour
{

    [SerializeField]
    private StatType statType;

    [SerializeField]
    private int slotNum;

    private TextMeshProUGUI statValueText;

    public void Start()
    {
        statValueText = GetComponent<TextMeshProUGUI>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    private void Update()
    {
        UpdateMyStat();
    }

    void UpdateMyStat()
    {
        switch (statType)
        {
            case StatType.food:
                statValueText.text = PlayerPrefs.GetInt("FoodAmount" + slotNum, 0).ToString();
                break;
            case StatType.day:
                statValueText.text = PlayerPrefs.GetInt("CurrentDay" + slotNum, 1).ToString();
                break;
            case StatType.totalChomped:
                statValueText.text = PlayerPrefs.GetInt("TotalChomped" + slotNum, 0).ToString();
                break;
        }
    }

}

public enum StatType
{
    day,
    progress,
    food,
    totalChomped,
}
