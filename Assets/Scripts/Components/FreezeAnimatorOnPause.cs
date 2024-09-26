using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeAnimatorOnPause : PausableMonoBehaviour
{
    [SerializeField] private Animator animator;

    protected override void Pause()
    {
        animator.enabled = false;
    }

    protected override void UnPause()
    {
        animator.enabled = true;
    }
}
