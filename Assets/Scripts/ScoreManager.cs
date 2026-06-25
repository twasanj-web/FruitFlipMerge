using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text bestScoreText;

    private int currentScore;
    private int bestScore;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        UpdateScoreUI();
        UpdateBestScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;

            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();

            UpdateBestScoreUI();
        }

        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = currentScore.ToString();
    }

    private void UpdateBestScoreUI()
    {
        bestScoreText.text = bestScore.ToString();
    }

    public int GetCurrentScore()
    {
        Debug.Log("GetCurrentScore = " + currentScore);
        return currentScore;
    }

    public int GetBestScore()
    {
        Debug.Log("GetBestScore = " + bestScore);
        return bestScore;
    }
}