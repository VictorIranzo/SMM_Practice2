using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lever : MonoBehaviour {

    private GameObject controlledObject;

    [HideInInspector]
    public bool active;

    private Animator leverAnimator;
    private Animator objectAnimator;

    public void Start()
    {
        active = false;
        leverAnimator = this.GetComponent<Animator>();

        leverAnimator.SetBool("Active", false);

        controlledObject = GameObject.FindGameObjectsWithTag("Tramp1").FirstOrDefault();
        objectAnimator = controlledObject.GetComponent<Animator>();
        objectAnimator.SetBool("ActiveTramp", true);
    }

    public void ActivateLever() {
        active = true;
        leverAnimator.SetBool("Active",true);

        // TODO: Review to do it generic for any GameObject.
        objectAnimator.SetBool("ActiveTramp",false);

        BoxCollider2D colliderObject = controlledObject.GetComponent<BoxCollider2D>();
        Destroy(colliderObject);
    }

    internal void DisactiveLever()
    {
        active = false;
        leverAnimator.SetBool("Active", false);

        // TODO: Review to do it generic for any GameObject.
        objectAnimator.SetBool("ActiveTramp", true);

        controlledObject.AddComponent<BoxCollider2D>();
    }
}
