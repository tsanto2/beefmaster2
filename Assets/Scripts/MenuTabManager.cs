using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuTabManager : MonoBehaviour
{

    [SerializeField]
    private GameObject myMenu;

    [SerializeField]
    private TextMeshProUGUI myText;

    [SerializeField]
    private List<TextMeshProUGUI> otherTexts;

    [SerializeField]
    private Color selectedColor, unselectedColor;

    [SerializeField]
    private List<GameObject> otherMenus;

    public void OpenMyMenu()
    {
        myMenu.SetActive(true);

        foreach (GameObject go in otherMenus)
        {
            go.SetActive(false);
        }

        myText.color = selectedColor;

        foreach (TextMeshProUGUI text in otherTexts)
        {
            text.color = unselectedColor;
        }
    }


}
