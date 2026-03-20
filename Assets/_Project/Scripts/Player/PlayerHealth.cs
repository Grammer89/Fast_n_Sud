using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    private void Start()
    {
        currentHP = maxHP;
        if (UIManager.instance != null)
            UIManager.instance.UpdateHearts(currentHP);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (UIManager.instance != null)
            UIManager.instance.UpdateHearts(currentHP);

        if (currentHP <= 0)
        {
            Die();
            Debug.Log("Addio");
        }
    }

    private void Die()
    {
        if (MoneyManager.instance != null)
            MoneyManager.instance.SaveCoins();

        GameManager.instance.GameOver();
    }
}