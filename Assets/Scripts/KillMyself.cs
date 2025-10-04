using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMyself : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KillMe());
    }

    private IEnumerator KillMe()
    {
        yield return new WaitForSeconds(2.0f);

        Destroy(gameObject);
    }

}
