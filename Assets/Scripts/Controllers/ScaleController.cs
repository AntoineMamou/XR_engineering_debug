using UnityEngine;

public class ScaleController : MonoBehaviour
{
    [Header("Target")]
    public Transform rootTransform;

    [Header("Limits")]
    public float minScale = 0.1f;
    public float maxScale = 3.0f;

    public void SetScale(float value)
    {
        Debug.Log($"[INPUT] Scale requested: {value}");

        // On vérifie si la valeur dépasse nos limites
        if (value < minScale || value > maxScale)
        {
            Debug.LogWarning("[WARN] Scale clamped");
            value = Mathf.Clamp(value, minScale, maxScale);
        }

        // On applique la nouvelle échelle sur les 3 axes (X, Y, Z)
        rootTransform.localScale = new Vector3(value, value, value);

        Debug.Log($"[XR] Scale applied: {value}");
    }
}