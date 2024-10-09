using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/*
    This script works on mimicking the grab & throw action. 
    To do that, I added Rigidbody & GrabInteractable components to the throwable objetcs.
    Here, I am just accessing the "XRGrabInteractable" and listening to "SelectEntered" and "SelectExited" events.
    
    When "SelectEntered" happens, Kinematics are stopped -> object is grabbed.
    When "SelectExited" happens, Kinematics are resumed -> object is throwed with a 500f force.
    
    I added this script for all rocks in my scene. 
*/

public class Throwable : MonoBehaviour
{
    public float throwForce = 500f; // The force applied when throwing
    private Rigidbody rb;
    private bool isGrabbed = false;
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        // get XRGrabInteractable from object
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        
        // Listen to Select Entered & Exited events
        grabInteractable.onSelectEntered.AddListener(GrabObject);
        grabInteractable.onSelectExited.AddListener(ThrowObject);
    }

    private void GrabObject(XRBaseInteractor interactor)
    /*  Mimic Object grabbing by disabling physics */
    {
        rb.isKinematic = true; 
        isGrabbed = true;
    }

    private void ThrowObject(XRBaseInteractor interactor)
    /*  Mimic Object throwing by enabling physics & applying force in forward direction  */
    {
        rb.isKinematic = false; 
        isGrabbed = false;

        // Apply a throw force in the direction of the controller
        Vector3 throwDirection = interactor.transform.forward; // Use the interactor's forward direction
        rb.AddForce(throwDirection * throwForce);
    }
}