using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TableGrabController : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;

    void OnEnable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
            grabInteractable.selectExited.AddListener(OnReleased);
        }
    }

    void OnDisable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
            grabInteractable.selectExited.RemoveListener(OnReleased);
        }
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        Debug.Log("[XR] Table grabbed");
    }

    void OnReleased(SelectExitEventArgs args)
    {
        Debug.Log("[XR] Table released");
    }
}