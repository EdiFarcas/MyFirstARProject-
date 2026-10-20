using System.Collections;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public ScoreManager scoreManager;
    public float resetDelay = 1.5f;

    private bool hasScored = false;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private Rigidbody rb;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y < -2f)
        {
            ResetDart();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasScored)
            return;

        DartTarget target = collision.gameObject.GetComponent<DartTarget>();

        if (target == null)
            return;

        Vector3 hitPoint = collision.contacts[0].point;

        int score = target.GetScore(hitPoint);

        Debug.Log("SCORE: " + score);

        if (scoreManager != null)
        {
            scoreManager.AddScore(score);
        }

        TargetFeedback feedback =
            collision.gameObject.GetComponent<TargetFeedback>();

        if (feedback != null)
        {
            feedback.Flash();
        }

        hasScored = true;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;

        StartCoroutine(ResetAfterDelay());
    }

    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(resetDelay);

        ResetDart();
    }

    public void ResetDart()
    {
        rb.isKinematic = false;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = startPosition;
        transform.rotation = startRotation;

        hasScored = false;
    }
}bdz`