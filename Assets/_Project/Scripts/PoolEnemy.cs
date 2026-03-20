using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PoolEnemy : MonoBehaviour
{
    public Enemy _enemy;
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

    IObjectPool<Enemy> m_Pool;

    public IObjectPool<Enemy> Pool
    {
        get
        {
            if (m_Pool == null)
            {
                if (poolType == PoolType.Stack)
                {
                    m_Pool = new ObjectPool<Enemy>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
                }
                else
                {
                    m_Pool = new LinkedPool<Enemy>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
                }

            }
            return m_Pool;
        }
    }

    Enemy CreatePooledItem()
    {
        //Devo instanziare il gameObject

        var enemy = Instantiate(_enemy);
        enemy.AddComponent<ReturnPool>().pool = Pool;  //Dopo lo spawn indico con questa istruzione ritorna l'oggetto nel pool
        //ReturnPool _returnPool = GetComponent<ReturnPool>();
        //_returnPool.SetEnemy(enemy);
        Debug.Log("Created Enemy" + enemy.gameObject.name);
        return enemy;

    }

    void OnReturnedToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    void OnTakeFromPool(Enemy enemy)
    {
        enemy.ResetValue();
        enemy.gameObject.SetActive(true);

    }
    void OnDestroyPoolObject(Enemy enemy)
    {
        Destroy(enemy.gameObject);
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

    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }

}
