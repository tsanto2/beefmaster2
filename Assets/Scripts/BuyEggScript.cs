using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyEggScript : MonoBehaviour
{

    [SerializeField]
    private int eggIndex;

    public void EggClicked()
    {
        Debug.Log("Bought egg: " + eggIndex);
    }

}
