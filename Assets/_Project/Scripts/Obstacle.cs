using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit obstacle");

            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}