using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker9000 : MonoBehaviour
{
    [SerializeField]
    private MultiLiner BEEFMASTERLiner, bibbyRichLiner;

    [SerializeField]
    private string bibbyLinerTextRich;

    [SerializeField]
    private MoneyManager mm;

    [SerializeField]
    private GameObject bull, bibbyBroke, bibbyRich, manholeClosed, manholeOpen;

    [SerializeField]
    private Transform bullLocationTwo;

    [SerializeField]
    private Material daySkybox, nightSkybox;

    public bool isNight, hasMovedBull, hasMadeMoney, bibbyCanMoveManhole, hasMovedManhole;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (BEEFMASTERLiner.HasCompletedFullDialogue && !hasMovedBull)
        {
            hasMovedBull = true;
            bull.transform.position = bullLocationTwo.position;
        }

        if (mm.money > 0)
        {
            if (!hasMadeMoney)
            {
                hasMadeMoney = true;

                bibbyBroke.SetActive(false);
                bibbyRich.SetActive(true);
            }

            if (bibbyRichLiner.HasCompletedFullDialogue)
            {
                bibbyCanMoveManhole = true;
            }
        }
        
        if (isNight)
        {
            if (bibbyBroke.activeInHierarchy)
                bibbyBroke.SetActive(false);
            if (bibbyRich.activeInHierarchy)
                bibbyRich.SetActive(false);
        }
        else
        {
            if (!bibbyBroke.activeInHierarchy && !hasMadeMoney)
                bibbyBroke.SetActive(true);
            else if (!bibbyRich.activeInHierarchy && hasMadeMoney)
                bibbyRich.SetActive(true);
        }

        if (bibbyCanMoveManhole && isNight)
        {
            if (!hasMovedManhole)
            {
                hasMovedManhole = true;
                manholeClosed.SetActive(false);
                manholeOpen.SetActive(true);
            }
        }
    }
}
