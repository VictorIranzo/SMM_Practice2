using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Button : MonoBehaviour {

    private GameObject controlledObject;
    private bool active;

    private Animator objectAnimator;


    private void Start()
    {
        active = false;
        controlledObject = GameObject.FindGameObjectsWithTag("Tramp1").FirstOrDefault();
        objectAnimator = controlledObject.GetComponent<Animator>();
        objectAnimator.SetBool("ActiveTramp", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = !active;
        if (active)
        {
            this.GetComponent<AudioSource>().Play();
            PushedButton();
            Debug.Log("Pushed");
        }
        else
        {
            UnpushedButton();
            Debug.Log("Unpushed");
        }
    }

    public void UnpushedButton()
    {
        objectAnimator.SetBool("ActiveTramp", true);

        controlledObject.AddComponent<BoxCollider2D>();
    }

    internal void PushedButton()
    {
        // TODO: Review to do it generic for any GameObject.
        objectAnimator.SetBool("ActiveTramp", false);

        BoxCollider2D colliderObject = controlledObject.GetComponent<BoxCollider2D>();
        Destroy(colliderObject);
    }

}
