using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebcamWatcher : MonoBehaviour
{

    [SerializeField]
    private RawImage textureDisplay;

    [SerializeField]
    private WebCamDevice[] devices;

    [SerializeField]
    private WebCamTexture camTexture;

    [SerializeField]
    private MeshRenderer[] mrs;

    [SerializeField]
    private float minStutterTime, maxStutterTime, minPauseTime, maxPauseTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckCam());
    }

    IEnumerator CheckCam()
    {
        /*yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Debug.Log("webcam found");
            devices = WebCamTexture.devices;
            for (int cameraIndex = 0; cameraIndex < devices.Length; ++cameraIndex)
            {
                Debug.Log("devices[cameraIndex].name: ");
                Debug.Log(devices[cameraIndex].name);
                Debug.Log("devices[cameraIndex].isFrontFacing");
                Debug.Log(devices[cameraIndex].isFrontFacing);
            }
        }
        else
        {
            Debug.Log("no webcams found");
        }

        if (WebCamTexture.devices.Length > 0)
        {
            WebCamDevice device = WebCamTexture.devices[0];
            camTexture = new WebCamTexture(device.name);
            textureDisplay.texture = camTexture;
            textureDisplay.material.mainTexture = camTexture;
            foreach (MeshRenderer mr in mrs)
            {
                mr.material.mainTexture = camTexture;
            }

            camTexture.Play();
            Debug.LogError(device.name);
        }

        StartCoroutine(StutterCam());*/

        yield return new WaitForEndOfFrame();
    }

    IEnumerator StutterCam()
    {
        yield return new WaitForSeconds(Random.Range(minStutterTime, maxStutterTime));

        if (camTexture.isPlaying)
            camTexture.Pause();

        yield return new WaitForSeconds(Random.Range(minPauseTime, maxPauseTime));

        camTexture.Play();

        StartCoroutine(StutterCam());
    }

}
