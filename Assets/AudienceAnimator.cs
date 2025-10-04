using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceAnimator : MonoBehaviour
{
    Animation anim;

    [SerializeField]
    AnimationClip[] animClips;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();

        anim.Play(animClips[Random.Range(0, animClips.Length)].name);
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.isPlaying)
        {
            anim.PlayQueued(animClips[Random.Range(0, animClips.Length)].name);
        }
    }
}
