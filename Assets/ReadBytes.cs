using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ReadBytes : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPrefab;

    [SerializeField]
    private TextMeshProUGUI debugText;

    [SerializeField]
    private CowScanDataSO cowScanDataSO;

    [SerializeField]
    private GameObject cowScanObject;

    [SerializeField]
    private int byteCount = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void LoadFiles()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }

        Debug.Log(Application.dataPath);
        var folder = Directory.CreateDirectory(Application.dataPath + "/Bytes");

        var info = new DirectoryInfo(Application.dataPath + "/Bytes");
        var fileInfo = info.GetFiles();
        foreach (FileInfo file in fileInfo)
        {
            if (file.Name.Substring(file.Name.Length - 5) != ".meta")
            {
                GameObject newBtn = GameObject.Instantiate(buttonPrefab);
                newBtn.name = file.Name;
                newBtn.transform.parent = gameObject.transform;
                newBtn.transform.localScale = Vector3.one;
                newBtn.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }

    public void LoadBytes(string fileName)
    {
        foreach(Transform child in cowScanObject.transform)
        {
            Destroy(child.gameObject);
        }

        byte[] bytez = File.ReadAllBytes(Application.dataPath + "/Bytes/" + fileName);

        string byteString = "";
        for (int i = bytez.Length/2; i > bytez.Length/2-4; i--)
        {
            Debug.Log(bytez[i]);
            byteString += bytez[i] + " ";
        }
        debugText.text = (fileName + ": " + byteString);

        CowBuilder9000(bytez);
    }

    public void CowBuilder9000(byte[] bytez)
    {
        int step = 0;
        GameObject newGO = null;

        for (int i = bytez.Length / 2; i > bytez.Length / 2 - byteCount; i--)
        {
            switch (step)
            {
                case 0:
                    if (bytez[i] > 255 / byteCount)
                    {
                        newGO = Instantiate(cowScanDataSO.cowModels[0]);
                    }
                    else
                    {
                        newGO = Instantiate(cowScanDataSO.cowModels[1]);
                    }
                    newGO.transform.parent = cowScanObject.transform;
                    newGO.transform.localPosition = Vector3.zero;
                    newGO.transform.localScale = new Vector3(1, 1, 1);
                    newGO.transform.rotation = cowScanObject.transform.rotation;
                    step++;
                    break;
                case 1:
                    Material mat;
                    float chunkSize = 255 / cowScanDataSO.cowMats.Length;
                    int index = Mathf.RoundToInt(bytez[i] / chunkSize);
                    if (index > 0)
                    {
                        index--;
                    }
                    mat = cowScanDataSO.cowMats[index];
                    if (newGO != null)
                        newGO.GetComponentInChildren<SkinnedMeshRenderer>().material = mat;
                    step++;
                    break;
            }
        }
    }
}
