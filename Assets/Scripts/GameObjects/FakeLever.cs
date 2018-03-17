using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLever : MonoBehaviour {

    [HideInInspector]
    public bool active;

    private Animator leverAnimator;

    public void Start()
    {
        active = false;
        leverAnimator = this.GetComponent<Animator>();

        leverAnimator.SetBool("Active", false);
    }

    public void ActivateLever()
    {
        active = true;
        leverAnimator.SetBool("Active", true);
    }

    internal void DisactiveLever()
    {
        active = false;
        leverAnimator.SetBool("Active", false);
    }
}
