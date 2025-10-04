using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RaceIntroCamManager : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera shot1cam1, shot1cam2, shot2cam1, shot2cam2, shot3cam1, shot3cam2;

    [SerializeField]
    private CinemachineVirtualCamera[] introCams;

    [SerializeField]
    private CinemachineBrain brain;

    [SerializeField]
    private float transitionTime, waitTime;

    [SerializeField]
    private AudioSource introTrack;

    void Start()
    {
        brain.m_DefaultBlend.m_Time = transitionTime;
        brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
        introCams[0].Priority = 1000000000;
        StartCoroutine(SwapIntroCams(1));
    }

    void CutToNextPair(int ind)
    {
        brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
        brain.m_DefaultBlend.m_Time = 0;
        introCams[ind - 1].Priority = 0;
        introCams[ind].Priority = 1000000000;
        StartCoroutine(SwapIntroCams(ind+1));
    }

    IEnumerator SwapIntroCams(int ind)
    {
        yield return new WaitForSeconds(0.05f);
        if (!introTrack.isPlaying)
            introTrack.Play();
        brain.m_DefaultBlend.m_Time = transitionTime;
        brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
        introCams[ind - 1].Priority = 0;
        introCams[ind].Priority = 1000000000;

        yield return new WaitForSeconds(transitionTime + waitTime);

        if (ind + 1 < 5)
        {
            CutToNextPair(ind + 1);
        }
        else
        {
            introCams[ind].Priority = 0;
            brain.m_DefaultBlend.m_Time = 1f;
            brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseIn;
        }

    }
}
