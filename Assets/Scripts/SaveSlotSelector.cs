using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSlotSelector : MonoBehaviour
{

    public void SlotSelected(int slotNum)
    {
        FindObjectOfType<ChallengeManager>().masterSlot = slotNum;

        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Additive);
        FindObjectOfType<AdditiveSceneLoader>().CurrentlyAdditivedScene = "TitleScreen";
        SceneManager.UnloadScene("SaveSelection");
    }

}
