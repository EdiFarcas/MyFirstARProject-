using System.Collections;
using UnityEngine;

public class TargetFeedback : MonoBehaviour
{
    public Renderer targetRenderer;
    public Color hitColor = Color.green;
    public float flashDuration = 0.2f;

    private Color originalColor;

    void Start()
    {
        originalColor = targetRenderer.material.color;
    }

    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        targetRenderer.material.color = hitColor;

        yield return new WaitForSeconds(flashDuration);

        targetRenderer.material.color = originalColor;
    }
}