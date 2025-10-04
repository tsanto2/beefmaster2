using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsToFlyThruSky : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> randomObjPrefabs;

    [SerializeField]
    private float flyTimeMin, flyTimeMax;

    private void Start()
    {
        StartCoroutine(FlyMySkies());
    }

    IEnumerator FlyMySkies()
    {
        yield return new WaitForSeconds(Random.Range(flyTimeMin, flyTimeMax));

        var myObj = randomObjPrefabs[Random.Range(0, randomObjPrefabs.Count)];

        Instantiate(myObj, transform.position, myObj.transform.rotation);

        StartCoroutine(FlyMySkies());
    }

}
