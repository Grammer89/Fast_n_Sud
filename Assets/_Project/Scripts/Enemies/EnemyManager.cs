using System;
using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Setting Enemies Prefab")]
    [SerializeField]  private Enemy[] _enemyLevel1;
    [SerializeField]  private Enemy[] _enemyLevel2;
    [SerializeField]  private Enemy[] _enemyLevel3;
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

    // Update is called once per frame
    void Update()
    {

    }


}
