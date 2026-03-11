using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        instance = this;
    }

    public void UpdateHP(int hp)
    {
        if (hpText != null)
            hpText.text = "HP: " + hp;
    }

    public void UpdateCoins(int coins)
    {
        if (coinText != null)
            coinText.text = "Coins: " + coins;
    }
}