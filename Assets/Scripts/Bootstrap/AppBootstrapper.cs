using UnityEngine;
using System;

public class AppBootstrapper : MonoBehaviour
{
    public SolarSystemConfig config;

    public PlanetView[] planets;

    public TimeController timeController;

    TimeModel timeModel;
    PlanetSystemController controller;

    public FocusController focusController;


    void Start()
    {
        Debug.Log("[BOOT] Initializing application");

        timeModel = new TimeModel();

        var ephemeris = new PlanetEphemerisService();

        controller = new PlanetSystemController(
            timeModel,
            ephemeris,
            planets,
            config
        );

        timeModel.SetTime(DateTime.Now);

        timeController.Init(timeModel);

        focusController.Init(timeModel);
    }
}
