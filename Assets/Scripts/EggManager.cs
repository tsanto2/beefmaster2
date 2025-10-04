using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggManager : MonoBehaviour
{

    private ChallengeManager cm;

    [SerializeField]
    private List<GameObject> eggPrefabs, cowPrefabs;

    [SerializeField]
    private List<Transform> eggSpawnPositions, cowSpawnPositions;

    [SerializeField]
    private List<int> EggTypeList = new List<int>();

    [SerializeField]
    private List<int> EggProgressList = new List<int>();

    [SerializeField]
    private List<int> CowTypeList = new List<int>();

    private int eggsSpawned = 0;
    private int cowsSpawned = 0;

    void Start()
    {
        cm = FindObjectOfType<ChallengeManager>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        CheckEggs();
        CheckCows();
    }

    private void CheckEggs()
    {
        foreach (char egg in PlayerPrefs.GetString("EggsOwned" + cm.masterSlot, ""))
        {
            EggTypeList.Add(Convert.ToInt32(Char.GetNumericValue(egg)));
        }

        foreach (int egg in EggTypeList)
        {
            //Debug.Log("Egg" + i.ToString() + ": " + egg.ToString());
        }

        foreach (char egg in PlayerPrefs.GetString("EggsOwnedProgress" + cm.masterSlot, ""))
        {
            EggProgressList.Add(Convert.ToInt32(Char.GetNumericValue(egg)));
        }

        var eggIndicesToRemove = new List<int>();

        for (int i = 0; i < EggProgressList.Count; i++)
        {
            if (EggProgressList[i] < 5)
            {
                SpawnEgg(EggTypeList[i], EggProgressList[i]);
            }
            else
            {
                int eggType = EggTypeList[i];
                eggIndicesToRemove.Add(i);
                EggTypeList.RemoveAt(i);
                EggProgressList.RemoveAt(i);

                PlayerPrefs.SetString("CowsOwned" + cm.masterSlot, PlayerPrefs.GetString("CowsOwned" + cm.masterSlot, "") + eggType.ToString());
                i--;
            }
        }

        foreach (int indice in eggIndicesToRemove)
        {
        }

        string newEggsOwnedList = "";
        foreach (int egg in EggTypeList)
        {
            newEggsOwnedList += egg.ToString();
        }
        PlayerPrefs.SetString("EggsOwned" + cm.masterSlot, newEggsOwnedList);

        string newEggsProgressList = "";
        foreach (int egg in EggProgressList)
        {
            newEggsProgressList += egg.ToString();
        }
        PlayerPrefs.SetString("EggsOwnedProgress" + cm.masterSlot, newEggsProgressList);
    }

    private void CheckCows()
    {
        foreach (char cow in PlayerPrefs.GetString("CowsOwned" + cm.masterSlot, ""))
        {
            CowTypeList.Add(Convert.ToInt32(Char.GetNumericValue(cow)));
        }

        foreach (int cow in CowTypeList)
        {
            SpawnCow(cow);
        }
    }

    private void SpawnEgg(int eggType, int eggProgress)
    {
        float progressScalar = eggProgress * 0.1f;

        GameObject newEgg = Instantiate(eggPrefabs[eggType], eggSpawnPositions[eggsSpawned].position, eggSpawnPositions[eggsSpawned].rotation);
        newEgg.transform.localScale = new Vector3(0.5f + progressScalar, 0.5f + progressScalar, 0.5f + progressScalar);

        eggsSpawned++;
    }

    private void SpawnCow(int cowType)
    {
        Debug.Log("Cow Type Spawning: " + cowType);
        GameObject newCow = Instantiate(cowPrefabs[cowType], cowSpawnPositions[cowsSpawned].position, cowSpawnPositions[cowsSpawned].rotation);

        cowsSpawned++;
    }
}

public enum EggType
{
    Brown,
    Ice,
    Green,
    Purple,
}
