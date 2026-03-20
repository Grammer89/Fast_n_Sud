using UnityEngine;

public class ChangeSpawnEnemy : MonoBehaviour
{
    [SerializeField] private PoolEnemy _poolEnemy;

    private void Awake()
    {
        //_poolEnemy.SetEnemy(EnemyManager.Instance.GetEnemy());
    }
    private void Update()
    {
        if (LevelManager.Instance.LevelCompleted)
        {
            Enemy enemy = EnemyManager.Instance.GetEnemy();
            SetEnemyPoolEnemy(enemy);

        }
    }

    public void SetEnemyPoolEnemy(Enemy enemy)
    {
        _poolEnemy = GetComponent<PoolEnemy>();
        if (_poolEnemy != null)
        {
            _poolEnemy.SetEnemy(enemy);
            Debug.Log("Set Enemy in PoolEnemy");
        }
    }

    //public void SetEnemyReturnPool(Enemy enemy)
    //{
    //    _returnPool = GetComponent<PoolEnemy>();
    //    if (_returnPool != null)
    //    {
    //        _returnPool.SetEnemy(enemy);
    //        Debug.Log("Set Enemy in ReturnPoolEnemy");
    //    }
    //}
}
