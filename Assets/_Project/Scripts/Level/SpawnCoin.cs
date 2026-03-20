using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [Header("Position Coin")]
    [SerializeField] private Transform _way1;
    [SerializeField] private Transform _way2;
    [SerializeField] private Transform _way3;
    public static SpawnCoin Instance { get; protected set; }
    private PoolCoin _poolCoin;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _poolCoin = GetComponent<PoolCoin>();
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
        _poolCoin.SpawnEnemy(way);
        yield break;

    }
}
