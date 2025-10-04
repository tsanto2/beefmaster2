using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GlobalVolumeProfileChanger : MonoBehaviour
{
    [SerializeField]
    private VolumeProfile[] profiles;

    [SerializeField]
    private Volume gv;

    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            index++;
            if (index >= profiles.Length)
            {
                index = 0;
            }

            gv.profile = profiles[index];
        }
    }
}
