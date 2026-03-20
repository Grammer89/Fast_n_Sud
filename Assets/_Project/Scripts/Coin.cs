using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float _time;
    public float TimeCoin{ get { return _time; } }
    public int value = 1;
    [SerializeField] private float velocity;
    [SerializeField] private float velocityRotation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin collected");

            MoneyManager.instance.AddCoins(value);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Vector3 newPosition = new Vector3((transform.position.x + (Time.deltaTime * velocity)), transform.position.y, transform.position.z);
        transform.position = newPosition;
        transform.Rotate(0, velocityRotation * Time.deltaTime, 0);

        _time += Time.deltaTime;

    }

    public void ResetValue()
    {
        Debug.Log("Reset Value ", gameObject);
        _time = 0;
    }
}