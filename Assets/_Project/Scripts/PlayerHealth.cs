using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
        UIManager.instance.UpdateHP(currentHP);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        UIManager.instance.UpdateHP(currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Salva le monete raccolte prima di GameOver
        if (MoneyManager.instance != null)
            MoneyManager.instance.SaveCoins();

        // Collega la morte al Game Over
        GameManager.instance.GameOver();
    }
}