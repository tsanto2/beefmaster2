using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCamSwitcher : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cam1, cam2;

    private CinemachineBrain brainz;

    // Start is called before the first frame update
    void Start()
    {
        brainz = FindObjectOfType<CinemachineBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (brainz.ActiveVirtualCamera == cam1)
            {
                cam1.Priority = 0;
                cam2.Priority = 10;
            }
            else
            {
                cam1.Priority = 10;
                cam2.Priority = 0;
            }
        }
    }
}
