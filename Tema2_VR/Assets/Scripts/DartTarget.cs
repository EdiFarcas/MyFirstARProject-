using UnityEngine;

public class DartTarget : MonoBehaviour
{
    public Transform center;

    public int GetScore(Vector3 hitPoint)
    {
        float distance = Vector3.Distance(hitPoint, center.position);

        if (distance <= 0.10f)
            return 100;

        if (distance <= 0.20f)
            return 50;

        if (distance <= 0.35f)
            return 25;

        return 10;
    }
}