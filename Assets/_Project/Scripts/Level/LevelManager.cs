using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level Game Object")]
    [SerializeField] private GameObject[] _levelGameObject;
   

    public static LevelManager Instance { get; protected set; }

    private bool _levelCompleted;
    private int _level;
    public bool LevelCompleted
    {
        get
        { return _levelCompleted; }
        set
        {
            _levelCompleted = value;
        }
    }

    public int Level
    {
        get
        { return _level; }
        set
        {
            _level += value;
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            _level = 1;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }

    public GameObject GetLevel()
    {
        int index = Random.Range(0, _levelGameObject.Length);
        Debug.Log("è stato scelto il livello: " + index);
        return _levelGameObject[index];

    }

}
