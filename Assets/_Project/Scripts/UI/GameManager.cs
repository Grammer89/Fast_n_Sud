using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject hud;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;

    public Transform player;

    private bool isGameOver = false;
    public bool IsGameOver {  get { return isGameOver; } }

    private int _timeScore;
    private float _lastScoreUpdate;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _timeScore = 0;
        _lastScoreUpdate = 0f;

        isGameOver = false;
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (!isGameOver && Time.time - _lastScoreUpdate > 1f)
        {
            _timeScore += 1;
            _lastScoreUpdate = Time.time;
            UIManager.instance.UpdateScore(_timeScore);
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        Time.timeScale = 0f; // ferma il gioco
        if (gameOverPanel != null)  gameOverPanel.SetActive(true);

        // Calcolo score = tempo sopravvissuto + monete raccolte
        int coins = MoneyManager.instance != null ? MoneyManager.instance.currentCoins : 0;
        int totalScore = _timeScore + coins;

        if (scoreText != null)
            scoreText.text = "Score: " + totalScore;

        if (coinsText != null)
            coinsText.text = "Monete: " + coins;

        if (hud != null)
            hud.SetActive(false);

        // Aggiungo il punteggio alla top 5 se abbastanza alto
        GameState.Instance.CheckScoreTopFive(totalScore);

        // Salva le monete raccolte in GameState
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