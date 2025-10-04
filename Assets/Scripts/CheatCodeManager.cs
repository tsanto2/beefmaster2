using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheatCodeManager : MonoBehaviour
{

    [SerializeField]
    private TMP_InputField cheatEntryField;

    [SerializeField]
    private bool deletePlayerPrefs;

    [SerializeField]
    private GameObject foodcounter;

    [SerializeField]
    private TextMeshProUGUI foodValue;

    private ChallengeManager cm;

    private void Start()
    {
        cm = FindObjectOfType<ChallengeManager>();

        cheatEntryField.onEndEdit.AddListener(delegate { CheckCode(cheatEntryField.text); });

        cheatEntryField.Select();

        if (deletePlayerPrefs)
            PlayerPrefs.DeleteAll();
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            cheatEntryField.Select();
        }

        if (PlayerPrefs.GetInt("cheesesteakjimmyentered"+ cm.masterSlot, 0) == 1)
        {
            foodcounter.SetActive(true);
        }

        foodValue.text = PlayerPrefs.GetInt("FoodAmount" + cm.masterSlot, 0).ToString();

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("CaoGarden", LoadSceneMode.Additive);
            SceneManager.UnloadScene("CheatCodeTest");
        }
    }

    private void CheckCode(string code)
    {
        cheatEntryField.text = "";

        code = code.ToLower();

        if (code == "close" || code == "quit")
        {
            SceneManager.LoadScene("TitleScreen");
        }
        if (code == "cheese steak jimmy's")
        {
            Debug.Log("1000 food granted.");
            PlayerPrefs.SetInt("cheesesteakjimmyentered" + cm.masterSlot, 1);
            PlayerPrefs.SetInt("FoodAmount" + cm.masterSlot, PlayerPrefs.GetInt("FoodAmount" + cm.masterSlot, 0) + 10000);
        }
        if (code == "hot dog")
        {
            // do something fun :)
        }
        if (code == "cleardata")
        {
            PlayerPrefs.DeleteAll();
        }

        EventSystem.current.SetSelectedGameObject(null);
        cheatEntryField.Select();
    }

}
