using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private CubeFirer cubeFirer;

    [SerializeField]
    private UIController uiController;

    [SerializeField]
    private float playTime;

    [SerializeField]
    private TextMeshProUGUI scoreValue;
    [SerializeField]
    private TextMeshProUGUI moneyValue;

    [SerializeField]
    private Camera theCamera;
    [SerializeField]
    private RenderTexture resultsTexture;

    [SerializeField]
    private Transform cowAss;

    private BonusBlast bb;

    private ChallengeManager cm;

    private void Start()
    {
        bb = FindObjectOfType<BonusBlast>();
        cm = FindObjectOfType<ChallengeManager>();

        StartCoroutine(BeginDay());
    }

    private void Update()
    {
        scoreValue.text = PlayerPrefs.GetInt("TotalChomped" + cm.masterSlot, 0).ToString();
        moneyValue.text = PlayerPrefs.GetInt("CashMoney" + cm.masterSlot, 0).ToString();

        cowAss.localScale = new Vector3(1, 1 + bb.slider.value, 1);

        if (bb.slider.value == 1)
        {
            cubeFirer.currentMinWaitTime = cubeFirer.hyperMinWaitTime;
            cubeFirer.currentMaxWaitTime = cubeFirer.hyperMaxWaitTime;
        }
        else
        {
            cubeFirer.currentMinWaitTime = cubeFirer.defaultMinWaitTime;
            cubeFirer.currentMaxWaitTime = cubeFirer.defaultMaxWaitTime;
        }
    }

    public void StopCubeFirer()
    {
        cubeFirer.gameObject.SetActive(false);
    }
    public void StartCubeFirer()
    {
        cubeFirer.gameObject.SetActive(true);
        cubeFirer.StartCubeFirer();
    }

    public void IncreaseScore(int increaseAmount)
    {
        bb.BoostBonusBlast();
        PlayerPrefs.SetInt("TotalChomped" + cm.masterSlot, PlayerPrefs.GetInt("TotalChomped" + cm.masterSlot, 0) + 1);
        PlayerPrefs.SetInt("CashMoney" + cm.masterSlot, PlayerPrefs.GetInt("CashMoney" + cm.masterSlot, 0) + 10);
    }

    void EndDay()
    {
        var dpm = FindObjectOfType<DayProgressManager>();
        if (dpm != null)
        {
            dpm.UpdateDay(dpm.currentDay + 1);
        }
        SceneManager.LoadScene("ResultsScreen", LoadSceneMode.Additive);
        FindObjectOfType<AdditiveSceneLoader>().CurrentlyAdditivedScene = "ResultsScreen";
        SceneManager.UnloadScene("GameplayScene");
    }

    IEnumerator BeginDay()
    {
        yield return new WaitForSeconds(playTime);

        theCamera.targetTexture = resultsTexture;
        yield return new WaitForSeconds(.1f);

        EndDay();
    }

}
