
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Setting Enemies Prefab")]
    [SerializeField]  private Enemy[] _enemyLevel;
    [Header("Setting Timespawn Enemy")]
    [SerializeField] private float _timeSpawn;
    public float TimeSpawn
    {
        get
        { return _timeSpawn; }
        set
        {
            _timeSpawn -= value;
        }
    }
    public static EnemyManager Instance { get; protected set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _timeSpawn = 3;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }

    public Enemy GetEnemy()
    {
        int index = Random.Range(0, _enemyLevel.Length);
        return _enemyLevel[index];

        Debug.Log("Recuperato il nemico numero " + index);
    }
    // Update is called once per frame
    void Update()
    {

    }


}
