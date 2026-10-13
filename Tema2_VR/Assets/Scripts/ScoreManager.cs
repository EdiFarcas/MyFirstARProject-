using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text totalScoreText;
    public TMP_Text lastThrowText;

    private int totalScore = 0;

    public void AddScore(int score)
    {
        totalScore += score;

        totalScoreText.text = "Total Score: " + totalScore;
        lastThrowText.text = "Last Throw: " + score;
    }
}