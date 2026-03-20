
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PoolCoin : MonoBehaviour
{
    public Coin _coin;
    private void Awake()
    {
        // //_enemy = EnemyManager.Instance.GetEnemy();
        //if( _enemy != null )
        //{
        //    Debug.Log("Non è null");
        //}
        //else
        //{
        //    Debug.Log("è null");
        //}
    }
    public enum PoolType
    {
        Stack,
        LinkedList
    }

    public PoolType poolType;

    public bool collectionChecks = true;
    public int maxPoolSize = 10;

    IObjectPool<Coin> m_Pool;

    public IObjectPool<Coin> Pool
    {
        get
        {
            if (m_Pool == null)
            {
                if (poolType == PoolType.Stack)
                {
                    m_Pool = new ObjectPool<Coin>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
                }
                else
                {
                    m_Pool = new LinkedPool<Coin>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
                }

            }
            return m_Pool;
        }
    }

    Coin CreatePooledItem()
    {
        //Devo instanziare il gameObject

        var coin = Instantiate(_coin);
        coin.AddComponent<ReturnCoin>().pool = Pool;  //Dopo lo spawn indico con questa istruzione ritorna l'oggetto nel pool
        //ReturnPool _returnPool = GetComponent<ReturnPool>();
        //_returnPool.SetEnemy(enemy);
        Debug.Log("Created Enemy" + coin.gameObject.name);
        return coin;

    }

    void OnReturnedToPool(Coin coin)
    {
        coin.gameObject.SetActive(false);
    }

    void OnTakeFromPool(Coin coin)
    {
       coin.ResetValue();
       coin.gameObject.SetActive(true);

    }
    void OnDestroyPoolObject(Coin coin)
    {
        Destroy(coin.gameObject);
    }

    public void SpawnEnemy(Transform way)
    {
        //GUILayout.Label("Pool size" + Pool.CountInactive);
        //if (GUILayout.Button("Create Enemy"))
        //{
        Debug.Log("Spawn Enemy");
        var amount = Random.Range(1, 2);
        for (int i = 0; i < amount; i++)
        {
            var ps = Pool.Get();
            //ps.transform.position = Random.insideUnitSphere * 10;
            ps.transform.position = way.position;


        }
    }

    public void SetEnemy(Coin coin)
    {
        _coin = coin;
    }
}
