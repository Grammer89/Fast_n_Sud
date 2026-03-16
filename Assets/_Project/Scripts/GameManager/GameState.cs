using UnityEngine;

public class GameState : MonoBehaviour
{
    #region Singleton Declaration
    private static GameState _instance;
    private static bool _isApplicationQuitting = false;

    public static GameState Instance
    {
        get
        {
            if (_isApplicationQuitting) return null;

            CreateOrGetInstance();
            return _instance;
        }
    }

    private static void CreateOrGetInstance()
    {
        if (_instance == null)
        {
            _instance = FindAnyObjectByType<GameState>(FindObjectsInactive.Include);
            if (_instance == null)
            {
                GameState prefab = Resources.Load<GameState>("Singletons/GameState");
                _instance = Instantiate(prefab);
            }
            DontDestroyOnLoad(_instance.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        _isApplicationQuitting = true;
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private int _totalCoins;
    public int TotalCoins { get { return _totalCoins; } }

    private bool _canDoubleJump = false;
    public bool CanDoubleJump { get { return _canDoubleJump; } }

    private int[] _topFiveScores = new int[5];
    public int[] TopFiveScores { get { return _topFiveScores; } }

    public void UnlockDoubleJump()
    {
        _canDoubleJump = true;
        Debug.Log("Hai sbloccato l'abilita' doppio salto!");
    }

    public void AddCoinsToTotal(int coins)
    {
        _totalCoins += coins;
        Debug.Log($"Hai raccolto {coins} monete. Adesso hai un totale di {_totalCoins} monete.");
    }

    public void TakeCoinsFromTotal(int coins)
    {
        if(coins > _totalCoins)
        {
            Debug.LogWarning("Non hai abbastanza monete!");
            return;
        }

        _totalCoins -= coins;
        Debug.Log($"Hai speso {coins} monete. Adesso ti restano {_totalCoins} monete.");
    }

    public void CheckScoreTopFive(int newScore)
    {
        for(int i = _topFiveScores.Length - 1; i >= 0; i--)
        {
            if(newScore > _topFiveScores[i])
            {
                for(int j = i; j > 0; j--)
                {
                    _topFiveScores[j - 1] = _topFiveScores[j];
                }
                _topFiveScores[i] = newScore;
                Debug.Log($"Il punteggio {newScore} e' stato aggiunto alla Top 5!");
                return;
            }
        }
    }
}
