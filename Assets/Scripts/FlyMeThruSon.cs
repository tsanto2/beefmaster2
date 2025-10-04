using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMeThruSon : MonoBehaviour
{

    [SerializeField]
    private float flySpeed, lifetime;

    [SerializeField]
    private Vector3 flyDir;

    private void Start()
    {
        StartCoroutine(KillMeRoutine());
    }

    private void Update()
    {
        transform.Translate(flyDir * flySpeed * Time.deltaTime);
    }

    IEnumerator KillMeRoutine()
    {
        yield return new WaitForSeconds(lifetime);

        Destroy(gameObject);
    }

}
