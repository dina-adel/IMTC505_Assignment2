using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Throwable : MonoBehaviour
{
    public float throwForce = 500f; // The force applied when throwing
    private Rigidbody rb;
    private bool isGrabbed = false;
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        
        // Register the events
        grabInteractable.onSelectEntered.AddListener(GrabObject);
        grabInteractable.onSelectExited.AddListener(ThrowObject);
    }

    private void GrabObject(XRBaseInteractor interactor)
    {
        rb.isKinematic = true; // Disable physics while grabbed
        isGrabbed = true;
    }

    private void ThrowObject(XRBaseInteractor interactor)
    {
        rb.isKinematic = false; // Enable physics
        isGrabbed = false;

        // Apply a throw force in the direction of the controller
        Vector3 throwDirection = interactor.transform.forward; // Use the interactor's forward direction
        rb.AddForce(throwDirection * throwForce);
    }
}