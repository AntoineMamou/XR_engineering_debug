using UnityEngine;
using System;

public class FocusController : MonoBehaviour
{
    public PlanetInfoView infoView;

    private TimeModel timeModel;
    private PlanetView activePlanet;

    public void Init(TimeModel model)
    {
        this.timeModel = model;
        PlanetSelectable.OnPlanetSelected += HandlePlanetSelected;

        infoView.Hide();
    }

    void OnDestroy()
    {
        PlanetSelectable.OnPlanetSelected -= HandlePlanetSelected;
    }

    private void HandlePlanetSelected(PlanetView planetView)
    {
        activePlanet = planetView;
        Debug.Log($"[FOCUS] Focusing on {planetView.planet}");

        infoView.ShowInfo(activePlanet.planet, timeModel.CurrentTime);
    }

    void Update()
    {
        if (activePlanet != null && infoView.gameObject.activeSelf && timeModel != null)
        {
            
            infoView.ShowInfo(activePlanet.planet, timeModel.CurrentTime);

            infoView.transform.position = activePlanet.transform.position + Vector3.up * 0.15f;
            infoView.transform.LookAt(Camera.main.transform);
            infoView.transform.Rotate(0, 180, 0);
        }
    }
}