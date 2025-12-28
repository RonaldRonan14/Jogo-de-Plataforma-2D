using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static int totalScore = 0;
    private int lives = 3;

    public TextMeshProUGUI scoreText;
    public List<GameObject> heartIcons;
    public GameObject gameOverPanel;

    public static GameController instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        UpdateScoreText();
    }

    public int GetScore() =>
        totalScore;

    public void AddScore(int value)
    {
        totalScore += value;
        UpdateScoreText();
    }

    public static void ResetGameProgress()
    {
        totalScore = 0;
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            int heartIndex = lives - 1;
            if (heartIcons != null && heartIndex < heartIcons.Count)
            {
                AudioManager.instance.PlaySFX(AudioManager.instance.danger);
                heartIcons[heartIndex].GetComponent<Heart>().LostHeart();
            }

            lives--;
            ResetAllPlatforms();

            if (lives <= 0)
            {
                Invoke(nameof(ShowGameOver), 0.05f);
            }
        }
    }

    public void ResetAllPlatforms()
    {
        FallingPlatform[] platforms = FindObjectsByType<FallingPlatform>(FindObjectsSortMode.None);
        foreach (FallingPlatform p in platforms)
        {
            p.ResetPlatform();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString().PadLeft(4, '0');
    }

    private void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.gameOver);
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0;
    }
}
