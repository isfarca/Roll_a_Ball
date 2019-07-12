using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardStrategy : PlayerController
{
    public override void Start()
    {
        base.Start();

        speed = 1000;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        // Player movement in desktop devices.
        // Definition of force vector X and Y components.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // Building of force vector.
        Vector3 desktopMovement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        // Adding force to rigidbody.
        rb.AddForce(desktopMovement * speed * Time.deltaTime);
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