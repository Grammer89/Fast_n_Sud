using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    [HideInInspector] public int currentCoins = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        UIManager.instance.UpdateCoins(currentCoins);
    }

    public void SaveCoins()
    {
        GameState.Instance.AddCoinsToTotal(currentCoins);
    }

    public void ResetCoins()
    {
        currentCoins = 0;
    }
}