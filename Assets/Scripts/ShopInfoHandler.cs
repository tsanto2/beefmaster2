using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInfoHandler : MonoBehaviour
{
    [SerializeField]
    public List<string> UnlockedItems, PurchasedItems;

    [SerializeField]
    private AudioSource purchasedItemSFX, cantAffordItemSFX;

    [SerializeField]
    private GameObject row1, row2;

    private void Update()
    {
        CheckPurchasedItems();
    }

    public void PopulateShoppe()
    {
        if (PlayerPrefs.GetInt("MrWhiteUnlocked", 0) == 1 && !row1.transform.Find("MrWhiteShopItem(Clone)"))
        {
            GameObject shopObj = Instantiate(Resources.Load("MrWhiteShopItem")) as GameObject;
            shopObj.transform.parent = row1.transform;
            shopObj.transform.localScale = new Vector3(1f, 1f, 1f);
            if (!UnlockedItems.Contains("MrWhite"))
                UnlockedItems.Add("MrWhite");
        }
        if (PlayerPrefs.GetInt("BlackCowSkinUnlocked", 0) == 1 && !row1.transform.Find("BlackCowSkinShopItem(Clone)"))
        {
            GameObject shopObj = Instantiate(Resources.Load("BlackCowSkinShopItem")) as GameObject;
            shopObj.transform.parent = row1.transform;
            shopObj.transform.localScale = new Vector3(1f, 1f, 1f);
            if (!UnlockedItems.Contains("BlackCowSkin"))
                UnlockedItems.Add("BlackCowSkin");
        }
        if (PlayerPrefs.GetInt("BeigeCowSkinUnlocked", 0) == 1 && !row1.transform.Find("BeigeCowSkinShopItem(Clone)"))
        {
            GameObject shopObj = Instantiate(Resources.Load("BeigeCowSkinShopItem")) as GameObject;
            shopObj.transform.parent = row1.transform;
            shopObj.transform.localScale = new Vector3(1f, 1f, 1f);
            if (!UnlockedItems.Contains("BeigeCowSkin"))
                UnlockedItems.Add("BeigeCowSkin");
        }
        if (PlayerPrefs.GetInt("JadeCowSkinUnlocked", 0) == 1 && !row1.transform.Find("JadeCowSkinShopItem(Clone)"))
        {
            GameObject shopObj = Instantiate(Resources.Load("JadeCowSkinShopItem")) as GameObject;
            shopObj.transform.parent = row1.transform;
            shopObj.transform.localScale = new Vector3(1f, 1f, 1f);
            if (!UnlockedItems.Contains("JadeCowSkin"))
                UnlockedItems.Add("JadeCowSkin");
        }
    }

    private void CheckPurchasedItems()
    {
        if (PlayerPrefs.GetInt("BlackCowSkinPurchased", 0) == 1 && !PurchasedItems.Contains("BlackCowSkinPurchased"))
        {
            PurchasedItems.Add("BlackCowSkinPurchased");
        }
        if (PlayerPrefs.GetInt("MrWhitePurchased", 0) == 1 && !PurchasedItems.Contains("MrWhitePurchased"))
        {
            PurchasedItems.Add("MrWhitePurchased");
        }
        if (PlayerPrefs.GetInt("BeigeCowSkinPurchased", 0) == 1 && !PurchasedItems.Contains("BeigeCowSkinPurchased"))
        {
            PurchasedItems.Add("BeigeCowSkinPurchased");
        }
        if (PlayerPrefs.GetInt("JadeCowSkinPurchased", 0) == 1 && !PurchasedItems.Contains("JadeCowSkinPurchased"))
        {
            PurchasedItems.Add("JadeCowSkinPurchased");
        }
    }

    public void PurchaseItem(string itemName)
    {
        PlayerPrefs.SetInt(itemName + "Purchased", 1);
        purchasedItemSFX.Play();
    }

    public void FailedToBuyItem()
    {
        cantAffordItemSFX.Play();
    }

}
