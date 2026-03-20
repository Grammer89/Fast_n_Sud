using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;

    public Transform player;

    private float startZ;
    private bool isGameOver = false;

    public bool IsGameOver {  get { return isGameOver; } }


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isGameOver = false;
        startZ = player.position.z;
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        Time.timeScale = 0f; // ferma il gioco
        if (gameOverPanel != null)  gameOverPanel.SetActive(true);

        // Calcolo score = distanza percorsa + monete raccolte
        float distance = player.position.z - startZ;
        int coins = MoneyManager.instance != null ? MoneyManager.instance.currentCoins : 0;
        int totalScore = Mathf.FloorToInt(distance) + coins;

        if (scoreText != null)
            scoreText.text = "Score: " + totalScore;

        // Salva le monete raccolte in PlayerPrefs
        if (MoneyManager.instance != null)
            MoneyManager.instance.SaveCoins();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Intro");
    }
}