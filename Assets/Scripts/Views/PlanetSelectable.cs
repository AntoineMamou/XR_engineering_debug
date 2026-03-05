using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


[RequireComponent(typeof(XRSimpleInteractable))]
public class PlanetSelectable : MonoBehaviour
{
    public static event Action<PlanetView> OnPlanetSelected;

    public PlanetView planetView;
    private XRSimpleInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
    }

    void OnEnable()
    {
        interactable.selectEntered.AddListener(OnSelect);
    }

    void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnSelect);
    }

    void OnSelect(SelectEnterEventArgs args)
    {
        Debug.Log($"[XR] Planet selected: {planetView.planet}");

        OnPlanetSelected?.Invoke(planetView);
    }
}