using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPurchaseHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject purchasedImage;

    [SerializeField]
    public string itemName;

    [SerializeField]
    public int cost;

    private ShopInfoHandler sih;

    private void Start()
    {
        sih = FindObjectOfType<ShopInfoHandler>();
    }

    private void Update()
    {
        if (sih.PurchasedItems.Contains(itemName + "Purchased"))
        {
            purchasedImage.SetActive(true);
        }
    }

    public void ItemClicked()
    {
        if (PlayerPrefs.GetInt("CashMoney", 0) >= cost && !(PlayerPrefs.GetInt(itemName + "Purchased", 0) == 1))
        {
            PlayerPrefs.SetInt("CashMoney", PlayerPrefs.GetInt("CashMoney", 0) - cost);
            sih.PurchaseItem(itemName);
            purchasedImage.SetActive(true);
        }
        else
        {
            sih.FailedToBuyItem();
        }
    }

}
