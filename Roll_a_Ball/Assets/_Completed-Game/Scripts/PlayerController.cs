using System;
using UnityEngine;
using UnityEngine.UI;

public enum ControlTypes
{
	AccelerationControl,
	KeyboardControl,
	TouchControl
}

public class PlayerController : MonoBehaviour
{
	// Create public variables for player speed, and for the Text UI game objects
	public Text countText;
	public Text winText;

	// Create private references to the rigid body component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private int count;

    [SerializeField] private float speed;

    [SerializeField] private ControlTypes controlType = ControlTypes.AccelerationControl;
    private IControl iControl;

    public void HandleControl()
    {
	    var c = gameObject.GetComponent<IControl>() as Component;

	    if (c != null)
	    {
		    Destroy(c);
	    }
	    
	    switch (controlType)
	    {
		    case ControlTypes.AccelerationControl:
			    iControl = gameObject.AddComponent<AccelerationControl>();
			    break;
		    case ControlTypes.KeyboardControl:
			    iControl = gameObject.AddComponent<KeyboardControl>();
			    break;
		    case ControlTypes.TouchControl:
			    iControl = gameObject.AddComponent<TouchControl>();
			    break;
		    default:
			    throw new ArgumentOutOfRangeException();
	    }
    }

    public void Input()
    {
	    iControl.Interact(rb, speed);
    }

    // At the start of the game..
    public void Start()
	{
		// Assign the Rigid body component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		// Run the SetCountText function to update the UI (see below)
		SetCountText();

		// Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winText.text = "";

		HandleControl();
	}

    // Each physics step..
    public void FixedUpdate()
    {
	    Input();
    }

    // When this game object intersects a collider with 'is trigger' checked, 
    // store a reference to that collider in a variable named 'other'..
    public void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
		}
	}

	// Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
	public void SetCountText()
	{
		// Update the text field of our 'countText' variable
		countText.text = "Count: " + count.ToString ();

		// Check if our 'count' is equal to or exceeded 12
		if (count >= 12) 
		{
			// Set the text value of our 'winText'
			winText.text = "You Win!";
		}
	}
}