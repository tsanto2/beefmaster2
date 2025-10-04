using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDataButton : MonoBehaviour
{

    public void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }

}
