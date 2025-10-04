using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField]
    private GameObject mainMenu;

    private UIController uiController;

    private ShopInfoHandler sih;

    private void Start()
    {
        uiController = FindObjectOfType<UIController>();
        sih = FindObjectOfType<ShopInfoHandler>();
    }

    public void OpenMainMenu()
    {
        if (!mainMenu.activeInHierarchy)
        {
            mainMenu.SetActive(true);

            sih.PopulateShoppe();

            uiController.HideGameplayUI();
        }
    }

    public void CloseMainMenu()
    {
        mainMenu.SetActive(false);

        uiController.ShowGameplayUI();
    }

}
