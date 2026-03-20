using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [Header("Position Enemy")]
    [SerializeField] private Transform _way1;
    [SerializeField] private Transform _way2;
    [SerializeField] private Transform _way3;
    public static SpawnEnemies Instance { get; protected set; }
    private PoolEnemy _poolEnemy;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _poolEnemy = GetComponent<PoolEnemy>();
            //DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        StartCoroutine(Spawning());
    }

    public IEnumerator Spawning()
    {
        while (!LevelManager.Instance.LevelCompleted || (!GameManager.instance.IsGameOver))
        {
            StartCoroutine(SpawnEnemy(_way1));
            StartCoroutine(SpawnEnemy(_way2));
            StartCoroutine(SpawnEnemy(_way3));
            yield return new WaitForSeconds(EnemyManager.Instance.TimeSpawn);
        }
    }

    public IEnumerator SpawnEnemy(Transform way)
    {

        //WaitForSeconds wfs = new WaitForSeconds(EnemyManager.Instance.TimeSpawn);

        //while(true)
        //{
        //    yield return wfs;
        //    Debug.Log("Spawn Enemy a " + way);
        _poolEnemy.SpawnEnemy(way);
        yield break;

    }

}
