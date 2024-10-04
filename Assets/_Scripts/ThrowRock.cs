using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;


public class ThrowRock : MonoBehaviour
{
    public float throwForce = 500f; // The force applied when throwing
    private Rigidbody rb;
    private bool isGrabbed = false;
    private void Start()  
        
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Simple input check for grabbing and throwing (adjust for VR controllers)
        if (Input.GetMouseButtonDown(0)) // Grab with left mouse button (or replace with VR grab input)
        {
            GrabObject();
        }
        else if (Input.GetMouseButtonUp(0)) // Release with left mouse button
        {
            ThrowObject();
        }
    }

    private void GrabObject()
    {
        if (!isGrabbed)
        {
            // Disable physics while grabbing
            rb.isKinematic = true;
            isGrabbed = true;
            // Optionally, move the object to your hand or controller position
        }
    }

    private void ThrowObject()
    {
        if (isGrabbed)
        {
            // Re-enable physics
            rb.isKinematic = false;
            isGrabbed = false;

            // Apply a forward throw force (customize this based on your controller/camera orientation)
            rb.AddForce(transform.forward * throwForce);
        }
    }
}
