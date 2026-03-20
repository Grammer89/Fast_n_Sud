using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image[] hearts;           // Array dei cuori
    public Sprite fullHeart;         // Cuore rosso
    public Sprite emptyHeart;        // Cuore grigio

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Aggiorna i cuori in base agli HP correnti
    public void UpdateHearts(int currentHP)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHP)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }

    public void UpdateCoins(int coins)
    {
        if (coinText != null)
            coinText.text = coins.ToString();
    }

    public void UpdateScore(int score)
    {
        if(scoreText != null)
            scoreText.text = "SCORE: " + score.ToString();
    }
}