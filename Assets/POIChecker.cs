using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POIChecker : MonoBehaviour
{
    [SerializeField]
    private AudioSource poiAudio;

    GameObject currentPOITextObject;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.tag == "POI")
            {
                currentPOITextObject = hit.transform.gameObject.GetComponent<POI>().PoiTextObject;
                currentPOITextObject.SetActive(true);
                //Debug.Log("Playing Audio");
                //poiAudio.Play();
            }
            else
            {
                if (currentPOITextObject != null)
                {
                    currentPOITextObject.SetActive(false);
                    currentPOITextObject = null;
                }
            }
        }
    }
}
