using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementMiniCow : MonoBehaviour
{

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private SkinnedMeshRenderer skm;

    [SerializeField]
    private List<Material> mats;

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    public void SetMyMat()
    {
        var newMat = mats[Random.Range(0, mats.Count)];

        while (newMat == skm.material)
        {
            newMat = mats[Random.Range(0, mats.Count)];
        }

        skm.material = newMat;
    }
}
