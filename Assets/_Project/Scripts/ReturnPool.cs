using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Enemy))]
public class ReturnPool : MonoBehaviour
{
    public Enemy _enemy;
    public IObjectPool<Enemy> pool;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemy != null)
        {
            if (_enemy.TimeEnemy > 3f)
            {
                Debug.Log("Object Returned to Pool" + _enemy.gameObject.name);
                pool.Release(_enemy);
            }
        }
    }

    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }
}



