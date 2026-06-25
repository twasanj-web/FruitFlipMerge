using System.Collections;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private GameOverManager gameOverManager;

    private Coroutine gameOverCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Fruit"))
            return;

        if (gameOverCoroutine == null)
            gameOverCoroutine = StartCoroutine(GameOverDelay());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Fruit"))
            return;

        if (gameOverCoroutine != null)
        {
            StopCoroutine(gameOverCoroutine);
            gameOverCoroutine = null;
        }
    }

    private IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(1f);

        gameOverManager.ShowGameOver(
            ScoreManager.Instance.GetCurrentScore(),
            ScoreManager.Instance.GetBestScore());

        gameOverCoroutine = null;
    }
}
