using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;
    float timeRemaining = 60f;

    private int score = 0;

    void Awake() => instance = this;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
        }
        else
        {
            timerText.text = "Time Up!";
        }
    }

    public void AddScore(int amount)
    {
        if (timeRemaining <= 0) return;

        score += amount;
        scoreText.text = "Score: " + score;
    }
}