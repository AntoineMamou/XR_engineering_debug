using UnityEngine;
using TMPro;
using System;

public class PlanetInfoView : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI periodText;
    public TextMeshProUGUI timeText;

    public void ShowInfo(PlanetData.Planet planet, DateTime currentTime)
    {
        gameObject.SetActive(true);

        nameText.text = planet.ToString();

        float a = PlanetData.GetKeplerParameter(planet, PlanetData.KeplerParameter.a)[0];
        distanceText.text = $"Distance au soleil : {a:F2} UA";

        float periodYears = Mathf.Sqrt(Mathf.Pow(a, 3));
        periodText.text = $"Période orbitale : {periodYears:F2} ans";

        timeText.text = $"Temps simulé : {currentTime:dd/MM/yyyy}";
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}