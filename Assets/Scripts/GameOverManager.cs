using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public TMP_Text currentScoreValue;
    public TMP_Text bestScoreValue;

    public void ShowGameOver(int currentScore, int bestScore)
    {
        gameOverPanel.SetActive(true);

        Canvas.ForceUpdateCanvases();

        Debug.Log("Current = " + currentScore);
        Debug.Log("Best = " + bestScore);

        currentScoreValue.SetText(currentScore.ToString());
        bestScoreValue.SetText(bestScore.ToString());

        currentScoreValue.ForceMeshUpdate();
        bestScoreValue.ForceMeshUpdate();

        Debug.Log("TMP Current = " + currentScoreValue.text);
        Debug.Log("TMP Best = " + bestScoreValue.text);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}