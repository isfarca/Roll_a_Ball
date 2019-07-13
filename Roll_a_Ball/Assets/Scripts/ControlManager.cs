using UnityEngine;

public class ControlManager : MonoBehaviour
{
}

public interface IControl
{
    void Interact(Rigidbody rb, float speed);
}

public class AccelerationControl : MonoBehaviour, IControl
{
    public void Interact(Rigidbody rb, float speed) // Speed: 1000
    {
        // Building of force vector.
        var mobileMovement = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);
        // Adding force to rigid body.
        rb.AddForce(speed * Time.deltaTime * mobileMovement);
    }
}

public class KeyboardControl : MonoBehaviour, IControl
{
    public void Interact(Rigidbody rb, float speed) // Speed: 1000
    {
        // Definition of force vector X and Y components.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // Building of force vector.
        var desktopMovement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        // Adding force to rigid body.
        rb.AddForce(speed * Time.deltaTime * desktopMovement);
    }
}

public class TouchControl : MonoBehaviour, IControl
{
    public void Interact(Rigidbody rb, float speed) // Speed: 50
    {
        // Player in mobile devices.
        float slowDown = 0.01f;
        Vector3 dragMovement = Input.GetTouch(0).deltaPosition * slowDown;
        var movementTouch = new Vector3(dragMovement.x, 0.0f, dragMovement.y);
        rb.AddForce(movementTouch * speed);
    }
}