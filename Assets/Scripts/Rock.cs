using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    public float speed = 2.0f;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidBody = hit.collider.attachedRigidbody;

        if (rigidBody == null || rigidBody.isKinematic) return;

        Vector2 pushVector = new Vector2(hit.moveDirection.x, hit.moveDirection.y);

        this.transform.position = new Vector3(hit.moveDirection.x*speed, hit.moveDirection.y*speed, 0);
    }

    internal void Move(int xDir, int yDir)
    {
        //this.transform.position = this.transform.position + new Vector3(xDir,yDir,0);

        Rigidbody2D rigidbody = this.GetComponent<Rigidbody2D>();
        rigidbody.AddForceAtPosition(new Vector3(xDir, yDir),new Vector2(this.transform.position.x,this.transform.position.y));
    }
}
