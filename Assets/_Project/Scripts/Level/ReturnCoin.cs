using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Coin))]
public class ReturnCoin : MonoBehaviour
{
    public Coin _coin;
    public IObjectPool<Coin> pool;
    // Start is called before the first frame update
    void Start()
    {
        _coin = GetComponent<Coin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_coin != null)
        {
            if (_coin.TimeCoin > 3f)
            {
                pool.Release(_coin);
            }
        }
    }

    public void SetEnemy(Coin coin)
    {
        _coin = coin;
    }
}
