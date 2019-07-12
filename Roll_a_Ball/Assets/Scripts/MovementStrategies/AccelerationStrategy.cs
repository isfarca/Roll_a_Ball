using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationStrategy : PlayerController
{
    public override void Start()
    {
        base.Start();

        speed = 1000;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        // Player movement in mobile devices.
        // Building of force vector.
        Vector3 mobileMovement = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);
        // Adding force to rigidbody.
        rb.AddForce(mobileMovement * speed * Time.deltaTime);
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