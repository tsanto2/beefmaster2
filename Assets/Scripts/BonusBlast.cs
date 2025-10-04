using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusBlast : MonoBehaviour
{

    [SerializeField]
    public Slider slider;

    [SerializeField]
    private float updateTime, decayTime;

    Coroutine BonusBlastDecay = null;

    [SerializeField]
    private AudioSource hyperSFX;

    [SerializeField]
    private GameObject hyperText;

    private void Start()
    {
        StartCoroutine(SlideTime());
    }

    public void BoostBonusBlast()
    {
        if (slider.value < 1)
        {
            slider.value += .15f;

            if (slider.value >= 1)
            {
                hyperSFX.Play();
                hyperText.SetActive(true);

                if (BonusBlastDecay == null)
                {
                    BonusBlastDecay = StartCoroutine(BonusBlastDecayRoutine());
                }
                else
                {
                    StopCoroutine(BonusBlastDecay);
                    BonusBlastDecay = StartCoroutine(BonusBlastDecayRoutine());
                }
            }
        }
        else
        {
            if (BonusBlastDecay == null)
            {
                BonusBlastDecay = StartCoroutine(BonusBlastDecayRoutine());
            }
            else
            {
                StopCoroutine(BonusBlastDecay);
                BonusBlastDecay = StartCoroutine(BonusBlastDecayRoutine());
            }
        }
    }

    private IEnumerator SlideTime()
    {
        yield return new WaitForSeconds(updateTime);

        if (slider.value > 0 && slider.value < 1)
        {
            slider.value -= 0.03f;
        }

        StartCoroutine(SlideTime());
    }

    private IEnumerator BonusBlastDecayRoutine()
    {
        yield return new WaitForSeconds(decayTime);

        slider.value = 0f;
        hyperText.SetActive(false);
    }

}
