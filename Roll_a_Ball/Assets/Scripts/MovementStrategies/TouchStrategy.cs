using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchStrategy : PlayerController
{
    public override void Start()
    {
        base.Start();

        speed = 50;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        // Player in mobile devices.
        float slowDown = 0.01f;
        Vector3 dragMovement = Input.GetTouch(0).deltaPosition * slowDown;
        Vector3 movementTouch = new Vector3(dragMovement.x, 0.0f, dragMovement.y);
        rb.AddForce(movementTouch * speed);
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    public override void SetCountText()
    {
        base.SetCountText();
    }
}